using System;

namespace Services
{
    public class PrinterService
    {
        private readonly EmailService email;
        private readonly TokenService token;

        public PrinterService(EmailService email, TokenService token)
        {
            this.email = email;
            this.token = token;
        }

        public void PrintAll()
        {
            Console.WriteLine($"Start from {typeof(PrinterService)}");
            token.PrintToken();
            email.PrintEmail();
            Console.WriteLine($"End from {typeof(PrinterService)}");
        }

    }
}