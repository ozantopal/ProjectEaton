using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OT.ProjectEaton.Common;
using OT.ProjectEaton.Common.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OT.ProjectEaton.DataCollector.Services
{
    public class DataCollectorService : IHostedService
    {
        private IMessageQueueService messageQueueService;
        private IDeviceMessageService deviceMessageService;
        private const string QUEUE_NAME = "messages";

        public DataCollectorService(IDeviceMessageService deviceMessageService, IMessageQueueService messageQueueService)
        {
            this.deviceMessageService = deviceMessageService;
            this.messageQueueService = messageQueueService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var connection = messageQueueService.GetRabbitMQConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var deviceMessage = JsonConvert.DeserializeObject<DeviceMessage>(message);

                    await deviceMessageService.Create(deviceMessage);
                };

                channel.BasicConsume(queue: QUEUE_NAME,
                    autoAck: false,
                    consumer: consumer);

                Console.ReadLine();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
