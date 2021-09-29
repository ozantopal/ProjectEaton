using MongoDB.Bson.Serialization.Attributes;

namespace OT.ProjectEaton.Common
{
    public class SensorData
    {
        [BsonElement("SensorType")]
        public SensorType SensorType { get; set; }

        [BsonElement("Value")]
        public int Value { get; set; }

        public SensorData(SensorType sensorType, int value)
        {
            SensorType = sensorType;
            Value = value;
        }
    }
}