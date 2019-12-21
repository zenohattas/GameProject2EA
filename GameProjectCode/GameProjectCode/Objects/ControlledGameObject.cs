using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;

namespace GameProjectCode.Objects
{
    class ControlledGameObject : MoveableGameObject
    {
        public Input Input;
        public ControlledGameObject(Dictionary<string, Animation> animations, float Speed = 0.15f) : base(animations, Speed) { }

        protected override void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = Speed;
        }
    }
}
