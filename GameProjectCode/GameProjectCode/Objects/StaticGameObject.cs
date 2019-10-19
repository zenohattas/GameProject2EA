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
    abstract class StaticGameObject
    {
        public StaticGameObject(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
        public virtual Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        protected Vector2 _position;
        protected Texture2D _texture;

        protected abstract void Move();
        public abstract void Update(GameTime gametime, List<GameObject> sprites);
    }
}
