using FinalProject.DTO;
using FinalProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorridorController : ControllerBase
    {
        private readonly ICorridorFunction corridorFunction;

        public CorridorController(ICorridorFunction _corridorFunction)
        {
            this.corridorFunction = _corridorFunction;
        }
        // GET: api/<LandmarkController>
        [HttpGet]
        public ActionResult<List<Corridor>> Get()
        {
            return corridorFunction.Get();
        }

        // GET api/<LandmarkController>/5
        [HttpGet("{id}")]
        public ActionResult<Corridor> Get(string id)
        {
            var corridor = corridorFunction.Get(id);
            if (corridor == null)
            {
                return NotFound($"corridor with id = {id} not found");
            }
            return corridor;
        }

        // POST api/<LandmarkController>
        [HttpPost]
        public ActionResult<Corridor> Post([FromBody] Corridor corridor)
        {

            corridorFunction.Create(corridor);
            return CreatedAtAction(nameof(Get), new { id = corridor.CorridorId }, corridor);

        }

        // PUT api/<LandmarkController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Corridor corridor)
        {
            var existingCorridor = corridorFunction.Get(id);
            if (existingCorridor == null)
            {
                return NotFound($"corridor with id = {id} not found");
            }
            corridorFunction.Update(id, corridor);
            return NoContent();
        }

        // DELETE api/<LandmarkController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var corridor = corridorFunction.Get(id);
            if (corridor == null)
            {
                return NotFound($"corridor with id = {id} not found");
            }
            corridorFunction.Remove(corridor.CorridorId);
            return Ok($"corridor with id = {id} deleted");
        }
    }
}
