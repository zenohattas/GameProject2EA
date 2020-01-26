using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Models
{
    class Mass : ICanCollide
    {
        public float m;                                    // The mass value
        public Vector3D pos;                               // Position in space
        public Vector3D vel;                               // Velocity
        public Vector3D force;                             // Force applied on this mass at an instance
        public Vector2 IntersectionDepth;

        public Mass(float m)                               // Constructor
        {
            this.m = m;
            pos = new Vector3D();
            vel = new Vector3D();
            force = new Vector3D();
            Dimenions = new Vector2(0);
            IntersectionDepth = new Vector2();

        }
        public Mass(float m, Vector3D position)                               // Constructor
        {
            this.m = m;
            pos = position;
            vel = new Vector3D();
            force = new Vector3D();
            Dimenions = new Vector2(0);
            IntersectionDepth = new Vector2();

        }
        public Mass(float m, Vector2 dimensions)                               // Constructor
        {
            this.m = m;
            pos = new Vector3D();
            Dimenions = dimensions;
            vel = new Vector3D();
            force = new Vector3D();
            IntersectionDepth = new Vector2();
        }
        public Mass(float m, Vector3D position, Vector3D velocity)                               // Constructor
        {
            this.m = m;
            pos = position;
            vel = velocity;
            force = new Vector3D();
            Dimenions = new Vector2(0);
            IntersectionDepth = new Vector2();
        }

        public Rectangle CollisionRectangle => new Rectangle(Position.ToPoint(), Dimenions.ToPoint());
        public Vector2 Position 
        {
            get
            {
                return new Vector2(pos.x, pos.y);
            }
            set 
            {
                pos.x = value.X;
                pos.y = value.Y;
            }
        }

        public Vector2 Dimenions { get; set; }

        /*
          void applyForce(Vector3D force) method is used to add external force to the mass. 
          At an instance in time, several sources of force might affect the mass. The vector sum 
          of these forces make up the net force applied to the mass at the instance.
        */
        public void applyForce(Vector3D force)
        {
            this.force += force;                   // The external force is added to the force of the mass
        }

        public void Collide(IHasCollision o)
        {
            Vector2 depth = Actions.MoveObject(this, o);
            if (Math.Abs(depth.X) > Math.Abs(IntersectionDepth.X))
            {
                IntersectionDepth.X = depth.X;
            }
            if (Math.Abs(depth.Y) > Math.Abs(IntersectionDepth.Y))
            {
                IntersectionDepth.Y = depth.Y;
            }
        }

        /*
          void init() method sets the force values to zero
        */
        public void init()
        {
            force.x = 0;
            force.y = 0;
            force.z = 0;
        }

        public void ResolveCollisions()
        {
            
        }

        /*
          void simulate(float dt) method calculates the new velocity and new position of 
          the mass according to change in time (dt). Here, a simulation method called
          "The Euler Method" is used. The Euler Method is not always accurate, but it is 
          simple. It is suitable for most of physical simulations that we know in common 
          computer and video games.
        */
        public void simulate(float dt)
        {
            vel += (force / m) * dt;                // Change in velocity is added to the velocity.
                                                    // The change is proportinal with the acceleration (force / m) and change in time

            pos += vel * dt;                        // Change in position is added to the position.
                                                    // Change in position is velocity times the change in time
        }
    }
}
