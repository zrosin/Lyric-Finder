using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lyric_Finder.Models
{
    public class Music
    {
        public Message message { get; set; }

        public async void GetSearch(string search, string type)
        {
            
            Music music = await MusicSearcher.GetSearch(search, type);


            music.message.body.track_list.Clear();

            foreach (var trackItem in music.message.body.track_list)
            {
                message.body.track_list.Add(trackItem);
            }

        }

    }

    public class Message
    {
        public Body body { get; set; }

    }

    public class Body
    {
        public ObservableCollection<TrackItem> track_list { get; set; }
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

    public class MusicSearcher
    {
        public async static Task<Music> GetSearch(string search, string type)
        {
            Music music = new Music();

            const string baseUrl = "https://api.musixmatch.com/ws/1.1/";
            const string apiKey = "919ade046d0a70d84044debc6ac28854";
            Uri requestUrl;
            if (type == "Artist")
            {
                requestUrl = new Uri($"{baseUrl}track.search?q_artist={search}&apikey={apiKey}");
            }
            else if (type == "Lyrics")
            {
                requestUrl = new Uri($"{baseUrl}track.search?q_lyrics={search}&apikey={apiKey}");
            }
            else
            {
                requestUrl = new Uri($"{baseUrl}track.search?q_track={search}&apikey={apiKey}");
            }
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(requestUrl);

                music = JsonConvert.DeserializeObject<Music>(json);
            }
            return music;


        }

    }

}
