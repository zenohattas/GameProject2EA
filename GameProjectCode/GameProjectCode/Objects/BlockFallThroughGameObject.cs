using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Objects
{
    class BlockFallThroughGameObject : BlockSolidGameObject, IFallThrough
    {
        public BlockFallThroughGameObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation, position) { }
    }
}
