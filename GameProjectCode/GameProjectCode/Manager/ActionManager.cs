using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Manager
{
    class ActionManager
    {
        public Vector2 MoveObject(ICollidable toMove , ICollidable refference)
        {
           
            Vector2 movement = new Vector2();

            //Getting the collisiondepth
            Vector2 collisionDepth = GameProjectCode.Extensions.RectangleExtension.GetIntersectionDepth(toMove.CollisionRectangle, refference.CollisionRectangle);

            Vector2 collisionSide = new Vector2();

            //Left side collides of o2
            if (toMove.Position.X + toMove.Dimenions.X > refference.Position.X && toMove.Position.X < refference.Position.X)
            {
                collisionSide.X--;
            }
            //Right side collides of refference
            if (refference.Position.X + refference.Dimenions.X > toMove.Position.X && refference.Position.X < toMove.Position.X)
            {
                collisionSide.X++;
            }
            //Bottom side collides of refference
            if (refference.Position.Y + refference.Dimenions.Y > toMove.Position.Y && refference.Position.Y < toMove.Position.Y)
            {
                collisionSide.Y--;
            }
            //Top side collides of refference
            if (refference.Position.Y < toMove.Position.Y + toMove.Dimenions.Y && refference.Position.Y > toMove.Position.Y)
            {
                collisionSide.Y++;
            }

            //Collides with a corner
            if (collisionSide.Y!=0 && collisionSide.X != 0)
            {
                if (Math.Abs(collisionDepth.X) < Math.Abs(collisionDepth.Y))
                {
                    movement.X = collisionDepth.X;
                }
                if (Math.Abs(collisionDepth.X) > Math.Abs(collisionDepth.Y))
                {
                    movement.Y = collisionDepth.Y;
                }
                if (Math.Abs(collisionDepth.X) == Math.Abs(collisionDepth.Y))
                {
                    movement.Y = collisionDepth.Y;
                }
            }
            //Collides on a side
            else
            {
                if (collisionSide.X != 0)
                {
                    movement.X = collisionDepth.X;
                }
                if (collisionSide.Y != 0)
                {
                    movement.Y = collisionDepth.Y;
                }
            }

            //Touching left
            if (collisionDepth.X > 0 && toMove.Position.X + toMove.Dimenions.X > refference.Position.X + refference.Dimenions.X)
            {
                
            }
            //Touching right
            if (collisionDepth.X < 0 && toMove.Position.X < refference.Position.X)
            {
                
            }
            //Touching Top
            if (collisionDepth.Y > 0 && toMove.Position.Y + toMove.Dimenions.Y > refference.Position.Y + refference.Dimenions.Y)
            {
                
            }
            ////Touching Bottom
            if (collisionDepth.Y < 0 && toMove.Position.Y < refference.Position.Y)
            {
                
            }

            return movement;
        }
    }
}
