using GameProjectCode.Manager;
using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Objects
{
    class StageExitGameObject : BoundryObject, ICanCollide
    {
        StageManager stageManager;
        StageExitGameObject LinkedStageExitGameObject;
        public int StageNumber;
        public string ID;
        public bool ExitRight;

        public StageExitGameObject(Rectangle CollisionRectangle, string ID, bool exitRight) : base(CollisionRectangle)
        {
            this.ID = ID;
            ExitRight = exitRight;
        }
        public void SetStageNumber(int stageNumber)
        {
            StageNumber = stageNumber;
        }
        public void LinkTo(StageExitGameObject stageExit)
        {
            LinkedStageExitGameObject = stageExit;
        }
        public void SetStageManager(StageManager stageManager)
        {
            this.stageManager = stageManager;
        }
        public void Initialize(StageManager stageManager, StageExitGameObject stageExit, int stageNumber)
        {
            StageNumber = stageNumber;
            LinkedStageExitGameObject = stageExit;
            this.stageManager = stageManager;
        }
        public void Collide(IHasCollision o)
        {
            if (o is PlayerGameObject)
            {
                ChangeStage(o as PlayerGameObject);
            }    
        }

        private void ChangeStage(PlayerGameObject player)
        {
            stageManager.SelectedStage = LinkedStageExitGameObject.StageNumber;
            if (LinkedStageExitGameObject.ExitRight)
            {
                player.Position = LinkedStageExitGameObject.Position + new Vector2(LinkedStageExitGameObject.Dimenions.X*2, 0);
            }
            else
            {
                player.Position = LinkedStageExitGameObject.Position - new Vector2(player.Dimenions.X*2, 0);
            }
        }

        public void ResolveCollisions()
        {
            
        }
    }
}
