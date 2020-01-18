using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Objects
{
    class BoundryObject : GameObject, IHasCollision
    {
        private Rectangle collisionRectangle;
        private Vector2 position;
        private Vector2 dimensions;

        public BoundryObject(Rectangle CollisionRectangle) : base()
        {
            collisionRectangle = CollisionRectangle;
        }

        public Rectangle CollisionRectangle => collisionRectangle;

        public override Vector2 Position
        {
            get
            {
                position.X = collisionRectangle.X;
                position.Y = collisionRectangle.Y;
                return position;
            }
            set
            {
                collisionRectangle.X = (int)value.X;
                collisionRectangle.Y = (int)value.Y;
                position = value;
            }
        }

        public Vector2 Dimenions
        {
            get
            {
                dimensions.X = collisionRectangle.Width;
                dimensions.Y = collisionRectangle.Height;
                return dimensions;
            }
        }
    }
}
