using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using PublicClass;
namespace DAL  
{
	 	//stand_ConfigValue
		public partial class stand_ConfigValue
	{
   		     
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from stand_ConfigValue");
			strSql.Append(" where ");
			                                       strSql.Append(" ID = @ID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return SqlHelper.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.stand_ConfigValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into stand_ConfigValue(");			
            strSql.Append("Name,Value");
			strSql.Append(") values (");
            strSql.Append("@Name,@Value");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Value", SqlDbType.VarChar,500)             
              
            };
			            
            parameters[0].Value = model.Name;                        
            parameters[1].Value = model.Value;                        
			   
			object obj = SqlHelper.GetSingle(strSql.ToString(),parameters);			
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
		public bool Update(Model.stand_ConfigValue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update stand_ConfigValue set ");
			                                                
            strSql.Append(" Name = @Name , ");                                    
            strSql.Append(" Value = @Value  ");            			
			strSql.Append(" where ID=@ID ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Value", SqlDbType.VarChar,500)             
              
            };
						            
            parameters[0].Value = model.ID;                        
            parameters[1].Value = model.Name;                        
            parameters[2].Value = model.Value;                        
            int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stand_ConfigValue ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;


			int rows=SqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stand_ConfigValue ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=SqlHelper.ExecuteSql(strSql.ToString());
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
		public Model.stand_ConfigValue GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID, Name, Value  ");			
			strSql.Append("  from stand_ConfigValue ");
			strSql.Append(" where ID=@ID");
						SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			
			Model.stand_ConfigValue model=new Model.stand_ConfigValue();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
																																				model.Name= ds.Tables[0].Rows[0]["Name"].ToString();
																																model.Value= ds.Tables[0].Rows[0]["Value"].ToString();
																										
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM stand_ConfigValue ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlHelper.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM stand_ConfigValue ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}

   
	}
}

