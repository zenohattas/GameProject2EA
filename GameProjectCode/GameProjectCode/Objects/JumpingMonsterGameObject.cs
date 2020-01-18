using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Objects
{
    class JumpingMonsterGameObject : MonsterGameObject, ICanFall, ICanJump
    {
        Vector2 tomove;
        bool collided;
        public JumpingMonsterGameObject(Dictionary<string, Animation> animations, Animation LeftAnimation, Animation RightAnimation, MovementPatern movementPatern, Vector2 position, int Power = 2, int BaseHP = 3, float Speed = 0.8F, float jumpHeight = 0.3f, float Gravity = 0.15f) : base(animations, LeftAnimation, RightAnimation, movementPatern, position, Power, BaseHP, Speed)
        {
            this.Gravity = Gravity;
            JumpHeight = jumpHeight;
            collided = false;
        }

        public float Gravity { get ; set; }
        public bool HasJumped { get; set; }

        public float JumpHeight { get; private set; }

        public bool IsGrounded { get; set; }
        public bool Collided { get; set; }

        public override void Collide(IHasCollision o)
        {
            base.Collide(o);
            Vector2 movement = Actions.MoveObject((ICollidable)this, o);
            slow = DefaultSlowValue;

            if (movement.Y < 0)
            {
                IsGrounded = true;
                Velocity = new Vector2(Velocity.X,0);
            }
            if (movement.Y > 0 && Velocity.Y < 0)
                Velocity = new Vector2(Velocity.X,0);

            if (o is PlayerGameObject)
            {
                movement.X = 0;
            }

            tomove = movement;
            //Position += movement;
        }
        public override void ResolveCollisions()
        {
            base.ResolveCollisions();
            Position = tomove;
        }
        public void Fall()
        {
            Velocity += new Vector2(0,Gravity);
        }

        public void Jump()
        {
            Velocity += new Vector2(JumpHeight, 0);
            IsGrounded = false;
        }
        

        protected override void Move()
        {
            base.Move();
            if (IsGrounded)
            {
                switch (MovementPatern.GetMovement())
                {
                    case Movement.RIGHT:
                        break;
                    case Movement.LEFT:
                        break;
                    case Movement.JUMP:
                        Jump();
                        break;
                    case Movement.JUMPLEFT:
                        Jump();
                        break;
                    case Movement.JUMPRIGHT:
                        Jump();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Fall();
            }
        }
        protected override void update(GameTime gametime)
        {
            base.update(gametime);
            if (!Collided)
            {
                IsGrounded = false;
            }
            Collided = false;
        }
    }
}
