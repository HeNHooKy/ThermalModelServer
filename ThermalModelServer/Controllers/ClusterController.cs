using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThermalModelServer.External;
using ThermalModelServer.Model;

namespace ThermalModelServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClusterController : ControllerBase
    {
        private readonly Context _context;

        public ClusterController
            (Context context)
        {
            _context = context;
        }

        [HttpPost()]
        public ActionResult Post(ClusterExternal extcluster)
        {
            var cluster = _context.Clusters
                .FirstOrDefault(c => c.Id == extcluster.Id);

            if(cluster == null)
            {
                return BadRequest();
            }

            cluster.Name = extcluster.Name;

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var clusters = _context.Clusters
                .Select(c => new Cluster
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return Ok(clusters);
        }
    }
}
