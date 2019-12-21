﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    interface IInteractable : ICollidable
    {
        void Collide(ICollidable o);
        void ResolveCollisions();
    }
}
