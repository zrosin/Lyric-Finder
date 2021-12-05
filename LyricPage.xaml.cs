using Lyric_Finder.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lyric_Finder
{
    public class LyricPageParams
    {
        public LyricPageParams() { }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string ID { get; set; }
    }


    public sealed partial class LyricPage : Page
    {
        public SongViewModel Song = new SongViewModel();

        
        public LyricPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (LyricPageParams)e.Parameter;

            Song.Title = parameters.Title;
            Song.Artist = parameters.Artist;
            Song.MusixmatchID = parameters.ID;
            GetSongLyrics(parameters.ID);
        }

        public async void GetSongLyrics(string ID)
        {
            const string baseUrl = "https://api.musixmatch.com/ws/1.1/";
            const string apiKey = "919ade046d0a70d84044debc6ac28854";

            Uri requestUrl = new Uri($"{baseUrl}track.lyrics.get?commontrack_id={ID}&apikey={apiKey}");

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(requestUrl);
                dynamic info = JsonConvert.DeserializeObject(json);
                Song.Lyrics = info.message.body.lyrics.lyrics_body;
            }
            
        }
    }
}
