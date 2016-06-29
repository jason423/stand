using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//stand_Role
		public class stand_Role
	{
   		     
      	/// <summary>
		/// Id
        /// </summary>		
		private int _id;
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// RoleName
        /// </summary>		
		private string _rolename;
        public string RoleName
        {
            get{ return _rolename; }
            set{ _rolename = value; }
        }        
		/// <summary>
		/// Remark
        /// </summary>		
		private string _remark;
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }        
		   
	}
}

