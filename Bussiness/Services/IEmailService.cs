using DTO.EmailDTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public interface IEmailService
    {
        public void SendOrderEmailToCustomer(OrderEmailDTO orderEmailDTO, AppUser appUser);

        public void SendOrderEmailToAdmin(AppUser appUser);

        public void ForgetPasswordEmail(AppUser appUser);

        public void SendActivateAccountCode(AppUser appUser);
    }
}
