using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Objects
{
    class Ground : GameObject, ICollidable
    {
        public Ground (Dictionary<string, Animation> animations) : base(animations)
        {
        }

        private Rectangle _collisionReactangle;
        private Vector2 _dimension;

        Rectangle ICollidable.CollisionRectangle => _collisionReactangle;
        Vector2 ICollidable.Dimenion {
            get
            {
                _dimension.X = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Width;
                _dimension.Y = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Height;
                return _dimension;
            }
        }

        protected override void SetAnimations()
        {
            //Keeps the same sprite as declared in the object creation;
        }

        void ICollidable.Collide(ICollidable o)
        {
            //Does nothing for now, no ground functionality;
        }
    }
}
