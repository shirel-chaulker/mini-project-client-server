using System;
using ProductServer.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServer.Dal
{
    public class SqlQuery
    {

        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\SQLEXPRESS";

        SqlConnection connection;
        public SqlQuery()
        {
            connection = new SqlConnection(connectionString);
        }

        public bool Connect()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {

                return false;
            }
        }

        public delegate void SetDataReader_delegate(SqlDataReader reader);
        public delegate void pustDataReader_delegate(UserComment userComment, SqlCommand command);
        public delegate void deleteproduct_delegate(SqlCommand command, int? productId);
        public delegate void UpdateProduct_delegate(SqlCommand command, Product product);
        public void runCommand(string sqlQuerey, SetDataReader_delegate func)
        {
            if (!Connect()) return;


            string insert = sqlQuerey;

            using (SqlCommand command = new SqlCommand(insert, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        func(reader);
                    }
                }
            }
        }

        public void RunAddUserComment(string sqlQuerey, pustDataReader_delegate func, UserComment userComment)
        {
            if (!Connect()) return;
            string insert = sqlQuerey;
            ;
            using (SqlCommand command = new SqlCommand(insert, connection))
            {
                func(userComment, command);

            }

        }
        public void RunDeleteProduct(string sqlQuerey, deleteproduct_delegate func, int productId)
        {
            if (!Connect()) return;
            string insert = sqlQuerey;
            ;
            using (SqlCommand command = new SqlCommand(insert, connection))
            {
                func(command, productId);

            }

        }
        public void RunUpdateProduct(string sqlQuerey, UpdateProduct_delegate func, Product product)
        {
            if (!Connect()) return;
            string insert = sqlQuerey;

            using (SqlCommand command = new SqlCommand(insert, connection))
            {
                func(command, product);

            }

        }

    }
}

