using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyric_Finder.Models
{
 
    public class SongList
    {
        public List<Track> Tracks { get; set; }

        
        public SongList()
        {
            Tracks = new List<Track>
            {
                new Track { track_id = "123", artist_name = "Imagine Dragons", track_name = "Demons"},
                new Track { track_id = "1976", artist_name = "Twenty One Pilots", track_name = "Mulberry Street"}
            };
        }
        
    }
}
