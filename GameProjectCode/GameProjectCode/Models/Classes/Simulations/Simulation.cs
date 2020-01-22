using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models.Classes.Simulations
{
    // class Simulation      ---> A container object for simulating masses
    class Simulation
    {
	    public int numOfMasses                                     // number of masses in this container
        {
            get
            {
                return masses.Count;
            }
        }
        public List<Mass> masses;                                   // masses are held by List of Mass

        public Simulation(int numOfMasses, float m)                        // Constructor creates some masses with mass values m
        {
            //this.numOfMasses = numOfMasses;

            masses = new List<Mass>();                              // Create an List container for Masses

            for (int count = 0; count < numOfMasses; ++count)       // We will step to every item in the list
                masses.Add(new Mass(m));                            // Create a Mass and put it in the list
        }

        public virtual void release()                               // delete the masses created
        {
            masses.Clear();
        }

        public Mass getMass(int index)
        {
            if (index < 0 || index >= numOfMasses)                  // if the index is not in the array
                return null;                                        // then return NULL
                
            return masses[index];                                   // get the mass at the index
        }

        public virtual void init()                                  // this method will call the init() method of every mass
        {
            foreach (Mass mass in masses)
            {
                mass.init();
            }                                                       // call init() method of the mass
        }

        public virtual void solve()                                 // no implementation because no forces are wanted in this basic container
        {
                                                                    // in advanced containers, this method will be overrided and some forces will act on masses
        }

        public virtual void simulate(float dt)                      // Iterate the masses by the change in time
        {
            foreach (Mass mass in masses)                           // We will iterate every mass
            {
                mass.simulate(dt);                                  // Iterate the mass and obtain new position and new velocity
            }                  
        }

        public virtual void operate(float dt)                       // The complete procedure of simulation
        {
            init();                                                 // Step 1: reset forces to zero
            solve();                                                // Step 2: apply forces
            simulate(dt);                                           // Step 3: iterate the masses by the change in time
        }

    };
}
