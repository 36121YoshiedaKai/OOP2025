namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //2.1.3

            var songs = new List<Song>();
            Console.WriteLine("*****曲名の登録*****");
            while (true) {

                Console.Write("曲名:");
                string? title = Console.ReadLine();
                //endを入れたら終了、大文字小文字区別なし
                if (title.Equals("end", StringComparison.OrdinalIgnoreCase) /*|| title.Equals("END")*/) break;

                Console.Write("アーティスト名:");
                string? artistname = Console.ReadLine();
                Console.Write("演奏時間（秒）:");
                int length = int.Parse(Console.ReadLine());
                //songs.Add(new Song(title, artistname, length));
                Song song = new Song() {
                    Title = title,
                    ArtistName = artistname,
                    Length = length,
                };
                songs.Add(song);
                //改行
                Console.WriteLine();
            }

            printSongs(songs);
        }

        //2.1.4
        private static void printSongs(IEnumerable<Song> songs) {
#if true
            foreach (var song in songs) {
                Console.WriteLine($"{song.Title},{song.ArtistName},{song.Length}");
            }


            /*foreach (var song in songs) {
                int timeA = song.Length / 60 ;
                int timeU = song.Length % 60;

                Console.WriteLine($"{song.Title},{song.ArtistName},{timeA}:{timeU:00}");
            }*/
#else
            //TimeSpan構造体を使った場合
            /*foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title},{song.ArtistName},{timespan.Minutes}:{timespan.Seconds:00}");

            }*/

            foreach (var song in songs) {
                Console.WriteLine(@"{0},{1},{2:m\:ss}",
                    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));

            }

#endif

        }
    }
}

