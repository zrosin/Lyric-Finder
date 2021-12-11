using Lyric_Finder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lyric_Finder.ViewModels
{

    public class MusicViewModel
    {
        public ObservableCollection<Song> songList;
        
        public MusicViewModel()
        {
            songList = new ObservableCollection<Song>();
        }

        public async Task<int> QueryTrack(string search, string type)
        {
            songList = await ApiCalls.GetSearch(search, type);
            return 1;
        }
    }
}

