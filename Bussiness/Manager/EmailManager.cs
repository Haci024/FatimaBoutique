using Bussiness.Services;
using DAL.DbConnection;
using DTO.EmailDTO;
using Entity.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Manager
{
    public class EmailManager : IEmailService
    {
        
        private readonly Context _db;

        public EmailManager(Context context)
        {
            _db = context;
            
        }

        public void ForgetPasswordEmail(AppUser appUser,string Email, int accessCode)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress(appUser.FullName, "example@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Yeni Sifariş", appUser.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Təsdiq şifrəniz :{accessCode}";

            mimeMessage.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();

            //client.Connect("smtp.gmail.com", 587, false);
            //client.Authenticate("example@gmail.com", "voxryimidhytyjot");
            //client.Send(mimeMessage);
            //client.Disconnect(true);
        }

        public void SendOrderEmailToAdmin(AppUser appUser)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress(appUser.FullName, "example@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Yeni Sifariş", appUser.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Yeni sifarişiniz var!";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            

            SmtpClient client = new SmtpClient();

            //client.Connect("smtp.gmail.com", 587, false);
            //client.Authenticate("example@gmail.com", "voxryimidhytyjot");
            //client.Send(mimeMessage);
            //client.Disconnect(true);
        }

        public void SendOrderEmailToCustomer(OrderEmailDTO orderEmailDTO,AppUser appUser)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress("Hörmətli" + " " + appUser.FullName, "example@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Sifariş", appUser.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Sifarişiniz qeydə alıdı.Ən qısa zamanda sizinlə əlaqə saxlanılacaq.Əgər sizə geri dönüş edilməsə bizimlə əlaqə səhifəsindən bizə müraciət edə bilərsiniz! Sifari {orderEmailDTO.OrderDate}";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject ="Sifariş";

            SmtpClient client = new SmtpClient();

            //client.Connect("smtp.gmail.com", 587, false);
            //client.Authenticate("example@gmail.com", "voxryimidhytyjot");
            //client.Send(mimeMessage);
            //client.Disconnect(true);
        }
    }
}
