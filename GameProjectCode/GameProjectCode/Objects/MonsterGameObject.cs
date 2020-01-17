using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameProjectCode.Objects
{
    class MonsterGameObject : MoveableGameObject, ICollidable, IAnimated, IDamagable, IKillable
    {
        protected Rectangle _collisionRectangle;
        private Vector2 _dimension;
        protected Animation LeftAnimation;
        protected Animation RightAnimation;
        private bool _isAlive;
        protected MovementPatern MovementPatern;
        protected int power;
        protected double _timer;
        public MonsterGameObject(Dictionary<string, Animation> animations, Animation animation, MovementPatern movementPatern, int Power, Animation LeftAnimation, Animation RightAnimation, int BaseHP = 3, float Speed = 0.15F) : base(animations, animation, Speed)
        {
            MovementPatern = movementPatern;
            power = Power;
            this.RightAnimation = RightAnimation;
            this.LeftAnimation = LeftAnimation;
            HP = BaseHP;
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
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }

        public void Collide(IHasCollision o)
        {
            if (o is PlayerGameObject)
            {
                actionManager.DealDamage(o as GameObject, power);

            }
        }

        public void Damage(int damage)
        {
            HP -= damage;
            Die();
        }

        public void ResolveCollisions()
        {
           //Nothing to do yet 
        }

        public void SetAnimations()
        {
            switch (MovementPatern.GetMovement())
            {
                case Movement.RIGHT:
                    _animationManager.Play(RightAnimation);
                    break;
                case Movement.LEFT:
                    _animationManager.Play(LeftAnimation);
                    break;
                case Movement.JUMP:
                    _animationManager._animation.CurrentFrame = 1;
                    break;
                case Movement.JUMPLEFT:
                    _animationManager.Play(LeftAnimation);
                    _animationManager._animation.CurrentFrame = 1;
                    break;
                case Movement.JUMPRIGHT:
                    _animationManager.Play(RightAnimation);
                    _animationManager._animation.CurrentFrame = 1;
                    break;
                default:
                    break;
            }
        }

        protected override void draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                base.draw(spriteBatch);

            }
        }

        protected override void Move()
        {
            switch (MovementPatern.GetMovement())
            {
                case Movement.RIGHT:
                    Velocity.X += Speed;
                    break;
                case Movement.LEFT:
                    Velocity.X -= Speed;
                    break;
                case Movement.JUMPRIGHT:
                    Velocity.X += Speed;
                    break;
                case Movement.JUMPLEFT:
                    Velocity.X -= Speed;
                    break;
                default:
                    break;
            }
        }

        protected override void update(GameTime gametime)
        {
            if (IsAlive)
            {
                base.update(gametime);
                _timer += gametime.ElapsedGameTime.TotalSeconds;
                if (_timer > 1)
                {
                    _timer = 0;
                    MovementPatern.Next();
                }
                SetAnimations();
            }
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}
