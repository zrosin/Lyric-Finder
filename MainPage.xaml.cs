using Lyric_Finder.Models;
using Lyric_Finder.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lyric_Finder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MusicViewModel music;

        FavoriteSongsViewModel favoriteSongsList = new FavoriteSongsViewModel();

        public MainPage()
        {
            this.InitializeComponent();

            music = new MusicViewModel();
            //this.DataContext = songs;
            FavoritesListView.ItemsSource = favoriteSongsList.favoriteSongs;
            

            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            favoriteSongsList = new FavoriteSongsViewModel();

            FavoritesListView.ItemsSource = favoriteSongsList.favoriteSongs;
        }

        private async void SearchClick(object sender, RoutedEventArgs e)
        {
            if (searchType.SelectedItem != null)
            {
                string type = ((ComboBoxItem)searchType.SelectedItem).Content.ToString();
                _ = await music.QueryTrack(searchText.Text, type);
                SearchListView.ItemsSource = music.songList;
            }
        }

        private void SearchListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Song send = e.ClickedItem as Song;

            var parameters = new LyricPageParams();
            
            parameters.Title = send.Title;
            parameters.Artist = send.Artist;
            parameters.ID = send.Id;
            
            Frame.Navigate(typeof(LyricPage), parameters);
        }

        private void FavoritesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Song send = e.ClickedItem as Song;

            var parameters = new LyricPageParams();

            parameters.Title = send.Title;
            parameters.Artist = send.Artist;
            parameters.ID = send.Id;
            parameters.Lyrics = send.Lyrics;

            Frame.Navigate(typeof(LyricPage), parameters);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AboutPage));
        }
    }
}
