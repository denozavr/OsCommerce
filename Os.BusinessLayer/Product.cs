using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public const double InchesInMeter = 39.37;
        public readonly decimal MinPrice;

        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance was created.");
            //always create Vendor object with product object
            //this.productVendor =new Vendor();
            this.MinPrice = .96m;
            this.Category = "Home";
        }

        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (productName.StartsWith("Bulk"))
            {
                this.MinPrice = 9.99m;
            }
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

        public decimal Cost { get; set; }

        private string productName;

        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ErrorMessage = "Product Name must be at least 3 characters";
                }
                else if(value.Length > 30)
                {
                    ErrorMessage = "Product Name cannot be more than 30 characters";
                }
                else
                {
                    productName = value;
                }
            }
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

        public string ErrorMessage { get; set; }
        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;
        public string ProductCode => this.Category + "-" + this.SequenceNumber;

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public decimal CalculateSuggestedPrice(decimal markupPercent) =>
             this.Cost + (this.Cost * markupPercent / 100);

        public string PrintProduct()
        {
            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product",
                this.ProductName, "sales@abc.com");

            var result = LogAction("Print Product");

            return "It's " + productName + " (" + productId + "): " + description + 
                " Available on: " + availabilityDate?.ToShortDateString();
        }

        public override string ToString()
        {
            return this.productName + "(" + productId + ")";
        }
    }
}
