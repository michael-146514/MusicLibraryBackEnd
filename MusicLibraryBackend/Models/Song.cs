using System.ComponentModel.DataAnnotations;

namespace MusicLibraryBackend.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int SongLikes { get; set; }
    }
}
