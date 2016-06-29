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
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from stand_User");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			return SqlHelper.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Model.stand_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into stand_User(");			
            strSql.Append("Id,UserName,Account,Password,Phone,IdCard,Role,Email,RealName,Points");
			strSql.Append(") values (");
            strSql.Append("@Id,@UserName,@Account,@Password,@Phone,@IdCard,@Role,@Email,@RealName,@Points");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Account", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Password", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@IdCard", SqlDbType.VarChar,18) ,            
                        new SqlParameter("@Role", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@RealName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Points", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.UserName;                        
            parameters[2].Value = model.Account;                        
            parameters[3].Value = model.Password;                        
            parameters[4].Value = model.Phone;                        
            parameters[5].Value = model.IdCard;                        
            parameters[6].Value = model.Role;                        
            parameters[7].Value = model.Email;                        
            parameters[8].Value = model.RealName;                        
            parameters[9].Value = model.Points;                        
			            SqlHelper.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.stand_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update stand_User set ");
			                        
            strSql.Append(" Id = @Id , ");                                    
            strSql.Append(" UserName = @UserName , ");                                    
            strSql.Append(" Account = @Account , ");                                    
            strSql.Append(" Password = @Password , ");                                    
            strSql.Append(" Phone = @Phone , ");                                    
            strSql.Append(" IdCard = @IdCard , ");                                    
            strSql.Append(" Role = @Role , ");                                    
            strSql.Append(" Email = @Email , ");                                    
            strSql.Append(" RealName = @RealName , ");                                    
            strSql.Append(" Points = @Points  ");            			
			strSql.Append(" where Id=@Id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Account", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Password", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Phone", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@IdCard", SqlDbType.VarChar,18) ,            
                        new SqlParameter("@Role", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@RealName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Points", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.UserName;                        
            parameters[2].Value = model.Account;                        
            parameters[3].Value = model.Password;                        
            parameters[4].Value = model.Phone;                        
            parameters[5].Value = model.IdCard;                        
            parameters[6].Value = model.Role;                        
            parameters[7].Value = model.Email;                        
            parameters[8].Value = model.RealName;                        
            parameters[9].Value = model.Points;                        
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from stand_User ");
			strSql.Append(" where Id=@Id ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;


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
		/// 得到一个对象实体
		/// </summary>
		public Model.stand_User GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, UserName, Account, Password, Phone, IdCard, Role, Email, RealName, Points  ");			
			strSql.Append("  from stand_User ");
			strSql.Append(" where Id=@Id ");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			
			Model.stand_User model=new Model.stand_User();
			DataSet ds=SqlHelper.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
												if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
																																				model.UserName= ds.Tables[0].Rows[0]["UserName"].ToString();
																																model.Account= ds.Tables[0].Rows[0]["Account"].ToString();
																																model.Password= ds.Tables[0].Rows[0]["Password"].ToString();
																																model.Phone= ds.Tables[0].Rows[0]["Phone"].ToString();
																																model.IdCard= ds.Tables[0].Rows[0]["IdCard"].ToString();
																																model.Role= ds.Tables[0].Rows[0]["Role"].ToString();
																																model.Email= ds.Tables[0].Rows[0]["Email"].ToString();
																																model.RealName= ds.Tables[0].Rows[0]["RealName"].ToString();
																												if(ds.Tables[0].Rows[0]["Points"].ToString()!="")
				{
					model.Points=int.Parse(ds.Tables[0].Rows[0]["Points"].ToString());
				}
																														
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
			strSql.Append(" FROM stand_User ");
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
			strSql.Append(" FROM stand_User ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlHelper.Query(strSql.ToString());
		}
        /// <summary>
        /// 通过账号密码获取实体
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
		    public Model.stand_User GetUserByAccountPwd(string account, string pwd)
        {
            DataTable dt = SqlHelper.Query("select * from stand_User where (Account=@Account or Email=@Account or Phone=@Account) and Password=@Password", new SqlParameter("@Account", account), new SqlParameter("@Password", pwd)).Tables[0];
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

	}
}

