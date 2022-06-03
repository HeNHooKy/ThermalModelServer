using Newtonsoft.Json;

namespace ThermalModelServer.Model
{
    public class Block
    {
        public Guid Id { get; set; }
        public Guid ClusterId { get; set; }
        public int Number { get; set; }
        public string? Name { get; set; }
        public Cluster Cluster { get; set; }
        public IEnumerable<Sensor> Sensors { get; set; }
    }
}
