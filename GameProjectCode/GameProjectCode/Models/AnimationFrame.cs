using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class AnimationFrame
    {
        public Rectangle Frame;

        public AnimationFrame(int x, int y , int width, int height)
        {
            Frame = new Rectangle(x, y, width, height);
        }
    }
}
