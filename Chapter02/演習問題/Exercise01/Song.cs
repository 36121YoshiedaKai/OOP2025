using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //2.1.1
    public class Song {

        public string Title { get; set; } = string.Empty;
        string ArtistName { get; set; } = string.Empty;
        int Length { get; set; }

        //2.1.2
        public Song(string title, string artistname, int length) {
            this.Title = title;
            this.ArtistName = artistname;
            this.Length = length;
        }
    }


}
