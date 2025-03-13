using FluentEmail.Core;

namespace Biblioteca.Services
{
    public class EmailServices
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailServices(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }


        public async Task<bool> SendEmailAsync(string Title)
        {
            var result = await _fluentEmail.To("mario.rossi@email.com").Subject("Hai preso in prestito un nuovo libro").Body($"nuovo libro: {Title}").SendAsync();


            return result.Successful;
           
        }
    }
}
