using Lyric_Finder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyric_Finder.ViewModels
{
    //A lot of code retrevied and addapted from in class examples and notes

    public class SongListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SongList songList;

        public ObservableCollection<TrackViewModel> Tracks { get; set; }

        public SongListViewModel()
        {
            this.songList = new SongList();

            Tracks = new ObservableCollection<TrackViewModel>();
            
            foreach(var track in songList.Tracks)
            {
                var newTrack = new TrackViewModel
                {
                    track_id = track.track_id,
                    track_name = track.track_name,
                    artist_name = track.artist_name

                };
                newTrack.PropertyChanged += OnPropertyChanged;
                Tracks.Add(newTrack);
            }
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, e);
        }
    }
}
