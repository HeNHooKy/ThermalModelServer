using Newtonsoft.Json;

namespace ThermalModelServer.External
{
    public class BlockExternal
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("clusterId")]
        public Guid ClusterId { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("sensors")]
        public IEnumerable<SensorExternal> Sensors { get; set; }
    }
}
