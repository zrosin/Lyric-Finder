using Microsoft.EntityFrameworkCore;

namespace Lyric_Finder.Models
{
    class FavoriteSongsContext : DbContext
    {
        public DbSet<Song> Favorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=favorites.db");
        }
    }
}
