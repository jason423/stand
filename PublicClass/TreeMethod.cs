using System.Data;
using System.Net.Sockets;

namespace PublicClass
{
    public class TreeMethod
    {
        private static DataTable dtTree = SqlHelper.Query(@"select * from stand_Tree").Tables[0];

        public TreeMethod()
        {
            
        }

        public static  void GetCodeByTreeId(DataTable dt)
        {           
            foreach (DataRow dr in (dt.Rows))
            {
                DataRow drTwo =dtTree.Select("Id='" +dr["PID"]+ "'")[0];
                dr["ClassifyTwo"] = drTwo["Code"].ToString();
                DataRow drThree = dtTree.Select("Id='" + drTwo["PID"] + "'")[0];
                dr["ClassifyOne"] = drThree["Code"].ToString();
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "ClassifyOne,ClassifyTwo,ClassifyThree Asc";

            dt = dv.ToTable();
        }

        
       
    }
}