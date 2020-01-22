using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProjectCode.Objects
{
    abstract class MoveableGameObject : GameSpriteObject
    {
        protected Vector2 _velocity;
        public virtual Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                if (Math.Abs(value.X) > MaxVelocity.X)
                {
                    if (Math.Abs(value.Y) > MaxVelocity.Y)
                    {
                        if (value.Y < 0)
                        {
                            if (value.X < 0)
                            {
                                _velocity = -MaxVelocity;
                            }
                            else{
                                _velocity = new Vector2(MaxVelocity.X, -MaxVelocity.Y);
                            }
                        }
                        else if (value.X < 0)
                        {
                            _velocity = new Vector2(-MaxVelocity.X, MaxVelocity.Y);
                        }
                        else
                        {
                            _velocity = MaxVelocity;
                        }
                    }
                    else
                    {
                        if (value.X < 0)
                        {
                            _velocity = new Vector2(-MaxVelocity.X, value.Y);
                        }
                        else
                        {
                            _velocity = new Vector2(MaxVelocity.X, value.Y);
                        }
                    }
                }
                else if (Math.Abs(value.Y) > MaxVelocity.Y)
                {
                    if (value.Y < 0)
                    {
                        _velocity = new Vector2(value.X, -MaxVelocity.Y);
                    }
                    else
                    {
                        _velocity = new Vector2(value.X, MaxVelocity.Y);
                    }
                }
                else
                {
                    _velocity = value;
                }
            }
        }
        public virtual Vector2 MaxVelocity { get; set; }
        public virtual Vector2 Speed { get { return new Vector2(speed * slow, 0); } }
        protected float speed;
        protected float slow;
        protected const float DefaultSlowValue = 1f;
        
        protected abstract void Move();

        protected MoveableGameObject(Dictionary<string, Animation> animations, Animation animation, float Speed = 0.15f , float maxVelocityX = 2f, float maxVelocityY = 0.20f):base(animations, animation)
        {
            speed = Speed;
            slow = 1f;
            MaxVelocity = new Vector2(maxVelocityX, maxVelocityY);
            _velocity = new Vector2(0,0);
        }

        protected override void update(GameTime gametime)
        {
            base.update(gametime);

            Move();

            Position += Velocity;
        }
    }
}
