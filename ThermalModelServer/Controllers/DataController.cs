using Microsoft.AspNetCore.Mvc;
using ThermalModelServer.External;
using ThermalModelServer.Model;

namespace ThermalModelServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly Context _context;

        public DataController
            (Context context)
        {
            _context = context;
        }

        [HttpGet("{sensorId}")]
        public ActionResult Get(Guid sensorId)
        {
            var datas = _context.Datas
                .Select(d => new DataObjExternal
                {
                    SensorId = d.SensorId,
                    CheckDate = d.CheckDate,
                    Value = d.Value
                })
                .FirstOrDefault(d => d.SensorId == sensorId);

            return Ok(datas);
        }
    }
}