using Microsoft.AspNetCore.Mvc;
using ThermalModelServer.External;
using ThermalModelServer.Model;

namespace ThermalModelServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly Context _context;

        public SensorController
            (Context context)
        {
            _context = context;
        }

        [HttpPost()]
        public ActionResult Post(SensorExternal extsensor)
        {
            var sensor = _context.Sensors
                .FirstOrDefault(s => s.Id == extsensor.Id);

            if(sensor == null)
            {
                return BadRequest();
            }

            sensor.Name = extsensor.Name;
            sensor.CoordX = extsensor.CoordX;
            sensor.CoordY = extsensor.CoordY;
            sensor.CoordZ = extsensor.CoordZ;

            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var sensors = _context.Sensors
                .Select(s => new SensorExternal
                {
                    Id = s.Id,
                    Number = s.Number,
                    LastCheck = s.LastCheck,
                    LastValue = s.LastValue,
                    Name = s.Name,
                    CoordX = s.CoordX,
                    CoordY = s.CoordY,
                    CoordZ = s.CoordZ
                });

            return Ok(sensors);
        }
    }
}