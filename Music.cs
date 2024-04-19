using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibraryManager
{
    [Table("music")]
    public class Music
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("musicID")]
        public int ID { get; set; }
        [Column("song_name")]
        public string Name { get; set; }
        [Column("artist_name")]
        public string Artist { get; set; }
        [Column("album_name")]
        public string Album { get; set; }
        [Column("time_in_seconds")]
        public int Time { get; set; }
    }
}
