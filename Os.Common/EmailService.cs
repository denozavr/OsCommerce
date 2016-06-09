using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Os.Common
{
    public class EmailService
    {
        /// <summary>
        /// Send email message.
        /// </summary>
        /// <param name="subject">Subject of the message.</param>
        /// <param name="message">Message text.</param>
        /// <param name="recipient">Email address of the message recepient.</param>
        /// <returns></returns>
        public string SendMessage(string subject, string message, string recipient)
        {
            var confirmation = "Message sent" + subject;
            LoggingService.LogAction(confirmation);

            return confirmation;
        }
    }
}
