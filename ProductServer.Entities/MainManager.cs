using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductServer.Model;

namespace ProductServer.Entities
{
    public class MainManager
    {
        private MainManager() { }
        private readonly static MainManager _instance = new MainManager();
        public static MainManager INSTANCE
        {
            get { return _instance; }
        }

        public List<Product> Init()
        {

            Products products = new Products();
            return products.getProducts();
        }

        public void pustUsersComment(UserComment userComment)
        {

            UsersComments usersComments = new UsersComments();
            usersComments.pustUsersComments(userComment);

        }
        public void ProductsRemove(string productID)
        {
            Products products = new Products();

            products.RemoveProduct(productID);


        }
        public void ProductsUpdate(ProductTemp productTemp)
        {
            Products products = new Products();

            products.UpdateProduct1(productTemp);

        }
    }
}
