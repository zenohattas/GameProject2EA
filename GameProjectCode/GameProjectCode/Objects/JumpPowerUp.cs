using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Objects
{
    class JumpPowerUp : PowerUpGameObject
    {
        public JumpPowerUp(Dictionary<string, Animation> animations, Animation animation, Vector2 Position,float Scale) : base(animations, animation, Position, Scale)
        {
        }

        public override void GivePowerUp(PlayerGameObject player)
        {
            player.MaxJumps++;
        }
    }
}
