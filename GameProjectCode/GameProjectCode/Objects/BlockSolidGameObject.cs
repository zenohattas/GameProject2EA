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
    class BlockSolidGameObject : GameSpriteObject, IHasCollision
    {
        public BlockSolidGameObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation)
        {
            Position = position;
            _collisionRectangle = new Rectangle((int)position.X, (int)position.Y, animation.Frames[0].Frame.Width, animation.Frames[0].Frame.Height);
        }

        public override Vector2 Position { get => base.Position; set => base.Position = value; }

        private Rectangle _collisionRectangle;
        public Rectangle CollisionRectangle { get { return _collisionRectangle; } }

        private Vector2 _dimension;
        public Vector2 Dimenions
        {
            get
            {
                _dimension.X = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Width;
                _dimension.Y = _animationManager._animation.Frames[_animationManager._animation.CurrentFrame].Frame.Height;
                return _dimension;
            }
        }


        protected override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
        }

        protected override void update(GameTime gametime)
        {
            base.update(gametime);
        }
    }
}
