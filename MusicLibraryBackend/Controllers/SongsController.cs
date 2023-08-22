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
        public IActionResult Get()
        {
            var Songs = _context.Songs.ToList();
            return Ok(Songs);
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id);

            if(song == null) { return NotFound(); }

            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public IActionResult Post([FromBody] Song songs)
        {
            _context.Songs.Add(songs);
            _context.SaveChanges();
            return StatusCode(201, songs);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song songData)
        {
            var existingSong = _context.Songs.Find(id);
            if(existingSong == null)
            {
                return NotFound();
            }

            existingSong.Title = songData.Title;
            existingSong.Artist = songData.Artist;
            existingSong.Album = songData.Album;
            existingSong.ReleaseDate = songData.ReleaseDate;
            existingSong.Genre = songData.Genre;
            _context.SaveChanges();

            return Ok(existingSong);

        }

        [HttpPut("{id}/like")]
        public IActionResult LikeSong(int id)
        {
            var existingSong = _context.Songs.Find(id);

            if (existingSong == null)
            {
                return NotFound();
            }

            existingSong.SongLikes++;

            _context.SaveChanges();

            return Ok(existingSong);
        }


        [HttpPut("{id}/likeRemmove")]
        public IActionResult LikeSongRemove(int id)
        {
            var existingSong = _context.Songs.Find(id);

            if (existingSong == null)
            {
                return NotFound();
            }

            existingSong.SongLikes--;

            _context.SaveChanges();

            return Ok(existingSong);
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _context.Songs.Find(id);
           if(song == null)
            {
                NotFound();
            }
            _context.Songs.Remove(song);
            _context.SaveChanges();

            return NoContent();
        }

 
    
    }
}
