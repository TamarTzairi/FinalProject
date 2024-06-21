using FinalProject.DTO;
using FinalProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomFunction roomFunction;

        public RoomController(IRoomFunction _roomFunction)
        {
            this.roomFunction = _roomFunction;
        }
        // GET: api/<LandmarkController>
        [HttpGet]
        public ActionResult<List<Room>> Get()
        {
            return roomFunction.Get();
        }

        // GET api/<LandmarkController>/5
        [HttpGet("{id}")]
        public ActionResult<Room> Get(string id)
        {
            var room = roomFunction.Get(id);
            if (room == null)
            {
                return NotFound($"room with id = {id} not found");
            }
            return room;
        }

        // POST api/<LandmarkController>
        [HttpPost]
        public ActionResult<Room> Post([FromBody] Room room)
        {

            roomFunction.Create(room);
            return CreatedAtAction(nameof(Get), new { id = room.RoomId }, room);

        }

        // PUT api/<LandmarkController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Room room)
        {
            var existingRoom = roomFunction.Get(id);
            if (existingRoom == null)
            {
                return NotFound($"room with id = {id} not found");
            }
            roomFunction.Update(id, room);
            return NoContent();
        }

        // DELETE api/<LandmarkController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var room = roomFunction.Get(id);
            if (room == null)
            {
                return NotFound($"room with id = {id} not found");
            }
            roomFunction.Remove(room.RoomId);
            return Ok($"room with id = {id} deleted");
        }
    }

}
