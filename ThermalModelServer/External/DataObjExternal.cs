using Newtonsoft.Json;

namespace ThermalModelServer.External
{
    public class DataObjExternal
    {
        [JsonProperty("sensorId")]
        public Guid SensorId { get; set; }
        [JsonProperty("checkDate")]
        public DateTime CheckDate { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
