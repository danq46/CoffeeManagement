using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoffeeManagement.DbUtilities;
using System.Security.Cryptography;
using System.Text;

namespace CoffeeManagement.DbUtilities
{
    public class User : Database
    {
        public Int32 UserID;
        public String Username;
        public void LoginUser(String username, String password, out Boolean isAuth)
        {
            var dbUserPassword = GetPasswordbByUsername(username);
            if (!String.IsNullOrEmpty(dbUserPassword)) 
            {
                
                using (var userDataReader = GetUserbByUsernameAndPassword(username, password)) 
                {
                    UserID = Convert.ToInt32(userDataReader.GetValue("UserID").ToString());
                    Username = userDataReader.GetValue("UserName").ToString();
                }
            
            }
            isAuth = true;
        }
        private String GetPasswordbByUsername(String username)
        {
            var userReader = Procedure("proc_GetPasswordbByUsername")
            .Params(
               new SqlParameter("@Username", username)
            ).Execute<DataTable>();

            var rows = userReader.Select();
             
            return rows[0]["Password"].ToString();
        }
        public void SignUpUser(String username, String password, out Boolean signedUp) 
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var sha = new SHA1CryptoServiceProvider();
            var hashedBytes = sha.ComputeHash(passwordBytes);

            SignUp(username, hashedBytes);
        }

        private Boolean SignUp(String username, byte[] password)
        {
            return Procedure("proc_SignUpUser")
            .Params(
               new SqlParameter("@Username", username),
               new SqlParameter("@Password", password)
            ).Execute<Boolean>();
        }
    }
}
