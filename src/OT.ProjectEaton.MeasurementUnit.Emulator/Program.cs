using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OT.ProjectEaton.Common.Services;
using OT.ProjectEaton.MeasurementUnit.Emulator.Options;
using System;

namespace OT.ProjectEaton.MeasurementUnit.Emulator
{
    class Program
    {
        private static RabbitMqConfigs RabbitMqConfigs;

        static void Main(string[] args)
        {
            RabbitMqConfigs = new RabbitMqConfigs();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<IMessageQueueService>(s =>
                    new MessageQueueService(RabbitMqConfigs.HostName, RabbitMqConfigs.UserName, RabbitMqConfigs.Password));

                services.AddHostedService<Services.MeasurementService>();
            });
    }
}
