using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace OT.ProjectEaton.Common
{
    public class DeviceMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("DeviceId")]
        public Guid DeviceId { get; set; }

        [BsonElement("SensorDatas")]
        public List<SensorData> SensorDatas { get; set; }

        public DeviceMessage(Guid deviceId, List<SensorData> sensorDatas)
        {
            DeviceId = deviceId;
            SensorDatas = sensorDatas;
        }
    }
}
