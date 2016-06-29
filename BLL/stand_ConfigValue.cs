using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Model;
namespace BLL {
	 	//stand_ConfigValue
		public partial class stand_ConfigValue
	{
   		     
		private readonly DAL.stand_ConfigValue dal=new DAL.stand_ConfigValue();
		public stand_ConfigValue()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.stand_ConfigValue model)
		{
						return dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.stand_ConfigValue model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
				/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.stand_ConfigValue GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		//public Model.stand_ConfigValue GetModelByCache(int ID)
		//{
			
		//	string CacheKey = "stand_ConfigValueModel-" + ID;
		//	object objModel = SqlHelper.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel(ID);
		//			if (objModel != null)
		//			{
		//				int ModelCache = SqlHelper.ConfigHelper.GetConfigInt("ModelCache");
		//				SqlHelper.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (Model.stand_ConfigValue)objModel;
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
		public List<Model.stand_ConfigValue> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.stand_ConfigValue> DataTableToList(DataTable dt)
		{
			List<Model.stand_ConfigValue> modelList = new List<Model.stand_ConfigValue>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.stand_ConfigValue model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Model.stand_ConfigValue();					
													if(dt.Rows[n]["ID"].ToString()!="")
				{
					model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				}
																																				model.Name= dt.Rows[n]["Name"].ToString();
																																model.Value= dt.Rows[n]["Value"].ToString();
																						
				
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