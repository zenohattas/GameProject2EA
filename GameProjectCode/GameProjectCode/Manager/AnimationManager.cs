﻿using System;
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
        private Animation _animation;
        private float _timer;

        public Vector2 Position { get; set; }
        public AnimationManager(Animation animation)
        {
            _animation = animation;
            _timer = 0;
        }
        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;

            //_animation.CurrentFrame = 0;

            //_timer = 0;
        }
        public void Stop()
        {
            _timer = 0;
            _animation.CurrentFrame = 0;
        }
        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0;
                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_animation.Texture,
                            Position,
                            new Rectangle(_animation.CurrentFrame * _animation.FrameWidth,
                                          0,
                                          _animation.FrameWidth,
                                          _animation.FrameHeight),
                            Color.White);
        }
    }
}
