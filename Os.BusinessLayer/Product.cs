using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Os.Common;
using static Os.Common.LoggingService;

namespace Os.BusinessLayer
{
    /// <summary>
    /// Manages products
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 
        /// </summary>
        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance was created.");
            //always create Vendor object with product object
            //this.productVendor =new Vendor();
        }

        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("Product with " + productName + " name was created.");
        }
        #endregion


        #region Properties
        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }



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


        private Vendor productVendor;

        //create Vendor object sometimes,i.e. when it requested (Lazy loading)
        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }
        #endregion

        public string PrintProduct()
        {
            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product",
                this.ProductName, "sales@abc.com");

            var result = LogAction("Print Product");

            return "It's " + productName + " (" + productId + "): " + description + 
                " Available on: " + availabilityDate?.ToShortDateString();
        }

    }
}
