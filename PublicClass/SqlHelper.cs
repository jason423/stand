using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Threading;
using System.Transactions;
using System.Web;

namespace PublicClass
{
    public  class  SqlHelper
    {






        public static readonly string connectionStringName = "stand";
        public static readonly string connectionString = GetConnectionString();

        //protected static String ReadAppSetting(String Name)
        //{
        //    bool keyExist = false;
        //    foreach (ConnectionStringSettings con in ConfigurationManager.ConnectionStrings)
        //    {
        //        if (con.Name.ToLower().Equals(Name.ToLower()))
        //        {
        //            keyExist = true;
        //        }
        //    }
        //    if (keyExist)
        //        return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        //    else
        //        return "";
        //}

        public static string GetConnectionString()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            path = Path.GetDirectoryName(path) + "\\app.config";
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = path;// 这里对应你app1文件的路径
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            string connstring = PublicClass.EnDeCode.Decode(config.ConnectionStrings.ConnectionStrings["stand"].ConnectionString);
            return connstring;
        }

        /// <summary>
        /// 哈希表来存储缓存参数
        /// </summary>
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        public static bool Exists(string strSql, params SqlParameter[] commandParameters)
        {
            object obj = SqlHelper.GetSingle(strSql, commandParameters);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            return cmdresult > 0;
        }

        public static object GetSingle(string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(connectionString, CommandType.Text, strSql, commandParameters);
        }

        public static object GetSingle(string conn, string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(conn, CommandType.Text, strSql, commandParameters);
        }

        public static object GetSingle(SqlTransaction trans, string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(trans, CommandType.Text, strSql, commandParameters);
        }

        public static int ExecuteSql(SqlTransaction trans, string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(trans, CommandType.Text, strSql, commandParameters);
        }

        public static int ExecuteSql(string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, strSql, commandParameters);
        }

        public static int ExecuteSql(string conn, string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(conn, CommandType.Text, strSql, commandParameters);
        }

        public static DataSet Query(string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, CommandType.Text, strSql, commandParameters);
        }

        public static DataSet Query(string conn, string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(conn, CommandType.Text, strSql, commandParameters);
        }

        public static SqlDataReader ExecuteReader(string strSql, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(connectionString, CommandType.Text, strSql, commandParameters);
        }



        #region ExecuteNonQuery
        /// <summary>
        /// 执行数据库操作
        /// 事物执行事例：
        /// using (TransactionScope scope = new TransactionScope())
        ///	{
        ///		SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "sp_tables", null);
        ///		SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "sp_tables", null);
        ///		scope.Complete();
        ///	}
        /// </summary>
        /// <param name="connectionString">连接数据库字符串</param>
        /// <param name="cmdType">在CommandType （存储过程，Sql语句问题）</param>
        /// <param name="cmdText">存储过程名称或者Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                if (Transaction.Current == null)
                {
                    SqlCommand cmd = new SqlCommand();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return val;
                    }
                }
                else
                {
                    SqlConnection connection = GetTransactionSqlConnection(connectionString);
                    using (SqlCommand cmd = CreateCommand(connection, cmdType, cmdText, commandParameters))
                    {
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return val;
                    }
                }
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// 执行数据库操作
        /// </summary>
        /// <param name="cmdType">在CommandType （存储过程，Sql语句问题）</param>
        /// <param name="cmdText">存储过程名称或者Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, cmdType, cmdText, commandParameters);
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            finally
            {
                
            }

        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// 执行数据库操作(事物)
        /// </summary>
        /// <param name="connectionString">连接数据库字符串</param>
        /// <param name="cmdType">在CommandType （存储过程，Sql语句问题）</param>
        /// <param name="cmdText">存储过程名称或者Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>执行结果 成功为True 失败为False</returns>
        public static bool ExecuteNonQueryTrans(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            finally
            {
                
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <param name="connectionString">连接数据库字符串</param>
        /// <param name="cmdType">在CommandType （存储过程，Sql语句问题）</param>
        /// <param name="cmdText">存储过程名称或者Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回SqlDataReader结果</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection connection = new SqlConnection(connectionString);
                // we use a try/catch here because if the method throws an exception we want to 
                // close the connection throw code, because no datareader will exist, hence the 
                // commandBehaviour.CloseConnection will not work
                try
                {
                    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Parameters.Clear();
                    return rdr;
                }
                catch
                {
                    connection.Close();
                    throw;
                }
            }
            finally
            {
                
            }
        }
        /// <summary>
        /// 重写ExecuteReader给Job使用
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReaderJob(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行的SqlCommand ，返回的第一列的第一条记录的数据库中指定的连接字符串
        /// 事物执行事例：
        /// using (TransactionScope scope = new TransactionScope())
        ///	{
        ///		SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "sp_tables", null);
        ///		SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "sp_tables", null);
        ///		scope.Complete();
        ///	}
        /// </summary>
        /// <param name="cmdType">在CommandType （存储过程，Sql语句问题）</param>
        /// <param name="cmdText">存储过程名称或者Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回首行首列值</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                if (Transaction.Current == null)
                {
                    SqlCommand cmd = new SqlCommand();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                            object val = cmd.ExecuteScalar();
                            cmd.Parameters.Clear();
                            return val;
                        }
                        catch
                        {
                            return null;
                        }
                    }
                }
                else
                {
                    SqlConnection connection = GetTransactionSqlConnection(connectionString);
                    using (SqlCommand cmd = CreateCommand(connection, cmdType, cmdText, commandParameters))
                    {
                        object val = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        return val;
                    }
                }
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                if (transaction == null) throw new ArgumentNullException("transaction");
                if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

                // Create a command and prepare it for execution
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, transaction.Connection, transaction, commandType, cmdText, commandParameters);

                // Execute the command & return the results
                object retval = cmd.ExecuteScalar();

                // Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
                return retval;
            }
            finally
            {
                
            }
        }
        #endregion

        #region ExecuteDataset
        /// <summary>
        /// 返回查询结果集
        /// </summary>
        /// <param name="connectionString">连接数据库字符串</param>
        /// <param name="cmdType">在CommandType （存储过程，Sql语句问题）</param>
        /// <param name="cmdText">存储过程名称或者Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);

                    // Create the DataAdapter & DataSet
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmd.Parameters.Clear();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            throw new System.Exception(ex.Message);
                        }
                        return ds;
                    }
                }
            }
            finally
            {
                
            }
        }

        /// <summary>
        /// 返回查询结果集
        /// </summary>
        /// <param name="cmdType">在CommandType （存储过程，Sql语句问题）</param>
        /// <param name="cmdText">存储过程名称或者Sql语句</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteDataSet(connectionString, cmdType, cmdText, commandParameters);
        }

        #endregion

        #region TransactionSqlConnection
        /// <summary>
        ///获取SqlConnection的事物对象
        /// </summary>
        /// <param name="connectionString">The name of the connection string to use.</param>
        /// <returns>The SqlConnection associated with the current transaction.</returns>
        /// <remarks>If no SqlConnection exists, one will be created.</remarks>
        private static SqlConnection GetTransactionSqlConnection(string connectionString)
        {
            LocalDataStoreSlot connectionDictionarySlot = Thread.GetNamedDataSlot("ConnectionDictionary");
            Dictionary<string, SqlConnection> connectionDictionary = (Dictionary<string, SqlConnection>)Thread.GetData(connectionDictionarySlot);

            if (connectionDictionary == null)
            {
                connectionDictionary = new Dictionary<string, SqlConnection>();
                Thread.SetData(connectionDictionarySlot, connectionDictionary);
            }

            SqlConnection connection = null;

            if (connectionDictionary.ContainsKey(connectionStringName))
            {
                connection = connectionDictionary[connectionStringName];
            }
            else
            {
                connection = new SqlConnection(connectionString);
                connectionDictionary.Add(connectionStringName, connection);
                Transaction.Current.TransactionCompleted += new TransactionCompletedEventHandler(Current_TransactionCompleted);
            }

            return connection;
        }

        /// <summary>
        /// 完成事物后关闭所有的对象
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The TransactionEventArgs that contains the event data.</param>
        /// <remarks>This event handler will attempt to close any participating SqlConnections in the transaction.</remarks>
        private static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
        {
            LocalDataStoreSlot connectionDictionarySlot = Thread.GetNamedDataSlot("ConnectionDictionary");
            Dictionary<string, SqlConnection> connectionDictionary = (Dictionary<string, SqlConnection>)Thread.GetData(connectionDictionarySlot);
            if (connectionDictionary != null)
            {
                foreach (SqlConnection connection in connectionDictionary.Values)
                {
                    if (connection != null && connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }

                connectionDictionary.Clear();
            }
            Thread.FreeNamedDataSlot("ConnectionDictionary");
        }
        #endregion

        #region PrepareCommand
        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    if (parm.Value == null)
                        parm.Value = DBNull.Value;

                    cmd.Parameters.Add(parm);
                }
            }
        }

        private static SqlCommand CreateCommand(SqlConnection connection, CommandType commandType, string commandText, params object[] values)
        {
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = commandType;

            // Append each parameter to the command
            if (values == null || values.Length == 0)
            {
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    command.Parameters[i].Value = DBNull.Value;
                }
            }
            else
            {
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    command.Parameters[i].Value = CheckValue(values[i]);
                }
            }

            return command;
        }

        private static object CheckValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }
        #endregion

        #region 生成参数
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, object Value)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Input, Value);
        }

        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Output, null);
        }

        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
        }

        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            param = MakeParam(ParamName, DbType, Size);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            return param;
        }
        #endregion 生成参数结束

        #region 缓存方法
        /// <summary>
        /// 追加参数数组到缓存.
        /// </summary>
        /// <param name="ConnectionString">一个有效的数据库连接字符串</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <param name="commandParameters">要缓存的参数数组</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            if (cacheKey == null || cacheKey.Length == 0) throw new ArgumentNullException("CacheKey");
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 从缓存中获取参数数组.
        /// </summary>
        /// <param name="ConnectionString">一个有效的数据库连接字符</param>
        /// <param name="commandText">存储过程名或SQL语句</param>
        /// <returns>参数数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        #endregion 缓存方法结束
    }
   
}
