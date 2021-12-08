using Lyric_Finder.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lyric_Finder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MusicViewModel music;

        public MainPage()
        {
            this.InitializeComponent();
            music = new MusicViewModel();

        }
        public async void GetSearch(string search, string type)
        {

            
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
                
                music = JsonConvert.DeserializeObject<MusicViewModel>(json);
            }
        }
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if (searchType.SelectedItem != null)
            {
                string type = ((ComboBoxItem)searchType.SelectedItem).Content.ToString();

                GetSearch(searchText.Text, type);
            }
            
        }
    }
}
