using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Objects
{
    class BlockLiquidGameObject : BlockSolidGameObject, ILiquid
    {
        private float _density;
        public float Density { get { return _density; } }
        public BlockLiquidGameObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position, float density = 0.1f) : base(animations, animation, position)
        {
            _density = density;
        }
    }
}
