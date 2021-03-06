﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace USIS
{
    public class Helpers
    {
        public static void SendEmail(string receiverEmail, string receiverName, string subject, string message)
        {
            try
            {
                Thread emailThread = new Thread(delegate ()
                {
                    var sender = new MailAddress("tugrulmailtest1@gmail.com", "USIS");
                    var password = "123Aa_456";

                    var receiver = new MailAddress(receiverEmail, receiverName);

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(sender.Address, password)
                    };
                    var mailMessage = new MailMessage(sender, receiver)
                    {
                        Subject = subject,
                        Body = message
                    };
                    smtp.Send(mailMessage);
                });
                emailThread.IsBackground = true;
                emailThread.Start();
            }
            catch
            {

            }
        }
    }
}