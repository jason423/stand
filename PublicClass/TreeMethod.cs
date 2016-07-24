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
            dt.Columns.Add("ClassifyOne");
            dt.Columns.Add("ClassifyTwo");
            dt.Columns.Add("ClassifyThree");
            foreach (var dr in (dt.Rows))
            {
                
            }
        }

        
       
    }
}