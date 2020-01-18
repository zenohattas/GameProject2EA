using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class Timer
    {
        protected float _time;
        public float Time
        {
            get
            {
                return _time * (int)GameSpeed.Speed;
            }
            set
            {
                _time = value;
            }
        } 
    }
}
