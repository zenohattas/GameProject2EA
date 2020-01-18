using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models.Classes.Simulations
{
    /*
    class MassConnectedWithSpring is derived from class Simulation
    It creates 1 mass with mass value 1 kg and binds the mass to an arbitrary constant point with a spring. 
    This point is refered as the connectionPos and the spring has a springConstant value to represent its 
    stiffness.
    */
    class MassConnectedWithSpring : Simulation
    {
        float springConstant;                                                   //more the springConstant, stiffer the spring force
        Vector3D connectionPos;                                                 //the arbitrary constant point that the mass is connected

        public MassConnectedWithSpring(float springConstant) : base(1, 1.0f)     //Constructor firstly constructs its super class with 1 mass and 1 kg
        {
            this.springConstant = springConstant;                              //set the springConstant

            connectionPos = new Vector3D(0.0f, -5.0f, 0.0f);                        //set the connectionPos

            masses[0].pos = connectionPos + new Vector3D(10.0f, 0.0f, 0.0f);       //set the position of the mass 10 meters to the right side of the connectionPos
            masses[0].vel = new Vector3D(0.0f, 0.0f, 0.0f);                        //set the velocity of the mass to zero
        }

        public override void solve()                                                    //the spring force will be applied
        {
            for (int count = 0; count < numOfMasses; ++count)                               //we will apply force to all masses (actually we have 1 mass, but we can extend it in the future)
            {
                Vector3D springVector = masses[count].pos - connectionPos;         //find a vector from the position of the mass to the connectionPos
                masses[count].applyForce(-springVector * springConstant);          //apply the force according to the famous spring force formulation
            }
        }

    }
}
