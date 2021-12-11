using Lyric_Finder.Models;
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
        public string Lyrics { get; set; }
    }


    public sealed partial class LyricPage : Page
    {
        public SongViewModel Song = new SongViewModel();

        
        public LyricPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameters = (LyricPageParams)e.Parameter;

            Song.Title = parameters.Title;
            Song.Artist = parameters.Artist;
            Song.Id = parameters.ID;
            
            if(parameters.Lyrics == null)
            {
                var a = await Song.GetLyrics();
            }
            else
            {
                favoriteButton.IsEnabled = false;
                Song.Lyrics = parameters.Lyrics;
            }

            this.DataContext = Song;
        }

        

        private void FavoriteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //I dont think interacting with the model here is against MVVM, as I don't need to view anything.
            using(var db = new FavoriteSongsContext())
            {
                db.Favorites.Add(Song.song);
                db.SaveChanges();
            }

            //disable button to show that task is completed
            favoriteButton.IsEnabled = false;
        }
    }
}
