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
    class MenuObject : GameSpriteObject, IHasCollision
    {
        bool ShouldInvert;
        bool IsInverted;
        Vector2 _dimension;
        Rectangle _collisionRectangle;
        public MenuObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation)
        {
            Position = position;
            ShouldInvert = false;
            IsInverted = false;
        }

        public override Vector2 Position { get => base.Position; set => base.Position = value; }

        public Rectangle CollisionRectangle
        {
            get
            {
                _collisionRectangle.X = (int)Position.X;
                _collisionRectangle.Y = (int)Position.Y;
                _collisionRectangle.Width = (int)Dimenions.X;
                _collisionRectangle.Height = (int)Dimenions.Y;
                return _collisionRectangle;
                //return _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame;
            }
        }

        public Vector2 Dimenions
        {
            get
            {
                _dimension.X = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Width;
                _dimension.Y = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Height;
                return _dimension;
            }
        }

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
