using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Data.Repertorio;
using NetCoreAPIMySQL.Model;

namespace BackEND_Sensor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IsensorRepo _sensorRepository;

        public SensorController(IsensorRepo sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSensoData()
        {
            return Ok(await _sensorRepository.GetAllDataSensor());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSensoData(int id)
        {
            return Ok(await _sensorRepository.GetDataSensorDetails(id));

        }

        [HttpPost]
        public async Task<IActionResult> CreateDataSensor([FromBody]DataSensor DataSensor)
        {
            if (DataSensor == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created=await _sensorRepository.InsertDataSensor(DataSensor);

            return Created("created", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDataSensor([FromBody] DataSensor DataSensor)
        {
            if (DataSensor == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

             await _sensorRepository.UpdateDataSensor(DataSensor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleDataSensor(int id)
        {
            
            await _sensorRepository.DeleteDataSensor(new DataSensor() { Id=id});

            return NoContent();
        }


    }
}
