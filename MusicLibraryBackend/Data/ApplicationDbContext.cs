using Microsoft.EntityFrameworkCore;
using MusicLibraryBackend.Models;

namespace MusicLibraryBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
