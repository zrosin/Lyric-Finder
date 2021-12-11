using Lyric_Finder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyric_Finder.ViewModels
{
    class FavoriteSongsViewModel
    {
        public ObservableCollection<Song> favoriteSongs = new ObservableCollection<Song>();

        public FavoriteSongsViewModel()
        {
            using (var db = new Models.FavoriteSongsContext())
            {
                foreach (var song in db.Favorites)
                {
                    favoriteSongs.Add(song);
                }
            }
        }
    }
}
