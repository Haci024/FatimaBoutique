using Bussiness.Services;
using DAL.DbConnection;
using DTO.ContactUsDTO;
using DTO.EmailDTO;
using Entity.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace Bussiness.Manager
{
    public class EmailManager : IEmailService
    {

        private readonly Context _db;

        public EmailManager(Context context)
        {
            _db = context;

        }
      
        public void ForgetPasswordEmail(AppUser appUser)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress(appUser.UserName, "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("FatimahBoutiqueForgetPassword", appUser.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Hörmətli {appUser.UserName} yeni şifrə yaratmaq üçün bu təsdiq şifrəniz :{appUser.ForgetPasswordCode}";

            mimeMessage.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "voxryimidhytyjot");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void SendActivateAccountCode(AppUser appUser)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress(appUser.UserName, "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Hesab aktivləşdirmə", appUser.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            
            bodyBuilder.TextBody = "Hesabınızı aktivləşdirmək üçün bu kodunuz:" + " " + appUser.ConfirmationCode;

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("odisseybanks024@gmail.com", "voxryimidhytyjot");

                client.Send(mimeMessage);
            }

        }

        public void SendOrderEmailToAdmin(AppUser appUser)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress(appUser.UserName, "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Yeni Sifariş", appUser.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Yeni sifarişiniz var!";

            mimeMessage.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "voxryimidhytyjot");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void SendOrderEmailToCustomer(OrderEmailDTO orderEmailDTO, AppUser appUser)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress("Hörmətli"+ appUser.UserName, "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Sifariş", appUser.Email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Sifarişiniz qeydə alındı. Ən qısa zamanda sizinlə əlaqə saxlanılacaq.Əgər sizə geri dönüş edilməsə bizimlə əlaqə səhifəsindən bizə müraciət edə bilərsiniz! Sifari {orderEmailDTO.OrderDate}";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Sifariş";

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "voxryimidhytyjot");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
        public void NewSubscriberMail(string email)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress("Abunəlik", "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Fatimah-Boutique", email);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Abunəliyiniz uğurla tamamlandı.Ən son yeniliklərdən anında xəbəriniz olacaq ,hörmətlə Fatimah-Boutique:)";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Yeni Abunə";

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "voxryimidhytyjot");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void ContactUsAvtoMessageForUser(AddContactUsDTO contactUsDTO)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress("Bizimlə əlaqə", "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Fatimah-Boutique", contactUsDTO.Gmail);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = $"Hörmətli {contactUsDTO.FullName} , müraciətiniz qeydə alındı .Ən qısa zamanda müraciətiniz cavablandırılacaq,hörmətlə Fatimah-Boutique:)";

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject =contactUsDTO.Title;

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "voxryimidhytyjot");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void ReplyMessageToCustomer(ReplyMessageDTO dto)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress ConfirmAddressFrom = new MailboxAddress(dto.Title, "odisseybanks024@gmail.com");
            MailboxAddress ConfirmAdressTo = new MailboxAddress("Fatimah-Boutique", dto.Gmail);

            mimeMessage.From.Add(ConfirmAddressFrom);
            mimeMessage.To.Add(ConfirmAdressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = dto.Description;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = dto.Title;

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("odisseybanks024@gmail.com", "voxryimidhytyjot");
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
