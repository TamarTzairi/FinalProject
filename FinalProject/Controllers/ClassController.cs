using FinalProject.DTO;
using FinalProject.Store;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassFunction classFunction;

        public ClassController(IClassFunction _classFunction)
        {
            this.classFunction = _classFunction;
        }
        // GET: api/<LandmarkController>
        [HttpGet]
        public ActionResult<List<Class>> Get()
        {
            return classFunction.Get();
        }

        // GET api/<LandmarkController>/5
        [HttpGet("{id}")]
        public ActionResult<Class> Get(string id)
        {
            var classs = classFunction.Get(id);
            if (classs == null)
            {
                return NotFound($"class with id = {id} not found");
            }
            return classs;
        }

        // POST api/<LandmarkController>
        [HttpPost]
        public ActionResult<Class> Post([FromBody] Class classs)
        {

            classFunction.Create(classs);
            return CreatedAtAction(nameof(Get), new { id = classs.ClassId }, classs);

        }

        // PUT api/<LandmarkController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Class classs)
        {
            var existingClass = classFunction.Get(id);
            if (existingClass == null)
            {
                return NotFound($"class with id = {id} not found");
            }
            classFunction.Update(id, classs);
            return NoContent();
        }

        // DELETE api/<LandmarkController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var classs = classFunction.Get(id);
            if (classs == null)
            {
                return NotFound($"class with id = {id} not found");
            }
            classFunction.Remove(classs.ClassId);
            return Ok($"class with id = {id} deleted");
        }
    }
}
