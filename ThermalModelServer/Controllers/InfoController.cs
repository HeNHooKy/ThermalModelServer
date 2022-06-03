using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThermalModelServer.External;

namespace ThermalModelServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly Context _context;

        public InfoController
            (Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var clusters = _context.Clusters
                .Include(c => c.Blocks)
                .ThenInclude(b => b.Sensors);

            var extclusters = clusters.Select(c => new ClusterExternal
                {
                    Id = c.Id,
                    Name = c.Name,
                    blocks = c.Blocks.Select(b => new BlockExternal
                    {
                        Id = b.Id,
                        Name = b.Name,
                        ClusterId = b.ClusterId,
                        Number = b.Number,
                        Sensors = b.Sensors.Select(s => new SensorExternal
                        {
                            Id = s.Id,
                            BlockId = s.BlockId,
                            Number = s.Number,
                            LastCheck = s.LastCheck,
                            LastValue = s.LastValue,
                            Name = s.Name,
                            CoordX = s.CoordX,
                            CoordY = s.CoordY,
                            CoordZ = s.CoordZ
                        })
                    })
                });

            return Ok(extclusters);
        }
    }
}
