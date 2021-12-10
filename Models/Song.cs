using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lyric_Finder.Models
{
    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string MusixmatchID { get; set; }
        public string Lyrics { get; set; }
        public bool IsFavorite { get; set; }

        
    }
}
