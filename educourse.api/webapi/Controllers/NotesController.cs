using webapi.Models;
using webapi.Services;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace webapi.Controllers
{
    [Route("api/notes/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteService _noteService;

        public NotesController(NoteService noteservice)
        {
            _noteService = noteservice;
        }


        [HttpGet]
        public ActionResult<List<Note>> Get() =>
            _noteService.Get();
        
        [HttpGet("{id:length(24)}", Name = "GetNotes")]
        public ActionResult<Note> Get(string id)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }
        
        [HttpGet("mailget/{email}")]
        public ActionResult<List<Note>> MailGet(string email)
        {
            var note = _noteService.MailGet(email);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        [HttpPost]
        public ActionResult<Note> Create(Note note)
        {
            _noteService.Create(note);

            return CreatedAtRoute("GetNotes", new { id = note.Id.ToString() }, note);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Note bookIn)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _noteService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var note = _noteService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _noteService.Remove(id);

            return NoContent();
        }
    }
}
