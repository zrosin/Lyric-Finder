using Lyric_Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyric_Finder.ViewModels
{
    public class MusicViewModel
    {
        private Music music;
        
        public MusicViewModel()
        {
            this.music = new Music();
        }

        public Message message
        {
            get { return music.message; }
            set { music.message = value; }
        }

        
    }

    public class MessageViewModel
    {
        private Message message;

        public MessageViewModel()
        {
            this.message = new Message();
        }
        
        public Body body
        {

            get { return message.body; }
            set { message.body = value; }
        }
    }

    public class BodyViewModel
    {
        private Body body;

        public BodyViewModel()
        {
            this.body = new Body();
        }

        public List<TrackItem> track_list
        {
            get { return body.track_list; }
            set { body.track_list = value; }
        }
    }

    public class TrackItemViewModel
    {
        private TrackItem trackItem;
        
        public TrackItemViewModel()
        {
            this.trackItem = new TrackItem();
        }

        public Track track
        {
            get { return trackItem.track; }
            set { trackItem.track = value; }
        }
    }

    public class TrackViewModel
    { 
        private Track track;

        public TrackViewModel()
        {
            this.track = new Track();
        }

        public string track_id
        {
            get { return track.track_id; }

            set { track.track_id = value;}
        }

        public string artist_name
        {
            get { return track.artist_name; }
            set { track.artist_name = value;}
        }
        public string track_name
        {
            get { return track.track_name; }
            set { track.track_name = value;}
        }
    }
}

