using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Objects
{
    class HudObject : GameSpriteObject
    {
        public bool ShouldUpdate { get; set; }
        private Animation _animation;
        public HudObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation)
        {
            _animation = animation;
            Position = position;
            ShouldUpdate = false;
        }
        public void Reset()
        {
            _animationManager.Reset();
        }

        protected override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
        }

        protected override void update(GameTime gametime)
        {
            if (ShouldUpdate)
            {
                base.update(gametime);
            }
        }
    }
}
