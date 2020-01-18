using GameProjectCode.Models;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class CollisionManager
    {
        public List<IHasCollision> GetCollidableList(List<GameObject> sprites)
        {
            List<IHasCollision> collidableSprites = new List<IHasCollision>();
            foreach (var sprite in sprites)
            {
                if (sprite is IHasCollision)
                {
                    collidableSprites.Add(sprite as IHasCollision);
                }
            }
            return collidableSprites;
        }

        /// <summary>
        /// Detects overlap between ICollidables.
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public bool DetectCollision(IHasCollision o1, IHasCollision o2)
        {
            if (o1.CollisionRectangle.Intersects(o2.CollisionRectangle))
                return true;
            return false;
        }

        /// <summary>
        /// Detects and executes all collision functions of the objects that collide with eachother.
        /// </summary>
        /// <param name="sprites"></param>
        public void DetectCollisions(List<GameObject> sprites)
        {
            List<IHasCollision> collidables = GetCollidableList(sprites);
            for (int i = 0; i < collidables.Count; i++)
            {
                if (collidables[i] is ICollidable)
                {
                    for (int j = 0; j < collidables.Count; j++)
                    {
                        if (i != j)
                        {
                            if (DetectCollision(collidables[i], collidables[j]))
                            {
                                    ICollidable x = collidables[i] as ICollidable;
                                    x.Collide(collidables[j]);
                                    if (collidables[j] is ICollidable)
                                    {
                                        ICollidable y = collidables[i] as ICollidable;
                                        y.Collide(collidables[i]);
                                    }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Calculates the side of the collision. Returns 0 if a side doesn't collide.
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public Rectangle GetCollisionEdge(ICollidable o1, ICollidable o2)
        {
            Rectangle collisionSide = new Rectangle();

            //Left side collides of o2
            if (o1.Position.X + o1.Dimenions.X > o2.Position.X && o1.Position.X < o2.Position.X)
            {
                collisionSide.X--;    
            }
            //Right side collides of o2
            if (o2.Position.X + o2.Dimenions.X > o1.Position.X && o2.Position.X < o1.Position.X)
            {
                collisionSide.X++;
            }
            //Bottom side collides of o2
            if (o2.Position.Y + o2.Dimenions.Y > o1.Position.Y && o2.Position.Y < o1.Position.Y)
            {
                collisionSide.Y--;
            }
            //Top side collides of o2
            if (o2.Position.Y < o1.Position.Y + o1.Dimenions.Y && o2.Position.Y > o1.Position.Y)
            {
                collisionSide.Y++;
            }

            return collisionSide;
        }
    }
}
