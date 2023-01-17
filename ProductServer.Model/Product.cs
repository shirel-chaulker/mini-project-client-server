using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServer.Model
{
   public class Product
    {
        public Product() { }
        public string ProductName { get; set; }
        public int ProductID { get; set; }

        public SqlMoney UnitPrice { get; set; }
        public int UnitInStock { get; set; }

    }
    public class ProductTemp
    {
        public ProductTemp() { }
        public string ProductName { get; set; }
        public int ProductID { get; set; }

        public string UnitPrice { get; set; }
        public string UnitInStock { get; set; }
    }
}
