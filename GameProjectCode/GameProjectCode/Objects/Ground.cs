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
    class Ground : GameObject, ICollidable
    {
        //public Ground (Dictionary<string, Animation> animations, int gameViewWidth) : base(animations)
        //{
        //    GameViewWidth = gameViewWidth;
        //}
        public Ground(Dictionary<string, Animation> animations, Viewport viewport, Animation animation, Vector2 position) : base(animations, animation)
        {
            _viewport = viewport;
            animationWidth = animation.Frames[0].Frame.Width;
            _collisionRectangle = new Rectangle((int)position.X, (int)position.Y, viewport.Width, animation.Frames[0].Frame.Height);
            Position = position;
        }

        private int animationWidth;
        //private int GameViewWidth;
        private Rectangle _collisionRectangle;
        private Vector2 _dimension;
        private Viewport _viewport;

        public Rectangle CollisionRectangle
        {
            get
            {
                _collisionRectangle.Width = _viewport.Width;
                return _collisionRectangle;
                //return _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame;
            }
        }
        Vector2 ICollidable.Dimenions {
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
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = Position;
            Vector2 drawWidth = new Vector2(animationWidth, 0);
            for (int i = (int)drawWidth.X; i < _viewport.Width; i++)
            {
                base.Draw(spriteBatch);
                Position += drawWidth;
            }
            Position = origin;
        }
    }
}
