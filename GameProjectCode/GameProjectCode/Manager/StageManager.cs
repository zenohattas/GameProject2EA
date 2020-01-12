using GameProjectCode.Models;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        public PlayerManager playerManager;
        public HudManager hudManager;
        SoundEffectManager soundEffectManager;
        public MenuManager menuManager;
        MusicManager musicManager;
        List<Stage> Stages;
        int prevStage;
        public int SelectedStage { get; set; }

        public StageManager(MenuManager menuManager, PlayerManager playerManager, SoundEffectManager soundEffectManager, MusicManager musicManager, HudManager hudManager)
        {
            Stages = new List<Stage>();
            this.menuManager = menuManager;
            SelectedStage = -1;
            prevStage = SelectedStage;
            this.playerManager = playerManager;
            this.soundEffectManager = soundEffectManager;
            this.musicManager = musicManager;
            this.hudManager = hudManager;
        }
        public GameObject GetPlayer()
        {
            return playerManager.GetPlayer();
        }
        public void AddPlayer(GameObject player)
        {
            playerManager.AddPlayer(player as GameSpriteObject);
        }
        public void AddMenu(Stage menu)
        {
            menuManager.AddMenu(menu);
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
                    menuManager.Draw(spriteBatch);
                    break;
                case 0:
                    Stages[0].Draw(spriteBatch);
                    break;                        
                default:
                    Stages[0].Draw(spriteBatch);
                    break;
            }
            if (SelectedStage > -1)
                hudManager.Draw(spriteBatch);
           
        }
        public void Update(GameTime gameTime)
        {
            if (!playerManager.IsPlayerAlive())
            {
                SelectedStage = -1;
                menuManager.ShowEndScreen();
                musicManager.PlaySong("End");
            }
            else
            {
                musicManager.PlaySong("Main");
            }
            if (SelectedStage == -2)
                this.Reset();
            if (SelectedStage == -1)
            {
                menuManager.Update(gameTime, this);
            }
            else if (Stages.Count >= SelectedStage)
            {
                foreach (var o in Stages[SelectedStage].gameSpriteObjects)
                {
                    o.Update(gameTime);
                }
                playerManager.Update(gameTime);
            }
            //Needs to be updated after player
            if (SelectedStage > -1)
                hudManager.Update(gameTime);
        }
        public void ResolveCollisions()
        {
            if (SelectedStage>= 0 && SelectedStage<Stages.Count)
            {
                foreach (GameObject o in Stages[SelectedStage].GameObjects)
                {
                    if (o is ICollidable)
                    {
                        ICollidable interactable = o as ICollidable;
                        interactable.ResolveCollisions();
                    }
                }
                playerManager.ResolveCollision();
            }
        }
        private void Reset()
        {
            //Implement later
        }
    }
}
