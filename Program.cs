using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("From Message:  ");
            string from = Console.ReadLine();
            Console.Write("To Message :   ");
            string to = Console.ReadLine();
            Console.Write("Subject :      ");
            string sub = Console.ReadLine();
            Console.Write("Body :         ");
            string body = Console.ReadLine();



            try
            {
                for (int i = 1; i < 5; i++)
                {
                    string subject = sub + "  " + i.ToString();



                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("decepticon567@gmail.com", "a2m6i4o6");

                    MailMessage msg = new MailMessage();
                    msg.To.Add(to);
                    msg.From = new MailAddress(from);
                    msg.Subject = subject;
                    msg.Body = body;

                    client.Send(msg);
                    Console.WriteLine($"{i} Message Sent");
                }
                Console.WriteLine("All Message Sent Successfully....");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
