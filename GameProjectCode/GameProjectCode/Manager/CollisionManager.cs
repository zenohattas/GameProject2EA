using GameProjectCode.Models;
using GameProjectCode.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class CollisionManager
    {
        public List<ICollidable> GetCollidableList(List<GameObject> sprites)
        {
            List<ICollidable> collidableSprites = new List<ICollidable>();
            foreach (var sprite in sprites)
            {
                if (sprite is ICollidable)
                {
                    collidableSprites.Add(sprite as ICollidable);
                }
            }
            return collidableSprites;
        }
        public bool DetectCollision(ICollidable o1, ICollidable o2)
        {
            if (o1.CollisionRectangle.Intersects(o2.CollisionRectangle))
                return true;
            return false;
        }
    }
}
