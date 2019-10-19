using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    interface ICollidable
    {
        Rectangle CollisionRectangle { get; }
        Vector2 Position { get; set; }
        Vector2 Dimenion { get; }
        void Collide(ICollidable o);
    }
}
