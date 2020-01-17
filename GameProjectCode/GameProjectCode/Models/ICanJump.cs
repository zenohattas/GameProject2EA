using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    interface ICanJump : IGrounded
    {
        float JumpHeight { get; }
        bool HasJumped { get; set; }
        void Jump();
    }
}
