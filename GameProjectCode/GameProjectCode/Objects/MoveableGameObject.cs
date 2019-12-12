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
        public Vector2 Velocity;
        public float Speed { get { return speed * slow; } }
        protected float speed;
        protected float slow;
        protected float gravity;
        protected ActionManager actionManager;
        protected const float DefaultSlowValue = 1f;
        
        protected abstract void Move();

        protected MoveableGameObject(Dictionary<string, Animation> animations, float Speed = 0.15f, float Gravity = 0.15f):base(animations)
        {
            actionManager = new ActionManager();
            speed = Speed;
            slow = 1f;
            gravity = Gravity;
        }

        protected override void update(GameTime gametime)
        {
            Move();

            base.update(gametime);

            Position += Velocity;
        }
    }
}
