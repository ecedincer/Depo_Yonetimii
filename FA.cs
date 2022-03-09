using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DepoYonetimi
{
    public class FA
    {


        static MailMessage mail;
        SmtpClient smtp;
        static Random rnd=new Random();
        static string onaykodu;

        public string dkod(string kmail)
        {
            onaykodu = rnd.Next(10) + rnd.Next(10) + rnd.Next(10) + rnd.Next(10) + rnd.Next(10).ToString();
            //mail = new MailMessage("depo.yonetimi@outlook.com",kmail,"Doğrulama Kodu","Doğrulama Kodunuz : "+onaykodu);
            //SmtpClient smtp = new SmtpClient("smtp.live.com",587);
            //smtp.EnableSsl = true;
            //smtp.Credentials = new NetworkCredential("depo.yonetimi@outlook.com", "depoyonetimi1");
            //smtp.Send(mail);

            //mail = new MailMessage();
            //smtp = new SmtpClient();
            //smtp.Credentials = new NetworkCredential("depo.yonetimi@outlook.com", "depoyonetimi1");
            //smtp.Port = 587;
            //smtp.Host = "smtp.live.com";
            //smtp.EnableSsl = true;
            //mail.To.Add(kmail.ToString());
            //mail.From = new MailAddress("depo.yonetimi@outlook.com");
            //mail.Subject = 
            //mail.Body = 
            //smtp.Send(mail);

            
            string from = "depo.yonetimi.mail@gmail.com"; //From address
            MailMessage message = new MailMessage(from, kmail);

            string mailbody = "Doğrulama Kodunuz : " + onaykodu; ;
            message.Subject = "Doğrulama Kodu"; 
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp
            NetworkCredential basicCredential1 = new
            NetworkCredential("depo.yonetimi.mail@gmail.com", "depoyonetimi1");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return onaykodu;





        }


    }
}