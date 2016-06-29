using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Model{
	 	//stand_User
		public class stand_User
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
		/// UserName
        /// </summary>		
		private string _username;
        public string UserName
        {
            get{ return _username; }
            set{ _username = value; }
        }        
		/// <summary>
		/// Account
        /// </summary>		
		private string _account;
        public string Account
        {
            get{ return _account; }
            set{ _account = value; }
        }        
		/// <summary>
		/// Password
        /// </summary>		
		private string _password;
        public string Password
        {
            get{ return _password; }
            set{ _password = value; }
        }        
		/// <summary>
		/// Phone
        /// </summary>		
		private string _phone;
        public string Phone
        {
            get{ return _phone; }
            set{ _phone = value; }
        }        
		/// <summary>
		/// IdCard
        /// </summary>		
		private string _idcard;
        public string IdCard
        {
            get{ return _idcard; }
            set{ _idcard = value; }
        }        
		/// <summary>
		/// Role
        /// </summary>		
		private string _role;
        public string Role
        {
            get{ return _role; }
            set{ _role = value; }
        }        
		/// <summary>
		/// Email
        /// </summary>		
		private string _email;
        public string Email
        {
            get{ return _email; }
            set{ _email = value; }
        }        
		/// <summary>
		/// RealName
        /// </summary>		
		private string _realname;
        public string RealName
        {
            get{ return _realname; }
            set{ _realname = value; }
        }        
		/// <summary>
		/// Points
        /// </summary>		
		private int _points;
        public int Points
        {
            get{ return _points; }
            set{ _points = value; }
        }        
		   
	}
}

