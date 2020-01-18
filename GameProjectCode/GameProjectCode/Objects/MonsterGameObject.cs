using GameProjectCode.Manager;
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
        protected Timer _timer;
        public MonsterGameObject(Dictionary<string, Animation> animations, Animation LeftAnimation, Animation RightAnimation, MovementPatern movementPatern, Vector2 position, int Power = 1, int BaseHP = 3, float Speed = 0.8F) : base(animations, LeftAnimation, Speed)
        {
            MovementPatern = movementPatern;
            power = Power;
            this.RightAnimation = RightAnimation;
            this.LeftAnimation = LeftAnimation;
            HP = BaseHP;
            IsAlive = true;
            Position = position;
            _timer = new Timer();
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

        public virtual void Collide(IHasCollision o)
        {
            if (o is PlayerGameObject)
            {
                Actions.DealDamage(o as GameObject, power);

            }
        }

        public void Damage(int damage)
        {
            HP -= damage;
            if (HP < 1)
            {
                Die();
            }
        }

        public virtual void ResolveCollisions()
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
                    Velocity += Speed;
                    break;
                case Movement.LEFT:
                    Velocity -= Speed;
                    break;
                case Movement.JUMPRIGHT:
                    Velocity += Speed;
                    break;
                case Movement.JUMPLEFT:
                    Velocity -= Speed;
                    break;
                default:
                    break;
            }
        }

        protected override void update(GameTime gametime)
        {
            if (IsAlive)
            {
                _timer.Time += (float)gametime.ElapsedGameTime.TotalSeconds;
                if (_timer.Time > 1)
                {
                    _timer.Time = 0;
                    MovementPatern.Next();
                }
                base.update(gametime);
                SetAnimations();
                Velocity = new Vector2(0, Velocity.Y);

            }
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}
