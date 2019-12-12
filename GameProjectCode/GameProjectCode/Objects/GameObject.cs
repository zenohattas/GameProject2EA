using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Objects
{
    abstract class GameObject
    {
        protected Vector2 _position;

        public virtual Vector2 Position { get { return _position; } set { _position = value; } }
    }
}
