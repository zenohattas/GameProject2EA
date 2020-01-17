using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;

namespace GameProjectCode.Objects
{
    class JumpingMonsterGameObject : MonsterGameObject, ICanFall, ICanJump
    {
        public JumpingMonsterGameObject(Dictionary<string, Animation> animations, Animation LeftAnimation, Animation RightAnimation, MovementPatern movementPatern, int Power = 2, int BaseHP = 3, float Speed = 0.15F, float jumpHeight = 0.3f, float Gravity = 0.15f) : base(animations, LeftAnimation, RightAnimation, movementPatern, Power,  BaseHP, Speed)
        {
            this.Gravity = Gravity;
            JumpHeight = jumpHeight;
        }

        public float Gravity { get ; set; }
        public bool HasJumped { get; set; }

        public float JumpHeight { get; private set; }

        public bool IsGrounded { get; set; }

        public void Fall()
        {
            Velocity.Y += Gravity;
        }

        public void Jump()
        {
            Velocity.Y += JumpHeight;
            IsGrounded = false;
        }

        protected override void Move()
        {
            base.Move();
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
    }
}
