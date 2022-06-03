using Newtonsoft.Json;

namespace ThermalModelServer.Model
{
    public class Sensor
    {
        public Guid Id { get; set; }
        public Guid BlockId { get; set; }
        public int Number { get; set; }
        public DateTime? LastCheck { get; set; }
        public string? LastValue { get; set; }
        public string? Name { get; set; }
        public string? CoordX { get; set; }
        public string? CoordY { get; set; }
        public string? CoordZ { get; set; }
        public Block Block { get; set; }
        public IEnumerable<Data> Datas { get; set; }
    }
}
