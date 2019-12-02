using GameProjectCode.Models;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class StageManager
    {
        PlayerManager playerManager;
        public MenuManager Menu;
        List<Stage> Stages;
        public int SelectedStage { get; set; }

        public StageManager(MenuManager menuManager, PlayerManager playerManager)
        {
            Stages = new List<Stage>();
            Menu = menuManager;
            SelectedStage = -1;
            this.playerManager = playerManager;
        }
        public GameObject GetPlayer()
        {
            return playerManager.GetPlayer();
        }
        public void AddPlayer(GameObject player)
        {
            playerManager.AddPlayer(player);
        }
        public void AddStage(Stage stage)
        {
            Stages.Add(stage);
        }
        public List<GameObject> GetStage()
        {
            if(SelectedStage >= 0 && SelectedStage < Stages.Count)
            {
                List<GameObject> Stage = new List<GameObject>(Stages[SelectedStage].GameObjects);
                Stage.Add(playerManager.GetPlayer());
                return Stage;
            }
            return null;
        }
        public List<GameObject> GetStage(int stageLevel)
        {
            if (stageLevel >= 0 && stageLevel < Stages.Count)
                return Stages[stageLevel].GameObjects;
            return null;
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            switch (SelectedStage)
            {
                case -1:
                    Menu.Draw(spriteBatch, spriteFont);
                    break;
                case 0:
                    Stages[0].Draw(spriteBatch);
                    break;                        
                default:
                    Stages[0].Draw(spriteBatch);
                    break;
            }
            if (SelectedStage > -1)
                playerManager.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            if (SelectedStage == -1)
            {
                Menu.Update(gameTime, this);
            }
            else if (Stages.Count >= SelectedStage)
            {
                foreach (var sprite in Stages[SelectedStage].GameObjects)
                {
                    sprite.Update(gameTime);
                }
                playerManager.Update(gameTime);
            }
        }
        public void ResolveCollisions()
        {
            if (SelectedStage>= 0 && SelectedStage<Stages.Count)
            {
                foreach (GameObject o in Stages[SelectedStage].GameObjects)
                {
                    if (o is IInteractable)
                    {
                        IInteractable interactable = o as IInteractable;
                        interactable.ResolveCollisions();
                    }
                }
                playerManager.ResolveCollision();
            }
        }
    }
}
