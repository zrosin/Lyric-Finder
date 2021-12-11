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
        
        public MessageViewModel message;
        public BodyViewModel body;
        public TrackItemViewModel trackItem;
        public TrackViewModel track;
        

        public MainPage()
        {
            this.InitializeComponent();
            music = new MusicViewModel();
            message = new MessageViewModel();
            body = new BodyViewModel();
            trackItem = new TrackItemViewModel();
            track = new TrackViewModel();
            

        }
       
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            if (searchType.SelectedItem != null)
            {
                string type = ((ComboBoxItem)searchType.SelectedItem).Content.ToString();

                music.GetSearch(searchText.Text, type);
               
            }
            
        }


        private void SearchListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*
            track = SearchListView.SelectedItem as TrackViewModel;

            var parameters = new LyricPageParams();
            parameters.Title = track.track_name;
            parameters.Artist = track.artist_name;
            parameters.ID = track.track_id;
            this.Frame.Navigate(typeof(LyricPage), parameters);
            */

        }
    }
}
