using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Objects
{
    class Block : GameSpriteObject, ICollidable
    {
        public Block(Dictionary<string, Animation> animations, Animation animation) : base(animations, animation)
        {
            _dimensions.X = animation.Frames[animation.CurrentFrame].Frame.Width;
            _dimensions.Y = animation.Frames[animation.CurrentFrame].Frame.Height;
        }

        protected Rectangle _collisionRectangle;
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
        protected Vector2 _dimensions;
        public Vector2 Dimenions => _dimensions;
    }
}
