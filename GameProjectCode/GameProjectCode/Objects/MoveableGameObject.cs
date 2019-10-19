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
    abstract class MoveableGameObject : GameObject
    {
        public Vector2 Velocity;
        public float Speed = 1.5f;

        protected abstract void Move();

        protected MoveableGameObject(Dictionary<string, Animation> animations):base(animations)
        {
        }

        public override void Update(GameTime gametime, List<GameObject> objects)
        {
            Move();

            base.Update(gametime, objects);

            Position += Velocity;
        }
    }
}
