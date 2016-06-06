using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Os.BusinessLayer
{
    /// <summary>
    /// Manages products
    /// </summary>
    public class Product
    {
        private string productName;
        
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string PrintProduct()
        {
            return "It's " + productName + " (" + productId + "): " + description;
        }

    }
}
