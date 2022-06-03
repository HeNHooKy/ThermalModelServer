using Newtonsoft.Json;

namespace ThermalModelServer.Model
{
    public class Cluster
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public IEnumerable<Block> Blocks { get; set; }
    }
}
