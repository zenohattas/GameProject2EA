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
    class BlockTransparentGameObject : GameSpriteObject
    {
        public BlockTransparentGameObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation)
        {
            Position = position;
        }

        public override Vector2 Position { get => base.Position; set => base.Position = value; }
        

        protected override void update(GameTime gametime)
        {
            base.update(gametime);
        }
    }
}
