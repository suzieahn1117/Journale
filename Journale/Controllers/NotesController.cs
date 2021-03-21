using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Journale.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Journale.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private static readonly Note[] ExampleNotes = new[]
            {
            new Note { Content = "WandaVision" },
            new Note { Content = "Hawk and Bucky"},
            new Note { Content = "Captain America"}
        };

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return ExampleNotes;
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NotesController>
        [HttpPost]
        public object Post([FromBody] Note note)
        {
            return new
            {
                Message = "Success!",
                Note = note
            };
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
