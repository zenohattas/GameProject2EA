using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    static class GameSpeed
    {
        static GameSpeed()
        {
            Speed = Speed.NORMAL;
        }
        static public Speed Speed { get; set; }
    }
    enum Speed
    {
        NORMAL = 1,
        FAST,
        FASTER,
        FASTEST
    }
}
