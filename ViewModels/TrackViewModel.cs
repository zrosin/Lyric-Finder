using Lyric_Finder.Models;
using System.ComponentModel;

namespace Lyric_Finder.ViewModels
{

    public class TrackViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Track track;

        public TrackViewModel()
        {
            this.track = new Track();
        }

        public string track_id
        {
            get { return track.track_id; }

            set 
            {
                track.track_id = value;
                OnPropertyChanged("track_id");
            }
        }

        public string artist_name 
        {
            get { return track.artist_name; }
            set 
            {
                track.artist_name = value;
                OnPropertyChanged("artist_name");
            }
        }
        public string track_name
        {
            get { return track.track_name; }
            set 
            {
                track.track_name = value;
                OnPropertyChanged("track_name");
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
