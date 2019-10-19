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
        public GameObject(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
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
                    _animationManager.Position = _position;
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
