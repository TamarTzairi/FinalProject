using FinalProject.DTO;
using FinalProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarkController : ControllerBase
    {
        private readonly ILandmarkFunction landmarkFunction;

        public LandmarkController(ILandmarkFunction _landmarkFunction)
        {
            this.landmarkFunction = _landmarkFunction;
        }
        // GET: api/<LandmarkController>
        [HttpGet]
        public ActionResult<List<Landmark>> Get()
        {
            return landmarkFunction.Get();
        }

        // GET api/<LandmarkController>/5
        [HttpGet("{id}")]
        public ActionResult<Landmark> Get(string id)
        {
            var landmark = landmarkFunction.Get(id);
            if (landmark == null)
            {
                return NotFound($"landmark with id = {id} not found");
            }
            return landmark;
        }

        // POST api/<LandmarkController>
        [HttpPost]
        public ActionResult<Landmark> Post([FromBody] Landmark landmark)
        {
           
            landmarkFunction.Create(landmark);
            return CreatedAtAction(nameof(Get), new { id = landmark.LandmarkId }, landmark);

        }

        // PUT api/<LandmarkController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Landmark landmark)
        {
            var existingLandmark = landmarkFunction.Get(id);
            if (existingLandmark == null)
            {
                return NotFound($"landmark with id = {id} not found");
            }
            landmarkFunction.Update(id, landmark);
            return NoContent();
        }

        // DELETE api/<LandmarkController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var landmark = landmarkFunction.Get(id);
            if (landmark == null)
            {
                return NotFound($"landmark with id = {id} not found");
            }
            landmarkFunction.Remove(landmark.LandmarkId);
            return Ok($"landmark with id = {id} deleted");
        }
    }
}
