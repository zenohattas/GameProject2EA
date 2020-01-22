using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models.Classes.Simulations
{
    //Grapplinghook is basiscly a Ropesimulator with a heavier attachment point. This point will be the last ellement if the grapplingHook is not attached and will be the first if the grapplingHook is attached 
    class GrapplingHookSimulation : RopeSimulation
    {
        public GrapplingHookSimulation( Mass AttachedOrigin, float m, float massOfHook, float springConstant, float springLength, float springFrictionConstant, Vector3D gravitation, float airFrictionConstant, float groundRepulsionConstant, float groundFrictionConstant, float groundAbsorptionConstant, int numOfMasses = 0) : base(numOfMasses, m, springConstant, springLength, springFrictionConstant, gravitation, airFrictionConstant, groundRepulsionConstant, groundFrictionConstant, groundAbsorptionConstant)
        {
            masses.Insert(0, AttachedOrigin);
            masses.Insert(1, new Mass(massOfHook));

            springs.Insert(0,new Spring(AttachedOrigin, masses[1],
                    springConstant, springLength, springFrictionConstant));
            if (masses.Count > 2)
            {
                springs.Insert(0, new Spring(masses[1], masses[2],
                        springConstant, springLength, springFrictionConstant));

            }
        }
        public void Invert()
        {
            masses.Reverse();
            springs.Reverse();
        }
    }
}
