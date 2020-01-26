using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;
using GameProjectCode.Models.Interfaces;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Objects
{
    class FallingMonsterGameObject : MonsterGameObject, IHasGravity
    {
        bool Collided;
        bool IsGrounded;
        public FallingMonsterGameObject(Dictionary<string, Animation> animations, Animation LeftAnimation, Animation RightAnimation, MovementPatern movementPatern, Vector2 position, int Power = 1, int BaseHP = 3, float Speed = 1, float scale = 1, float gravity = 0.15f) : base(animations, LeftAnimation, RightAnimation, movementPatern, position, Power, BaseHP, Speed, scale)
        {
            Gravity = gravity;
            Collided = false;
            IsGrounded = false;
        }

        public float Gravity { get ; set; }
        public override void Collide(IHasCollision o)
        {
            base.Collide(o);

            if (o is ICollidable)
            {
                Collided = true;
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
            if (!IsGrounded)
            {
                Fall();
            }
        }
        public void Fall()
        {
            Velocity += new Vector2(0, Gravity);
        }
    }
}
