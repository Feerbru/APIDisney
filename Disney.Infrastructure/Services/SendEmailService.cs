using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Disney.Core.DTOs.UserDto;
using Disney.Core.Entities;
using Disney.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Disney.Infrastructure.Services
{
    public class SendEmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;

        public SendEmailService(IConfiguration configuration, IHttpContextAccessor accessor)
        {
            _configuration = configuration;
            _accessor = accessor;
        }

        public string GenerateToken()
        {
            using (RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[8];
                cryptRNG.GetBytes(tokenBuffer);
                return Convert.ToBase64String(tokenBuffer);
            }   
        }
        
        public async Task CreatedAccountEmail(UserDto userDto)
        {
            EmailInfo emailuser = new EmailInfo();
            emailuser.Receiver = userDto.Email;
            
            var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailuser.Sender);
            var to = new EmailAddress(emailuser.Receiver);
            var pwd = GenerateToken();

            var htmlContent = "";
            var textContent = ($"Tu registro en la plataforma ha sido exitoso tu usuario es {userDto.Username} y contraseña es {userDto.Password}");

            try
            {
                var message = await Task.Run(() => MailHelper.CreateSingleEmail(from, to, emailuser.Subject, textContent, htmlContent));
                var response = await client.SendEmailAsync(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}