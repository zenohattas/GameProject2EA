using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;

namespace GameProjectCode.Objects
{
    class EndGameObject : BlockSolidGameObject, ICanCollide
    {
        private StageManager stageManager;
        public EndGameObject(Dictionary<string, Animation> animations, Animation animation, Vector2 position) : base(animations, animation, position)
        {
        }
        public void LoadStagemanager(StageManager stageManager)
        {
            this.stageManager = stageManager;
        }
        public void Collide(IHasCollision o)
        {
            if (o is PlayerGameObject)
            {
                stageManager.SelectedStage = -1;
                stageManager.menuManager.ShowWinScreen();
            }
        }

        public void ResolveCollisions()
        {
            
        }
    }
}
