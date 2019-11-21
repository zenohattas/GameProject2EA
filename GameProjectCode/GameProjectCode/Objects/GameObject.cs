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
    abstract class GameObject
    {
        /// <summary>
        /// Create gameobject with animation being the first value of the animations library
        /// </summary>
        /// <param name="animations"></param>
        public GameObject(Dictionary<string, Animation> animations)
        {
            _animations = animations;

            _animationManager = new AnimationManager(_animations.First().Value);
        }
        /// <summary>
        /// Create a gameobject with animation initialised on a specific sprite
        /// </summary>
        /// <param name="animations"></param>
        /// <param name="animation"></param>
        public GameObject(Dictionary<string, Animation> animations, Animation animation)
        {
            _animations = animations;

            _animationManager = new AnimationManager(animation);
        }

        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected Vector2 _position;
        
        public virtual Vector2 Position
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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            _animationManager.Draw(spriteBatch);
        }
        protected abstract void SetAnimations();
        public virtual void Update(GameTime gametime, List<GameObject> objects)
        {
            SetAnimations();

            _animationManager.Update(gametime);
        }

    }
}
