using Newtonsoft.Json;

namespace ThermalModelServer.External
{
    public class DataExternal
    {
        [JsonProperty("piid")]
        public Guid PiId { get; set; }
        [JsonProperty("datas")]
        public DataObj[] Datas { get; set; }
    }

    public class DataObj
    {
        [JsonProperty("connecionnumber")]
        public int ConnectionNumber { get; set; }
        [JsonProperty("data")]
        public string[] Data { get; set; }
        [JsonProperty("datetime")]
        public DateTime DateTime { get; set; }

    }
}
