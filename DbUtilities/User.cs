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
        public User()
        {
            //
        }

        public Int32 UserID;
        public String Username;
        public void LoginUser(String username, String password, out Boolean isAuth)
        {
            var dbUserPassword = GetPasswordbByUsername(username);
            if (!String.IsNullOrEmpty(dbUserPassword))
            {
                if (VerifiedPassword(dbUserPassword, password))
                {
                    using (var userDataReader = GetUserbByUsername(username))
                    {
                        while (userDataReader.Read())
                        {
                            Username = userDataReader.GetValue("UserName").ToString();
                            UserID = Convert.ToInt32(userDataReader.GetValue("UserID").ToString());
                        }
                    }
                }
            }
            isAuth = true;
        }

        private SqlDataReader GetUserbByUsername(string username)
        {
            return Procedure("proc_GetUserDataByUsername").Execute<SqlDataReader>();
        }

        private String GetPasswordbByUsername(String username)
        {
            var userReader = Procedure("proc_GetPasswordbByUsername")
            .Params(
               new SqlParameter("@Username", username)
            ).Execute<DataTable>();

            var rows = userReader.Select();

            return rows.Length > 0 ?
                rows[0]["Password"].ToString()
                : String.Empty;
        }
        public void SignUpUser(String username, String password, out Boolean signedUp)
        {
            var passwordBytes = Encoding.ASCII.GetBytes(password);
            var sha = new SHA1CryptoServiceProvider();
            var hashedBytes = sha.ComputeHash(passwordBytes);

            signedUp = SignUp(username, hashedBytes);
        }

        private Boolean SignUp(String username, byte[] password)
        {
            return Procedure("proc_SignUpUser")
            .Params(
               new SqlParameter("@Username", username),
               new SqlParameter("@Password", password)
            ).Execute<Boolean>();
        }
        private Boolean VerifiedPassword(String dbPassword, String enteredPassword)
        {
            // yet to debug 
            var sha = new SHA1CryptoServiceProvider();
            var saltBytes = Encoding.ASCII.GetBytes(enteredPassword);
            return sha.ComputeHash(saltBytes).Equals(dbPassword);
        }
    }
}
