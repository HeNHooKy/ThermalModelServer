using Microsoft.AspNetCore.Mvc;
using ThermalModelServer.External;
using ThermalModelServer.Model;

namespace ThermalModelServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly Context _context;

        public StoresController
            (Context context)
        {
            _context = context;
        }

        [HttpGet(Name = "newid")]
        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        private Cluster GetCluster(Guid clusterId)
        {
            var cluster = _context.Clusters
                .FirstOrDefault(c => c.Id == clusterId);

            if (cluster == null)
            {
                cluster = new Cluster
                {
                    Id = clusterId
                };

                _context.Clusters.Add(cluster);
                _context.SaveChanges();
            }

            return cluster;
        }

        private Block GetBlock(Guid clusterId, int number)
        {
            var block = _context.Blocks.FirstOrDefault(b
                => b.ClusterId == clusterId
                && b.Number == number);

            if(block == null)
            {
                block = new Block
                {
                    Id = Guid.NewGuid(),
                    ClusterId = clusterId,
                    Number = number
                };

                _context.Blocks.Add(block);
                _context.SaveChanges();
            }

            return block;
        }

        private Sensor GetSensor(Guid blockId, int number)
        {
            var sensor = _context.Sensors.FirstOrDefault(s
                => s.BlockId == blockId
                && s.Number == number);

            if(sensor == null)
            {
                sensor = new Sensor
                {
                    Id = Guid.NewGuid(),
                    BlockId = blockId,
                    Number = number
                };

                _context.Sensors.Add(sensor);
                _context.SaveChanges();
            }

            return sensor;
        }

        [HttpPost(Name = "data")]
        public ActionResult PostData(DataExternal datas)
        {
            var gotTime = DateTime.Now;
            var newStorageValue = new List<Data>();

            foreach(var block in datas.Datas)
            {
                for (int i = 0; i < block.Data.Length; i++)
                {
                    var payload = block.Data[i];

                    var cluster = GetCluster(datas.PiId);
                    var blockObj = GetBlock(cluster.Id, block.ConnectionNumber);
                    var sensor = GetSensor(blockObj.Id, i);

                    sensor.LastCheck = gotTime;
                    sensor.LastValue = payload;

                    var newData = new Data
                    {
                        SensorId = sensor.Id,
                        CheckDate = gotTime,
                        Value = payload
                    };
                    
                    newStorageValue.Add(newData);
                }
            }

            _context.Datas.AddRange(newStorageValue);
            _context.SaveChanges();

            return Ok();
        }
    }
}