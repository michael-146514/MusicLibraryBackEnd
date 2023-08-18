using Microsoft.AspNetCore.Mvc;
using MusicLibraryBackend.Data;
using MusicLibraryBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var Songs = _context.Songs.ToList();
            return Ok(Songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var songId = _context.Songs.Where(s => s.Id == id);
            if(songId == null)
            {
                return NotFound();
            }
            return Ok(songId);
        }

        // POST api/<SongsController>
        [HttpPost]
        public ActionResult Post([FromBody] Song songs)
        {
            _context.Songs.Add(songs);
            _context.SaveChanges();
            return StatusCode(201, songs);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
