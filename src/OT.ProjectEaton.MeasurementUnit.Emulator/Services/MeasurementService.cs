using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OT.ProjectEaton.Common;
using OT.ProjectEaton.Common.Services;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace OT.ProjectEaton.MeasurementUnit.Emulator.Services
{
    public class MeasurementService : IHostedService
    {
        private const int SENSOR_READ_PERIOD_IN_MINS = 5;
        private const string QUEUE_NAME = "messages";
        private Guid[] deviceIds = new Guid[] {
            Guid.Parse("c7a93f90-59cb-45a6-b381-5b6391cfd2dd"),
            Guid.Parse("74ae1f73-f801-4ddf-b682-7a385af1d78a")};
        private Timer timer;
        private IMessageQueueService messageQueueService;

        public MeasurementService(IMessageQueueService messageQueueService)
        {
            this.messageQueueService = messageQueueService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(GetDeviceData, 
                state: null, 
                dueTime: TimeSpan.Zero, 
                period: TimeSpan.FromSeconds(SENSOR_READ_PERIOD_IN_MINS));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void GetDeviceData(object state)
        {
            Console.WriteLine($"Service start to work at: {DateTime.Now}");

            using (IConnection connection = messageQueueService.GetRabbitMQConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(QUEUE_NAME,
                    durable: false, 
                    exclusive: false, 
                    autoDelete: false, 
                    arguments: null);

                foreach (var deviceId in deviceIds)
                {
                    var message = JsonConvert.SerializeObject(new DeviceMessage(deviceId, GetRandomSensorData()));
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: QUEUE_NAME,
                        basicProperties: null,
                        body: body);
                }
            }
        }

        /// <summary>
        /// Generates random data for all 3 type of sensor.
        /// The numbers used to generate random values are 
        /// choosen based on the specifications stated in the documentation.
        /// </summary>
        /// <returns></returns>
        private List<SensorData> GetRandomSensorData()
        {
            var random = new Random();
            var result = new List<SensorData>
            {
                new SensorData(SensorType.Temperature, random.Next(-20, 41)),
                new SensorData(SensorType.Humidity, random.Next(0, 101)),
                new SensorData(SensorType.WindSpeed, random.Next(0, 51))
            };

            return result;
        }
    }
}
