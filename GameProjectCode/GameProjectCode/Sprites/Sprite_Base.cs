using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Sprites
{
    abstract class Sprite_Base
    {
        public Vector2 Velocity;
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        public Input Input;
        protected Vector2 _position;

        public virtual Vector2 Position
        {
        get { return _position; }
        set { _position = value; }
        }

        public float Speed = 0.8f;
        protected Texture2D _texture;

        public abstract void Draw(SpriteBatch spriteBatch);
        protected abstract void Move();
        protected abstract void SetAnimations();
        public abstract void Update(GameTime gametime, List<Sprite_Base> sprites);
        
    }
}
