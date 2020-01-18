using GameProjectCode.Extensions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models.Classes.Simulations
{
    /*
  class RopeSimulation is derived from class Simulation (see Physics1.h). It simulates a rope with 
  point-like particles binded with springs. The springs have inner friction and normal length. One tip of 
  the rope is stabilized at a point in space called "Vector3D ropeConnectionPos". This point can be
  moved externally by a method "void setRopeConnectionVel(Vector3D ropeConnectionVel)". RopeSimulation 
  creates air friction and a planer surface (or ground) with a normal in +y direction. RopeSimulation 
  implements the force applied by this surface. In the code, the surface is refered as "ground".
*/
    class RopeSimulation : Simulation               //An object to simulate a rope interacting with a planer surface and air
    {
        public List<Spring> springs;                                   //Springs binding the masses (there shall be [numOfMasses - 1] of them)

        public Vector3D gravitation;                               //gravitational acceleration (gravity will be applied to all masses)

        public Vector3D ropeConnectionPos;                         //A point in space that is used to set the position of the 
                                                                   //first mass in the system (mass with index 0)

        public Vector3D ropeConnectionVel;                         //a variable to move the ropeConnectionPos (by this, we can swing the rope)

        float springConstant;                                       //3. how stiff the springs are

        float springLength;                                         //4. the length that a spring does not exert any force

        float springFrictionConstant;                               //5. inner friction constant of spring

        public bool IsConnected;

        float m;

        public float groundRepulsionConstant;                      //a constant to represent how much the ground shall repel the masses

        public float groundFrictionConstant;                       //a constant of friction applied to masses by the ground
                                                            //(used for the sliding of rope on the ground)

        public float groundAbsorptionConstant;                     //a constant of absorption friction applied to masses by the ground
                                                            //(used for vertical collisions of the rope with the ground)

        public float airFrictionConstant;                          //a constant of air friction applied to masses

        public Rectangle ropeConnectionRectangle
        {
            get
            {
                return new Rectangle(masses[0].Position.ToPoint(), new Point(1));
            }
        }

        public RopeSimulation(                                     //a long long constructor with 11 parameters starts here
            int numOfMasses,                                //1. the number of masses
            float m,                                        //2. weight of each mass
            float springConstant,                           //3. how stiff the springs are
            float springLength,                             //4. the length that a spring does not exert any force
            float springFrictionConstant,                   //5. inner friction constant of spring
            Vector3D gravitation,                           //6. gravitational acceleration
            float airFrictionConstant,                      //7. air friction constant
            float groundRepulsionConstant,                  //8. ground repulsion constant
            float groundFrictionConstant,                   //9. ground friction constant
            float groundAbsorptionConstant,                 //10. ground absorption constant
            bool IsConnected = false
            ) : base(numOfMasses, m)                  //The super class creates masses with weights m of each
        {
            this.gravitation = gravitation;

            this.airFrictionConstant = airFrictionConstant;

            ropeConnectionPos = new Vector3D();
            ropeConnectionVel = new Vector3D();

            this.springConstant = springConstant;
            this.springFrictionConstant = springFrictionConstant;
            this.springLength = springLength;

            this.IsConnected = IsConnected;
            this.m = m;

            this.groundFrictionConstant = groundFrictionConstant;
            this.groundRepulsionConstant = groundRepulsionConstant;
            this.groundAbsorptionConstant = groundAbsorptionConstant;

            masses = new List<Mass>();

            for (int index = 0; index < numOfMasses; ++index)           //To set the initial positions of masses loop with for(;;)
            {
                masses.Add(new Mass(m));
                masses[index].pos.x = index * springLength;             //Set x position of masses[a] with springLength distance to its neighbor
                masses[index].pos.y = 0;                                //Set y position as 0 so that it stand horizontal with respect to the ground
                masses[index].pos.z = 0;                                //Set z position as 0 so that it looks simple
            }

            springs = new List<Spring>();                               //create list for springs
                                                                        //(springs are necessary for numOfMasses)

            for (int index = 0; index < numOfMasses - 1; ++index)       //to create each spring, start a loop
            {
                //Create the spring with index "a" by the mass with index "a" and another mass with index "a + 1".
                springs.Add(new Spring(masses[index], masses[index + 1],
                    springConstant, springLength, springFrictionConstant));
            }
        }

        public override void release()                                           //release() is overriden because we have springs to delete
        {
            base.release();                                             //Have the super class release itself

            springs.Clear();                                            //to delete all springs
        }

        public override void solve()                                        //solve() is overriden because we have forces to be applied
        {
            for (int index = 0; index < numOfMasses - 1; ++index)       //apply force of all springs
            {
                springs[index].solve();                        //Spring with index "a" should apply its force
            }

            for (int index = 0; index < numOfMasses; ++index)               //Start a loop to apply forces which are common for all masses
            {
                masses[index].applyForce(gravitation * masses[index].m);              //The gravitational force

                masses[index].applyForce(-masses[index].vel * airFrictionConstant);   //The air friction

                if (Math.Abs(masses[index].IntersectionDepth.X) > 0 || Math.Abs(masses[index].IntersectionDepth.Y) > 0)        //Forces from the ground are applied if a mass collides with the ground
                {
                    Vector3D v;                             //A temporary Vector3D

                    v = masses[index].vel;                     //get the velocity
                    v.y = 0;                                //omit the velocity component in y direction

                    //The velocity in y direction is omited because we will apply a friction force to create
                    //a sliding effect. Sliding is parallel to the ground. Velocity in y direction will be used
                    //in the absorption effect.
                    masses[index].applyForce(-v * groundFrictionConstant);     //ground friction force is applied

                    v = masses[index].vel;                     //get the velocity
                    v.x = 0;                                //omit the x and z components of the velocity
                    v.z = 0;                                //we will use v in the absorption effect

                    //above, we obtained a velocity which is vertical to the ground and it will be used in
                    //the absorption force

                    if (v.y < 0)                            //let's absorb energy only when a mass collides towards the ground
                        masses[index].applyForce(-v * groundAbsorptionConstant);       //the absorption force is applied

                    //The ground shall repel a mass like a spring.
                    //By "Vector3D(0, groundRepulsionConstant, 0)" we create a vector in the plane normal direction
                    //with a magnitude of groundRepulsionConstant.
                    //By (groundHeight - masses[a].pos.y) we repel a mass as much as it crashes into the ground.
                    Vector3D force = new Vector3D(groundRepulsionConstant * masses[index].IntersectionDepth.X, groundRepulsionConstant * masses[index].IntersectionDepth.Y, 0);

                    masses[index].applyForce(force);           //The ground repulsion force is applied
                }

            }


        }

        public override void simulate(float dt)                             //simulate(float dt) is overriden because we want to simulate
                                                            //the motion of the ropeConnectionPos
        {
            base.simulate(dt);                              //the super class shall simulate the masses

            if (IsConnected)
            {
                if (ropeConnectionVel.x * dt < masses[0].IntersectionDepth.X)         //ropeConnectionPos shall not go under the ground
                {
                    ropeConnectionPos.x += masses[0].IntersectionDepth.X;
                    ropeConnectionVel.x = 0;
                }
                else
                {
                    ropeConnectionPos.x += ropeConnectionVel.x * dt;    //iterate the positon of ropeConnectionPos
                }
                if (ropeConnectionVel.y * dt < masses[0].IntersectionDepth.Y)
                {
                    ropeConnectionPos.y += masses[0].IntersectionDepth.Y;
                    ropeConnectionVel.y = 0;
                }
                else
                {
                    ropeConnectionPos.y += ropeConnectionVel.y * dt;    //iterate the positon of ropeConnectionPos
                }
                masses[0].pos = ropeConnectionPos;             //mass with index "0" shall position at ropeConnectionPos
                masses[0].vel = ropeConnectionVel;             //the mass's velocity is set to be equal to ropeConnectionVel
            }
        }

        public override void operate(float dt)
        {
            base.operate(dt);
            foreach (Mass mass in masses)
            {
                mass.IntersectionDepth = new Microsoft.Xna.Framework.Vector2(0, 0);
            }
        }

        public void setRopeConnectionVel(Vector3D ropeConnectionVel)   //the method to set ropeConnectionVel
        {
            this.ropeConnectionVel = ropeConnectionVel;
        }
        public void AddMass()
        {
            masses.Insert(masses.Count-1,new Mass(m,masses[masses.Count-1].Position));                               //Adds a ellement before the last ellement in the rope
            springs.Last<Spring>().mass2 = masses[masses.Count-2];
            springs.Add(new Spring(masses[masses.Count-2], masses[masses.Count-1],
                    springConstant, springLength, springFrictionConstant));
        }
        public void RemoveMass()
        {
            if (masses.Count > 2)
            {
                masses.RemoveAt(masses.Count - 2);                                        //Remove the second to last ellement van de rope           
                springs.RemoveAt(springs.Count - 1);
                if (springs.Count > 1 )
                {
                    springs[springs.Count - 1].mass2 = masses.Last<Mass>();
                }
            }
        }
    }
}
