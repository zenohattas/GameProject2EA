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
    class MenuObject : GameSpriteObject
    {
        bool ShouldInvert;
        bool IsInverted;
        public MenuObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation)
        {
            Position = position;
            ShouldInvert = false;
            IsInverted = false;
        }

        public override Vector2 Position { get => base.Position; set => base.Position = value; }

        public void Invert()
        {
            if(!IsInverted)
                ShouldInvert = true;
        }
        public void Revert()
        {
            if (IsInverted)
                ShouldInvert = true;
        }
        protected override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
        }

        protected override void update(GameTime gametime)
        {
            if (ShouldInvert)
            {
                base.update(gametime);
                ShouldInvert = false;
                IsInverted = !IsInverted;
            }
        }
    }
}
