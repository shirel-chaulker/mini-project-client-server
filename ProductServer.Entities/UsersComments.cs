using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductServer.Dal;
using ProductServer.Model;

namespace ProductServer.Entities
{
    public class UsersComments
    {
        public UsersComments() { }
        public List<Product> ProductList { get; set; }
        Product product;

        public void addUserComments(UserComment userComment, System.Data.SqlClient.SqlCommand command)
        {
            command.Parameters.AddWithValue("@FirstName", userComment.FirstName);
            command.Parameters.AddWithValue("@LastName", userComment.LastName);
            command.Parameters.AddWithValue("@Username", userComment.Username);
            command.Parameters.AddWithValue("@EmailAddress", userComment.EmailAddress);
            command.Parameters.AddWithValue("@ContactUsInput", userComment.ContactUsInput);
            int rows = command.ExecuteNonQuery();
        }

        string insert = "insert into ContactUs values (@FirstName,@LastName,@Username,@EmailAddress,@ContactUsInput)";

        public void pustUsersComments(UserComment userComment)
        {
            SqlQuery sqlQuery1 = new SqlQuery();
            sqlQuery1.RunAddUserComment(insert,addUserComments,userComment);
        }
    }
}
