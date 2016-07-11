using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Model;
namespace BLL
{
    //stand_User
    public partial class stand_User
    {

        private readonly DAL.stand_User dal = new DAL.stand_User();
        public stand_User()
        { }

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
        public void Add(Model.stand_User model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.stand_User model)
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
        /// 得到一个对象实体
        /// </summary>
        public Model.stand_User GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.stand_User GetModelByCache(int Id)
        //{

        //	string CacheKey = "stand_UserModel-" + Id;
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
        //	return (Model.stand_User)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.stand_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.stand_User> DataTableToList(DataTable dt)
        {
            List<Model.stand_User> modelList = new List<Model.stand_User>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.stand_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.stand_User();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.Account = dt.Rows[n]["Account"].ToString();
                    model.Password = dt.Rows[n]["Password"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.IdCard = dt.Rows[n]["IdCard"].ToString();
                    model.Role = dt.Rows[n]["Role"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.RealName = dt.Rows[n]["RealName"].ToString();
                    if (dt.Rows[n]["Points"].ToString() != "")
                    {
                        model.Points = int.Parse(dt.Rows[n]["Points"].ToString());
                    }


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

        public Model.stand_User GetUserByAccountPwd(string account, string pwd)
        {
            return dal.GetUserByAccountPwd(account, pwd);
        }

        public Model.stand_User GetUserByAccount(string account)
        {
            return dal.GetUserByAccount(account);
        }
        public bool HasUserByAccount(string account)
        {
            return dal.HasUserByAccount(account);
        }
        #endregion
    }
}