﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    interface IDamagable
    {
        int HP { get; set; }
        void Damage(int damage);
    }
}
