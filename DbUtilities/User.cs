using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoffeeManagement.DbUtilities;

namespace CoffeeManagement.DbUtilities
{
    public class User : Database
    {
        public Int32 UserID;
        public String Username;
        public User(String username, String password)
        {
            using (var userDataReader = GetUserbByUsernameAndPassword(username, password)) 
            {
                UserID = Convert.ToInt32(userDataReader.GetValue("UserID").ToString());
                Username = userDataReader.GetValue("UserName").ToString();
            }
        }

        public SqlDataReader GetUserbByUsernameAndPassword(String username, String password) 
        {
            return Procedure("proc_GetUserByUsernameAndPassword")
            .Params(
               new SqlParameter("@Username", SqlDbType.NVarChar),
               new SqlParameter("@Password", SqlDbType.NVarChar)
            ).Execute<SqlDataReader>();
        }
    }
}
