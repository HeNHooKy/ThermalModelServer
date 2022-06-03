using Microsoft.AspNetCore.Mvc;
using ThermalModelServer.External;
using ThermalModelServer.Model;

namespace ThermalModelServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockController : ControllerBase
    {
        private readonly Context _context;

        public BlockController
            (Context context)
        {
            _context = context;
        }

        [HttpPost()]
        public ActionResult Post(BlockExternal extblock)
        {
            var block = _context.Blocks
                .FirstOrDefault(b => b.Id == extblock.Id);

            if(block == null)
            {
                return BadRequest();
            }

            block.Name = extblock.Name;

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var blocks = _context.Blocks
                .Select(b => new BlockExternal
                {
                    Id = b.Id,
                    ClusterId = b.ClusterId,
                    Number = b.Number,
                    Name = b.Name
                });
            return Ok(blocks);
        }
    }
}