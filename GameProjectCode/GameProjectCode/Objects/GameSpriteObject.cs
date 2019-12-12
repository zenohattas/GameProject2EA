using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Objects
{
    abstract class GameSpriteObject : GameObject, ISpriteObject
    {
        /// <summary>
        /// Create gameobject with animation being the first value of the animations library
        /// </summary>
        /// <param name="animations"></param>
        public GameSpriteObject(Dictionary<string, Animation> animations)
        {
            _animations = animations;

            _animationManager = new AnimationManager(_animations.First().Value);
        }
        /// <summary>
        /// Create a gameobject with animation initialised on a specific sprite
        /// </summary>
        /// <param name="animations"></param>
        /// <param name="animation"></param>
        public GameSpriteObject(Dictionary<string, Animation> animations, Animation animation)
        {
            _animations = animations;

            _animationManager = new AnimationManager(animation);
        }

        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        
        public override Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (_animationManager != null)
                {
                    _animationManager.Position = _position;//+ _animationManager._animation.Offset;
                }
            }
        }

        AnimationManager ISpriteObject._animationManager => throw new NotImplementedException();

        Dictionary<string, Animation> ISpriteObject._animations => throw new NotImplementedException();

        protected virtual void draw(SpriteBatch spriteBatch)
        {
            _animationManager.Draw(spriteBatch);
        }
        protected virtual void update(GameTime gametime)
        {
            _animationManager.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            draw(spriteBatch);
        }

        public void Update(GameTime gametime)
        {
            update(gametime);
        }
    }
}
