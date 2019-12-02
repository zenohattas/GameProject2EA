using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class DynamicBackground : Background
    {
        private float frameSpeed = 0.14f;
        public DynamicBackground(Texture2D texture, Rectangle rectangle) : base(texture, rectangle){ }
        public void Update()
        {
            //IMPLEMENT
        }
    }
}
