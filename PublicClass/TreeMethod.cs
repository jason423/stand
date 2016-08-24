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
            dt.Columns.Add("ClassifyTwo", typeof(string));
            dt.Columns.Add("ClassifyOne", typeof(string));
            foreach (DataRow dr in (dt.Rows))
            {
                if (!string.IsNullOrWhiteSpace(dr["PID"].ToString()))
                {

                    DataRow[] drs = dtTree.Select("Id='" + dr["PID"] + "'");
                    if (drs.Length > 0)
                    {
                        dr["ClassifyTwo"] = drs[0]["Code"].ToString();
                        DataRow drThree = dtTree.Select("Id='" + drs[0]["PID"] + "'")[0];
                        dr["ClassifyOne"] = drThree["Code"].ToString();
                    }
                }
            }
            DataView dv = dt.DefaultView;
            dv.Sort = "ClassifyOne,ClassifyTwo,ClassifyThree Asc";

            dt = dv.ToTable();
        }

        
       
    }
}