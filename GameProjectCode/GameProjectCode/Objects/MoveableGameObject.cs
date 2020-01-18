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
        public virtual Vector2 Velocity { get; set; }
        public Vector2 Speed { get { return new Vector2(speed * slow, 0); } }
        protected float speed;
        protected float slow;
        protected const float DefaultSlowValue = 1f;
        
        protected abstract void Move();

        protected MoveableGameObject(Dictionary<string, Animation> animations, Animation animation, float Speed = 0.15f):base(animations, animation)
        {
            speed = Speed;
            slow = 1f;
        }

        protected override void update(GameTime gametime)
        {
            base.update(gametime);

            Move();

            Position += Velocity;
        }
    }
}
