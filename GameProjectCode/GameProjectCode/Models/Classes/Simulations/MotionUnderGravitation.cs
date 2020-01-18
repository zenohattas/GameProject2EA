using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models.Classes.Simulations
{
    /*
    class MotionUnderGravitation is derived from class Simulation
    It creates 1 mass with mass value 1 kg and sets its velocity to (10.0f, 15.0f, 0.0f) and its position to
    (-10.0f, 0.0f, 0.0f). The purpose of this application is to apply a gravitational force to the mass and
    observe the path it follows. The above velocity and position provides a fine projectile path with a
    9.81 m/s/s downward gravitational acceleration. 9.81 m/s/s is a very close value to the gravitational
    acceleration we experience on the earth.
    */
    class MotionUnderGravitation : Simulation
    {
        public Vector3D gravitation;                                                   //the gravitational acceleration

        public MotionUnderGravitation(Vector3D gravitation) : base(1, 1.0f)      //Constructor firstly constructs its super class with 1 mass and 1 kg
        {                                                                       //Vector3D gravitation, is the gravitational acceleration
            this.gravitation = gravitation;                                    //set this class's gravitation
            masses[0].pos = new Vector3D(-10.0f, 0.0f, 0.0f);                      //set the position of the mass
            masses[0].vel = new Vector3D(10.0f, 15.0f, 0.0f);                      //set the velocity of the mass
        }

        public override void solve()                                                    //gravitational force will be applied therefore we need a "solve" method.
        {
            for (int a = 0; a < numOfMasses; ++a)                               //we will apply force to all masses (actually we have 1 mass, but we can extend it in the future)
                masses[a].applyForce(gravitation * masses[a].m);              //gravitational force is as F = m * g. (mass times the gravitational acceleration)
        }

    }
}
