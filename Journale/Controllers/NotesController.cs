using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private string connectionString = "Data Source = aeons-prod.cpgkjp6s0hpf.us-west-1.rds.amazonaws.com; " +
            "Initial Catalog=Journale; " + "User id=Master; Password=ColdBrew1; ";


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

                List<Note> notes = new List<Note>();
                using(var _conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Note", _conn);
                    command.Connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Note note = new Note();
                            note.Content = reader["Content"].ToString();
                            note.Id = reader["Id"].ToString();
                            note.CreatedDate = reader["createdDate"].ToString();
                            notes.Add(note);
                        }
                    }
                }
                return notes;
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            using(var _conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Note WHERE Id=@Id", _conn);
                command.Parameters.AddWithValue("@Id", id);
                command.Connection.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Note note = new Note();
                        note.Content = reader["Content"].ToString();
                        note.Id = reader["Id"].ToString();
                        note.CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString());
                        return note;
                    }
                }
            }
            return new Note();
        }

        // POST api/<NotesController>
        [HttpPost]
        public void Post([FromBody] Note note)
        {
           using(var _conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Note (Content, CreatedDate) VALUES (@content, @CreatedDate)", _conn);
                command.Connection.Open();
                command.Parameters.AddWithValue("@content", note.Content);
                command.Parameters.AddWithValue("@CreatedDate", note.CreatedDate);
                command.ExecuteNonQuery();
            }

        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Note note)
        {
            using(var _conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Note SET Content=@Content WHERE Id=@Id", _conn);
                command.Connection.Open();
                command.Parameters.AddWithValue("@Content", note.Content);
                command.Parameters.AddWithValue("@Id", note.Id);
                command.ExecuteNonQuery();
            }
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using(var _conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Note WHERE Id=@id", _conn);
                command.Connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
