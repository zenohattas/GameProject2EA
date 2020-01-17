using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class MovementPatern
    {
        List<Movement> movements;
        int currMovement;

        public MovementPatern(List<Movement> movements)
        {
            this.movements = movements;
        }
        public void Next()
        {
            currMovement++;
            if (currMovement >= movements.Count)
            {
                currMovement = 0;
            }
        }
        public Movement GetMovement()
        {
            return movements[currMovement];
        }

    }
    enum Movement
    {
        RIGHT,
        LEFT,
        JUMP,
        JUMPLEFT,
        JUMPRIGHT
    }
}
