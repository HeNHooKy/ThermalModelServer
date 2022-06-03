using Newtonsoft.Json;

namespace ThermalModelServer.Model
{
    public class Data
    {
        public Guid SensorId { get; set; }
        public DateTime CheckDate { get; set; }
        public string Value { get; set; }
        public Sensor Sensor { get; set; }
    }
}
