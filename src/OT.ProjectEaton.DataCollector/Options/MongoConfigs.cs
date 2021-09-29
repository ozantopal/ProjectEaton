using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.ProjectEaton.DataCollector.Options
{
    public class MongoConfigs
    {
        public string ConnectionString { get; } = "mongodb://localhost:27017";
        public string DbName { get; } = "DeviceMessageDB";
        public string CollectionName { get; } = "DeviceMessages";
    }
}
