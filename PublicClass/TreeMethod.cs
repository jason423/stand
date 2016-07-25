using System.Data;
using System.Net.Sockets;

namespace PublicClass
{
    public class TreeMethod
    {
        private DataTable dtTree;

        public TreeMethod()
        {
            dtTree = SqlHelper.Query(@"select * from stand_Tree").Tables[0];
        }

        public void GetCodeByTreeId(DataTable dt)
        {           
            foreach (DataRow dr in (dt.Rows))
            {
                DataRow drTwo =dtTree.Select("Id='" +dr["PID"].ToString()+ "'")[0];
                dr["ClassifyTwo"] = drTwo["Code"].ToString();
                DataRow drThree = dtTree.Select("Id='" + drTwo["PID"].ToString() + "'")[0];
                dr["ClassifyOne"] = drThree["Code"].ToString();
            }
        }

        
       
    }
}