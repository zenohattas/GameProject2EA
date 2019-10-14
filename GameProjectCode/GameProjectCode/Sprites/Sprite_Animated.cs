using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Sprites
{
    class Sprite_Animated : Sprite_Base
    {
        public Sprite_Animated(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }
             

        public override Vector2 Position
        {
            get => base.Position;
            set
            {
                base.Position = value;
                if (_animationManager != null)
                {
                    _animationManager.Position = _position;
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            _animationManager.Draw(spriteBatch);
        }

        public override void Update(GameTime gametime, List<Sprite_Base> sprites)
        {
            Move();

            SetAnimations();

            _animationManager.Update(gametime);

            Position += Velocity;

            Velocity = Vector2.Zero;
        }

        protected override void Move()
        {
            //No Ai implemented yet.
        }

        protected override void SetAnimations()
        {
            if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else
                _animationManager.Stop();
        }
    }
}
