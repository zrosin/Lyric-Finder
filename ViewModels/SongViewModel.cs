using Lyric_Finder.Models;
using System.ComponentModel;

namespace Lyric_Finder.ViewModels
{
    public class SongViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Song song;

        public SongViewModel()
        {
            this.song = new Song();
        }

        public string Title 
        {
            get { return song.Title; }

            set
            {
                song.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Artist
        {
            get { return song.Artist; }

            set
            {
                song.Artist = value;
                OnPropertyChanged("Artist");
            }
        }

        public string Id
        {
            get { return song.Id; }

            set
            {
                song.Id = value;
                OnPropertyChanged("MusixmatchID");
            }
        }

        public string Lyrics
        {
            get { return song.Lyrics; }

            set
            {
                song.Lyrics = value;
                OnPropertyChanged("Lyrics");
            }
        }

        public bool IsFavorite
        {
            get { return song.IsFavorite; }

            set
            {
                song.IsFavorite = value;
                OnPropertyChanged("IsFavorite");
            }
        }

        private void OnPropertyChanged(string property)
        {
            // Notify any controls bound to the ViewModel that the property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
