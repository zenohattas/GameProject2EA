using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameProjectCode.Objects
{
    class MonsterGameObject : ControlledGameObject, ICollidable, IAnimated, IDamagable
    {
        protected Rectangle _collisionRectangle;
        private Vector2 _dimension;
        public MonsterGameObject(Dictionary<string, Animation> animations, float Speed = 0.15F) : base(animations, Speed)
        {
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
            }
        }

        public Vector2 Dimenions 
        {
            get
            {
                _dimension.X = _animationManager._animation.Frames [_animationManager._animation.CurrentFrame].Frame.Width;
                _dimension.Y = _animationManager._animation.Frames [_animationManager._animation.CurrentFrame].Frame.Height;
                    return _dimension;
            }
        }
        public int HP { get; private set; }
        public override Vector2 Position { get => base.Position; set => base.Position = value; }

        public void Collide(IHasCollision o)
        {
            throw new NotImplementedException();
        }

        public void Damage(int damage)
        {
            HP -= damage;
        }

        public void ResolveCollisions()
        {
            
        }

        public void SetAnimations()
        {
            throw new NotImplementedException();
        }

        protected override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
        }

        protected override void Move()
        {
            base.Move();
        }

        protected override void update(GameTime gametime)
        {
            base.update(gametime);
        }
    }
}
