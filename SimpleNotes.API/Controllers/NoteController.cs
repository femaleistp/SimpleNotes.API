using Microsoft.AspNetCore.Mvc;
using SimpleNotes.API.Interfaces;
using SimpleNotes.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _service; // Dependency injection for INoteService
        public NoteController(INoteService service) // Constructor injection for INoteService
        {
            _service = service; // Inject the INoteService dependency
        }

        // GET: api/<NoteController>
        [HttpGet("GetAll")] // Custom route for getting all notes
        public IActionResult GetAll() // ActionResult to return a response
        {
            // Get all notes from the service
            var notes = _service.GetAll();
            // Return the notes as a JSON response
            return Ok(notes);
        }

        // GET api/<NoteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) // ActionResult to return a response
        {
            var note = _service.GetById(id); // Get a note by ID from the service
            return note == null ? NotFound(): Ok(note); // Return 404 if not found, else return the note
        }

        // POST api/<NoteController>
        [HttpPost]
        public IActionResult Create([FromBody] Note note) // ActionResult to return a response
        {

            _service.Add(note); // Add a new note using the service
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note); // Return 201 Created with the note
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Note note)
        {
            if (id != note.Id)
            {
                return BadRequest("Note ID mismatch");
            }
            var updated = _service.Update(note);
            if(!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id); // Delete a note by ID using the service   
            return NoContent(); // Return 204 No Content after deletion
        }
    }
}
