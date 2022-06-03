using Newtonsoft.Json;

namespace ThermalModelServer.External
{
    public class ClusterExternal
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("blocks")]
        public IEnumerable<BlockExternal> blocks { get; set; }
    }
}
