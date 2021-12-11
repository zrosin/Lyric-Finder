using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lyric_Finder.Models
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Id { get; set; }
        public string Lyrics { get; set; }
    }
}
