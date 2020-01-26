using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectCode.Objects
{
    abstract class PowerUpGameObject : BlockSolidGameObject, ICanCollide
    {
        public bool IsVisible { get; set; }
        public PowerUpGameObject(Dictionary<string, Animation> animations, Animation animation, Vector2 Position, float Scale) : base(animations, animation, Position)
        {
            animation.SetScale(new Vector2(Scale));
            IsVisible = true;
        }

        public void Collide(IHasCollision o)
        {
            if (o is PlayerGameObject)
            {
                GivePowerUp(o as PlayerGameObject);
                IsVisible = false;
            }
        }

        public void ResolveCollisions()
        {
            
        }

        protected override void draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                base.draw(spriteBatch);
            }
        }

        abstract public void GivePowerUp(PlayerGameObject player);
    }
}
