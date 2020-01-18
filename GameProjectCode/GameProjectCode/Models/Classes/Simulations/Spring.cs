using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models.Classes.Simulations
{
    class Spring                                            //An object to represent a spring with inner friction binding two masses. The spring
                                                            //has a normal length (the length that the spring does not exert any force)
    {
        public Mass mass1;                                        //The first mass at one tip of the spring
        public Mass mass2;                                        //The second mass at the other tip of the spring

        public float springConstant;                               //A constant to represent the stiffness of the spring
        public float springLength;                                 //The length that the spring does not exert any force
        public float frictionConstant;                             //A constant to be used for the inner friction of the spring

        public Spring(Mass mass1, Mass mass2,
            float springConstant, float springLength, float frictionConstant)       //Constructor
        {
            this.springConstant = springConstant;                                  //set the springConstant
            this.springLength = springLength;                                      //set the springLength
            this.frictionConstant = frictionConstant;                              //set the frictionConstant

            this.mass1 = mass1;                                                    //set mass1
            this.mass2 = mass2;                                                    //set mass2
        }

        public void solve()                                                                    //solve() method: the method where forces can be applied
        {
            Vector3D springVector = mass1.pos - mass2.pos;                            //vector between the two masses

            float r = springVector.length();                                            //distance between the two masses

            Vector3D force = new Vector3D();                                                             //force initially has a zero value

            if (r != 0)                                                                 //to avoid a division by zero check if r is zero
                force += (springVector / r) * (r - springLength) * (-springConstant);   //the spring force is added to the force

            force += -(mass1.vel - mass2.vel) * frictionConstant;                     //the friction force is added to the force
                                                                                        //with this addition we obtain the net force of the spring

            mass1.applyForce(force);                                                   //force is applied to mass1
            mass2.applyForce(-force);                                                  //the opposite of force is applied to mass2
        }

    }
}
