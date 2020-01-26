using GameProjectCode.Models;
using GameProjectCode.Models.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Objects
{
    class BlockClimbableGameObject : BlockTransparentGameObject, IHasCollision, IClimbable
    {
        private Rectangle _collisionRectangle;
        private Vector2 _dimension;
        public BlockClimbableGameObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation, position)
        {
            _collisionRectangle = new Rectangle();
            _dimension = new Vector2();
        }

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
            private set
            {
                _dimension = value;
            }
        }
    }
}
