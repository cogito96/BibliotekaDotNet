using BibiotekaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BibiotekaNet.Biznesowa_Warstwa
{
    public class DodatkiBL
    {

        public void WyślijWiadomosc(string topicMessage, string messageMessage)
        {
            var message = new MailMessage();
            message.From = new MailAddress("projektmvc2018@gmail.com", "Adres od");               /////////////  tu bedzie adress osoby ktora aktualnie jest zalogowana
            message.To.Add(new MailAddress("bujnolukasz@gmail.com"));

            message.Subject = topicMessage;
            message.Body = messageMessage;

            var smtp = new SmtpClient("smtp.gmail.com");

            var Credentials = new NetworkCredential
            {
                UserName = "projektmvc2018@gmail.com",
                Password = "qwopasklzxnm"
            };
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = Credentials;
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(message);
        }

        public bool isValid(string topic, string messanger)
        {
            if(string.IsNullOrEmpty(topic) || string.IsNullOrEmpty(messanger))
            {
                return false;
            }
            return true;
        }
    }
}