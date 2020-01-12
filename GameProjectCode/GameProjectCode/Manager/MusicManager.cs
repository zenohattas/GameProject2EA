using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class MusicManager
    {
        Dictionary<string, Song> Songs;
        private Song currentSong;
        public MusicManager()
        {
            Songs = new Dictionary<string, Song>();
        }
        /// <summary>
        /// Only to be used once, if called again will overwrite previous added songs.
        /// </summary>
        /// <param name="songs"></param>
        public void AddSongs(Dictionary<string, Song> songs)
        {
            Songs = songs;
        }
        public void PlaySong(string Song)
        {
            try
            {
                if (currentSong != Songs[Song])
                {
                    MediaPlayer.Play(Songs[Song]);
                    MediaPlayer.IsRepeating = true;
                    currentSong = Songs[Song];

                }
            }
            catch (Exception)
            {
                throw new EntryPointNotFoundException("Error: Song does not exist!");
            }
        }
    }
}
