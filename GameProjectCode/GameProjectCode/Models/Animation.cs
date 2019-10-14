using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;


namespace GameProjectCode.Models
{
    class Animation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; set; }
        public int FrameHeight { get { return Texture.Height; } }
        public float FrameSpeed { get; set; }
        public int FrameWidth { get { return Texture.Width / FrameCount; } }
        public bool IsLooping { get; set; }
        public Texture2D Texture { get; set; }
        public Animation(Texture2D texture, int frameCount, bool isLooping = true, float framespeed = 0.1f)
        {
            Texture = texture;

            FrameCount = frameCount;

            IsLooping = isLooping;

            FrameSpeed = framespeed;
        }
    }
}
