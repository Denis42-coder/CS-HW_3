using Limilabs.Client.SMTP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmailSendExample
{
    public static class WpfTestMailSender
    {
        public static string YourMail = "d.iuj@yandex.ru";
        public static string YourName = "Denis";
        public static string MyHost = "smtp.yandex.ru";
        public static int MyPort = 465;
        public static string fromPassword = System.IO.File.ReadAllText("C:\\1.txt");
        public static string subject = "Тема письма";
    }

    public class EmailSendServiceClass()
    {   
        

        var fromAddress = new MailAddress(WpfTestMailSender.YourMail, WpfTestMailSender.YourName);       
        var smtp = new SmtpClient
        {
            Host = WpfTestMailSender.MyHost,
            Port = WpfTestMailSender.MyPort,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(WpfTestMailSender.YourMail, WpfTestMailSender.fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            Smtp.Send(message);
        }
            MessageBox.Show("Message has sent");

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            Console.WriteLine(ex);
        }
    }
}
