using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GameProjectCode.Models
{
    class Animation
    {
        public Texture2D Texture;
        public int CurrentFrame { get; set; }
        public Vector2 Offset { get; set; }
        //public int FrameCount { get; set; } obsolete => Frames.Count
        //public int FrameHeight { get; set; }
        public float FrameSpeed { get; set; }
        //public int FrameWidth { get; set; }
        public bool IsLooping { get; set; }
        public Animation(Texture2D texture, int framePositionX, int framePositionY, int frameWidth, int frameHeight, bool isLooping = true, float framespeed = 0.14f)
        {

            Texture = texture;

            Frames = new List<AnimationFrame>
            {
                new AnimationFrame(framePositionX, framePositionY, frameWidth, frameHeight)
            };

            IsLooping = isLooping;

            FrameSpeed = framespeed;
        }
        public Animation(Texture2D texture, int framePositionX, int framePositionY, int frameWidth, int frameHeight, int OffsetX, int OffsetY, bool isLooping = true, float framespeed = 0.1f)
        {

            Texture = texture;

            Frames = new List<AnimationFrame>
            {
                new AnimationFrame(framePositionX, framePositionY, frameWidth, frameHeight)
            };

            IsLooping = isLooping;

            FrameSpeed = framespeed;
        }

        //New way of doing it => hardcoding animation values:
        //Waarom doen we dit: easier defining of collisionboxes

        public List<AnimationFrame> Frames;

        ///<summary>
        ///Adds a frame to the animation, dimensions fully specified
        ///</summary>
        public void AddFrame(int framePositionX, int framePositionY, int frameWidth, int frameHeight)
        {
            Frames.Add(new AnimationFrame(framePositionX, framePositionY, frameWidth, frameHeight));
        }
        ///<summary>
        ///Adds a frame to the animation, takes the dimension of the first frame in the animation
        ///</summary>
        public void AddFrame(int framePositionX, int framePositionY)
        {
            Frames.Add(new AnimationFrame(framePositionX, framePositionY, Frames[0].Frame.Width, Frames[0].Frame.Height));
        }

    }
}
