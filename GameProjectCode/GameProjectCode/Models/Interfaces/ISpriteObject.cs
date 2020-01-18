using GameProjectCode.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    interface ISpriteObject
    {
        AnimationManager _animationManager { get; }
        Dictionary<string, Animation> _animations { get; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gametime);
    }
}
