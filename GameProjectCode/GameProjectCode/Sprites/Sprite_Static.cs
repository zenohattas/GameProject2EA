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
    class Sprite_Static : Sprite_Base
    {
        public Sprite_Static(Texture2D texture)
        {
            _texture = texture;
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public override void Update(GameTime gametime, List<Sprite_Base> sprites)
        {
            Move();

            Position += Velocity;

            Velocity = Vector2.Zero;
        }

        protected override void Move()
        {
            //empty
        }

        protected override void SetAnimations() { } //no implementation
    }
}
