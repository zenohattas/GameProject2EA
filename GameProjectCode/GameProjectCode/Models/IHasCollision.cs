using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    interface IHasCollision
    {
        Rectangle CollisionRectangle { get; }
        Vector2 Position { get; set; }
        Vector2 Dimenions { get; }
    }
}
