using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

namespace Web.App_Start
{
    public class IdentityConfig : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);

            //SmtpClient client = new SmtpClient();
            //return client.SendMailAsync(ConfigurationManager.AppSettings["SupportEmailAddr"],
            //                            message.Destination,
            //                            message.Subject,
            //                            message.Body);
        }
    }
}