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
        public async static Task<string> GetSongLyrics(string ID)
        {
            const string baseUrl = "https://api.musixmatch.com/ws/1.1/";
            const string apiKey = "919ade046d0a70d84044debc6ac28854";

            Uri requestUrl = new Uri($"{baseUrl}track.lyrics.get?commontrack_id={ID}&apikey={apiKey}");
            string lyrics;
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(requestUrl);
                dynamic info = JsonConvert.DeserializeObject(json);
                if(info.message.header.status_code != 200)
                {
                    return "Server error.\n\nThis song may have been deleted, or has no lyrics.\nPlease try a different song.";
                }
                lyrics = info.message.body.lyrics.lyrics_body;
            }
            return lyrics;
        }

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
                foreach (var track in info.message.body.track_list)
                {
                    Song song = new Song();
                    
                    song.Artist = track.track.artist_name;
                    song.Title = track.track.track_name;
                    song.Id = track.track.commontrack_id;
                    songs.Add(song);
                }

            }

            return songs;

        }
    }
}
