﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    interface ILiquid: IHasCollision
    {
        float Density { get; }
    }
}
