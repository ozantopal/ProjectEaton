using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.ProjectEaton.Common.Services
{
    public class DeviceMessageService : IDeviceMessageService
    {
        private readonly IMongoCollection<DeviceMessage> messages;

        public DeviceMessageService(string connStr, string dbName, string collectionName)
        {
            var client = new MongoClient(connStr);
            var db = client.GetDatabase(dbName);

            messages = db.GetCollection<DeviceMessage>(collectionName);
        }

        public async Task<List<DeviceMessage>> Get()
        {
            return await messages.Find(dm => true).ToListAsync();
        }

        public async Task<DeviceMessage> Create(DeviceMessage dm)
        {
            await messages.InsertOneAsync(dm);
            return dm;
        }
    }
}
