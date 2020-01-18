using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Manager
{
    class AnimationManager
    { 
        public Animation _animation;
        private Timer _timer;

        public Vector2 Position { get; set; }
        public AnimationManager(Animation animation)
        {
            _animation = animation;
            _timer = new Timer();
        }
        public void Play(Animation animation)
        {

            _animation = animation;

            //_animation.CurrentFrame = 0;

            //_timer = 0;
        }
        public void Reset()
        {
            _timer.Time = 0;
            _animation.CurrentFrame = 0;
        }
        public void Update(int ToFrame)
        {
            if (_animation.Frames.Count > ToFrame)
            {
                _animation.CurrentFrame = ToFrame;
            }
        }
        public void Update(GameTime gameTime)
        {
            _timer.Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer.Time >= _animation.FrameSpeed)
            {
                _timer.Time = 0;
                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.Frames.Count)
                {
                    if (_animation.IsLooping)
                    {
                        _animation.CurrentFrame = 0;
                    }
                    else{
                        _animation.CurrentFrame--;
                    }
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_animation.Texture,
                            Position + _animation.Offset,
                            _animation.Frames[_animation.CurrentFrame].Frame,
                                Color.White);
        }
    }
}
