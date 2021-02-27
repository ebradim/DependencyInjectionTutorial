using System;

namespace Services
{
    public class EmailService
    {
        int rand;
        private readonly TokenService token;
        public EmailService(TokenService token)
        {
            this.token = token;
            rand = new Random().Next(0, 250);
        }

        public void PrintEmail()
        {
            Console.WriteLine($"{typeof(EmailService)} is printing your email: {rand}@test.com, with token: {token.GetToken()}");
        }

    }
}