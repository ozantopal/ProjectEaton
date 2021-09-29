using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.ProjectEaton.Common.Services
{
    public interface IMessageQueueService
    {
        IConnection GetRabbitMQConnection();
    }
}
