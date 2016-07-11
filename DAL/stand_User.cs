using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using PublicClass;

namespace DAL  
{
	 	//stand_User
		public partial class stand_User
	{

        #region  BasicMethod

        

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from stand_User");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return SqlHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.stand_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into stand_User(");
            strSql.Append("UserName,Account,Password,Phone,IdCard,Role,Email,RealName,Points)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Account,@Password,@Phone,@IdCard,@Role,@Email,@RealName,@Points)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@Account", SqlDbType.VarChar,500),
                    new SqlParameter("@Password", SqlDbType.VarChar,500),
                    new SqlParameter("@Phone", SqlDbType.VarChar,500),
                    new SqlParameter("@IdCard", SqlDbType.VarChar,18),
                    new SqlParameter("@Role", SqlDbType.VarChar,50),
                    new SqlParameter("@Email", SqlDbType.VarChar,200),
                    new SqlParameter("@RealName", SqlDbType.VarChar,50),
                    new SqlParameter("@Points", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.IdCard;
            parameters[5].Value = model.Role;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.RealName;
            parameters[8].Value = model.Points;

            object obj = SqlHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.stand_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update stand_User set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Account=@Account,");
            strSql.Append("Password=@Password,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("IdCard=@IdCard,");
            strSql.Append("Role=@Role,");
            strSql.Append("Email=@Email,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("Points=@Points");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@Account", SqlDbType.VarChar,500),
                    new SqlParameter("@Password", SqlDbType.VarChar,500),
                    new SqlParameter("@Phone", SqlDbType.VarChar,500),
                    new SqlParameter("@IdCard", SqlDbType.VarChar,18),
                    new SqlParameter("@Role", SqlDbType.VarChar,50),
                    new SqlParameter("@Email", SqlDbType.VarChar,200),
                    new SqlParameter("@RealName", SqlDbType.VarChar,50),
                    new SqlParameter("@Points", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.IdCard;
            parameters[5].Value = model.Role;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.RealName;
            parameters[8].Value = model.Points;
            parameters[9].Value = model.Id;

            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stand_User ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            int rows = SqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from stand_User ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = SqlHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.stand_User GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserName,Account,Password,Phone,IdCard,Role,Email,RealName,Points from stand_User ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Model.stand_User model = new Model.stand_User();
            DataSet ds = SqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.stand_User DataRowToModel(DataRow row)
        {
            Model.stand_User model = new Model.stand_User();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Account"] != null)
                {
                    model.Account = row["Account"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["IdCard"] != null)
                {
                    model.IdCard = row["IdCard"].ToString();
                }
                if (row["Role"] != null)
                {
                    model.Role = row["Role"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["Points"] != null && row["Points"].ToString() != "")
                {
                    model.Points = int.Parse(row["Points"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,UserName,Account,Password,Phone,IdCard,Role,Email,RealName,Points ");
            strSql.Append(" FROM stand_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,UserName,Account,Password,Phone,IdCard,Role,Email,RealName,Points ");
            strSql.Append(" FROM stand_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM stand_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from stand_User T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return SqlHelper.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "stand_User";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqlHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
        /// <summary>
        /// 通过账号密码获取实体
        /// </summary>
        /// <param name="account">账号或手机号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public Model.stand_User GetUserByAccountPwd(string account, string pwd)
        {
            DataTable dt = SqlHelper.Query("select * from stand_User where (Account=@Account or Phone=@Account) and Password=@Password", new SqlParameter("@Account", PublicClass.EnDeCode.Encode(account)), new SqlParameter("@Password", PublicClass.EnDeCode.Encode(pwd))).Tables[0];
            if (dt.Rows.Count == 1)
            {
                Model.stand_User userModel = GetModel((int)dt.Rows[0]["ID"]);
                return userModel;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 通过账号获取实体
        /// </summary>
        /// <param name="account">账号或手机号</param>
        /// <returns></returns>
        public Model.stand_User GetUserByAccount(string account)
        {
            DataTable dt = SqlHelper.Query("select * from stand_User where Account=@Account or Phone=@Account", new SqlParameter("@Account", PublicClass.EnDeCode.Encode(account))).Tables[0];
            if (dt.Rows.Count == 1)
            {
                Model.stand_User userModel = GetModel((int)dt.Rows[0]["ID"]);
                return userModel;
            }
            else
            {
                return null;
            }
        }

        public bool HasUserByAccount(string account)
        {
            DataTable dt = SqlHelper.Query("select * from stand_User where Account=@Account or  Phone=@Account", new SqlParameter("@Account", EnDeCode.Encode(account))).Tables[0];
            if (dt.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

