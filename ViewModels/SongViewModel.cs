using Lyric_Finder.Models;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Lyric_Finder.ViewModels
{
    public class SongViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //needs to be public to work with entity. this is a YUCKY way to write a class. MVVM sucks toes
        public Song song;

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

        public async Task<int> GetLyrics()
        {
            song.Lyrics = await ApiCalls.GetSongLyrics(song.Id);
            return 1;
        }

        private void OnPropertyChanged(string property)
        {
            // Notify any controls bound to the ViewModel that the property changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
