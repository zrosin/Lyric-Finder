using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyric_Finder.Models
{
    public class Music
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public Body body { get; set; }

    }

    public class Body
    {
        public List<TrackItem> track_list { get; set; }
    }

    public class TrackItem
    {
        public Track track { get; set; }
    }

    public class Track
    {
        public string track_id { get; set; }

        public string track_name { get; set; }

        public string artist_name { get; set; }
    }
}
