using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Model;
namespace BLL {
	 	//stand_Role
		public partial class stand_Role
	{
   		     
		private readonly DAL.stand_Role dal=new DAL.stand_Role();
		public stand_Role()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.stand_Role model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.stand_Role model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.stand_Role GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public Model.stand_Role GetModelByCache(int Id)
		//{
			
		//	string CacheKey = "stand_RoleModel-" + Id;
		//	object objModel = SqlHelper.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(Id);
		//			if (objModel != null)
		//			{
		//				int ModelCache = SqlHelper.ConfigHelper.GetConfigInt("ModelCache");
		//				SqlHelper.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (Model.stand_Role)objModel;
		//}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.stand_Role> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.stand_Role> DataTableToList(DataTable dt)
		{
			List<Model.stand_Role> modelList = new List<Model.stand_Role>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.stand_Role model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Model.stand_Role();					
													if(dt.Rows[n]["Id"].ToString()!="")
				{
					model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
				}
																																				model.RoleName= dt.Rows[n]["RoleName"].ToString();
																																model.Remark= dt.Rows[n]["Remark"].ToString();
																						
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}