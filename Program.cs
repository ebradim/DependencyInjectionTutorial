

namespace DependencyInjectionTutorial
{
    using System;
    using CustomDependencyInjection;
    using Services;

    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceContainer();
            container.AddSingleton<TokenService>();
            container.AddScoped<PrinterService>();
            container.AddSingleton<EmailService>();
            var provider = new ServiceProvider(container);
            var print1 = provider.GetService<PrinterService>();
            print1.PrintAll();
            var print2 = provider.GetService<PrinterService>();
            print2.PrintAll();

        }
    }
}
