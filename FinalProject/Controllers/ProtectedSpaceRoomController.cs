using FinalProject.DTO;
using FinalProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedSpaceRoomController : ControllerBase
    {
        private readonly IPsrFunction psrFunction;

        public ProtectedSpaceRoomController(IPsrFunction _psrFunction)
        {
            this.psrFunction = _psrFunction;
        }
        // GET: api/<LandmarkController>
        [HttpGet]
        public ActionResult<List<ProtectedSpaceRoom>> Get()
        {
            return psrFunction.Get();
        }

        // GET api/<LandmarkController>/5
        [HttpGet("{id}")]
        public ActionResult<ProtectedSpaceRoom> Get(string id)
        {
            var psr = psrFunction.Get(id);
            if (psr == null)
            {
                return NotFound($"ProtectedSpaceRoom with id = {id} not found");
            }
            return psr;
        }

        // POST api/<LandmarkController>
        [HttpPost]
        public ActionResult<ProtectedSpaceRoom> Post([FromBody] ProtectedSpaceRoom psr)
        {

            psrFunction.Create(psr);
            return CreatedAtAction(nameof(Get), new { id = psr.PsrId }, psr);

        }

        // PUT api/<LandmarkController>/5
        [HttpPut("{id}")]
        
        public ActionResult Put(string id, [FromBody] ProtectedSpaceRoom psr)
        {
            var existingPsr = psrFunction.Get(id);
            if (existingPsr == null)
            {
                return NotFound($"ProtectedSpaceRoom with id = {id} not found");
            }
            psrFunction.Update(id, psr);
            return NoContent();
        }
        // DELETE api/<LandmarkController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var psr = psrFunction.Get(id);
            if (psr == null)
            {
                return NotFound($"ProtectedSpaceRoom with id = {id} not found");
            }
            psrFunction.Remove(psr.PsrId);
            return Ok($"ProtectedSpaceRoom with id = {id} deleted");
        }
    }
}
