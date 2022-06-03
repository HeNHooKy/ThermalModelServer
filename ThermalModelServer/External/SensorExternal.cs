using Newtonsoft.Json;

namespace ThermalModelServer.External
{
    public class SensorExternal
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("blockId")]
        public Guid BlockId { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("lastCheck")]
        public DateTime? LastCheck { get; set; }
        [JsonProperty("lastValue")]
        public string? LastValue { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("coordX")]
        public string? CoordX { get; set; }
        [JsonProperty("coordY")]
        public string? CoordY { get; set; }
        [JsonProperty("coordZ")]
        public string? CoordZ { get; set; }
    }
}
