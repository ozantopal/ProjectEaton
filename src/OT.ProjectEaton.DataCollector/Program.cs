using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OT.ProjectEaton.Common.Services;
using OT.ProjectEaton.DataCollector.Options;
using System;
using System.IO;

namespace OT.ProjectEaton.DataCollector
{
    class Program
    {
        private static MongoConfigs MongoConfigs;
        private static RabbitMqConfigs RabbitMqConfigs;
        static void Main(string[] args)
        {
            MongoConfigs = new MongoConfigs();
            RabbitMqConfigs = new RabbitMqConfigs();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<IDeviceMessageService>(s =>
                    new DeviceMessageService(MongoConfigs.ConnectionString, MongoConfigs.DbName, MongoConfigs.CollectionName));

                services.AddTransient<IMessageQueueService>(s =>
                    new MessageQueueService(RabbitMqConfigs.HostName, RabbitMqConfigs.UserName, RabbitMqConfigs.Password));
                
                services.AddHostedService<Services.DataCollectorService>();
            });
    }
}
