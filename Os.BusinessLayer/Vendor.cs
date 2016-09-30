using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Os.Common;

namespace Os.BusinessLayer
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends product to vendor
        /// </summary>
        /// <param name="product">What to order</param>
        /// <param name="quantity">How much to order?</param>
        /// <param name="deliverBy">When client get his order</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product,int quantity, DateTimeOffset? deliverBy )
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));//"product" before c# 6
            if (quantity <= 0)
                throw new ArgumentNullException(nameof(quantity));

            var success = false;

            var orderText = "Order from OsCom" + Environment.NewLine +
                            "Product: " + product.ProductCode + Environment.NewLine +
                            "Quantity: " + quantity;

            if (deliverBy.HasValue)
            {
                orderText += System.Environment.NewLine +
                            "Deliver By: " + deliverBy.Value.ToString("d");
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText,
                                                                     this.Email);
            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }
            var operationResult = new OperationResult(success,orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends product to vendor
        /// </summary>
        /// <param name="product">What to order</param>
        /// <param name="quantity">How much to order?</param>
        /// <param name="deliverBy">When client get his order</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity,
            DateTimeOffset? deliverBy, string instructions)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));//"product" before c# 6
            if (quantity <= 0)
                throw new ArgumentNullException(nameof(quantity));

            var success = false;

            var orderText = "Order from OsCom" + Environment.NewLine +
                            "Product: " + product.ProductCode + Environment.NewLine +
                            "Quantity: " + quantity;

            if (deliverBy.HasValue)
            {
                orderText += System.Environment.NewLine +
                            "Deliver By: " + deliverBy.Value.ToString("d");
            }
            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderText += System.Environment.NewLine +
                            "Instructions: " + instructions;
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText,
                                                                     this.Email);
            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }
            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }
        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message,
                                                        this.Email);
            return confirmation;
        }
    }
}
