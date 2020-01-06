using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class SoundEffectManager
    {
        Dictionary<string, SoundEffect> Sounds;
        public SoundEffectManager()
        {
            Sounds = new Dictionary<string, SoundEffect>();
        }
        public void LoadSounds(ContentManager Content)
        {
            //Sounds.Add("DesertBackground", Content.Load<Song>("Sounds/"));
        }
        public void PlaySound(string Sound)
        {
            try
            {
                Sounds[Sound].Play();
            }
            catch (Exception)
            {
                throw new EntryPointNotFoundException("Error: Sound does not exist!");
            }
        }
    }
}
