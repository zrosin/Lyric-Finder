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
    class ApiCalls
    {

        public async static Task<ObservableCollection<Song>> GetSearch(string search, string type)
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();

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
                dynamic info = JsonConvert.DeserializeObject(json);
                foreach (string id in info.message.body.track_list.commontrack_id)
                {
                    
                    Song song = new Song();
                    
                    song.Artist = info.message.body.track_list.track_id.artist_name;
                    //song.Title = track.track_name;
                    song.MusixmatchID = id;
                    songs.Add(song);
                }

            }

            return songs;

        }
    }
}
