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
        public MenuManager Menu;
        List<List<GameObject>> Stage;
        public int SelectedStage { get; set; }

        public StageManager(MenuManager menuManager)
        {
            Stage = new List<List<GameObject>>();
            Menu = menuManager;
            SelectedStage = -1;
        }
        public void AddStage(List<GameObject> stage)
        {
            Stage.Add(stage);
        }
        public List<GameObject> GetStage()
        {
            if(SelectedStage >= 0 && SelectedStage < Stage.Count)
                return Stage[SelectedStage];
            return null;
        }
        public List<GameObject> GetStage(int stageLevel)
        {
            if (stageLevel >= 0 && stageLevel < Stage.Count)
                return Stage[stageLevel];
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
                    foreach (var sprite in Stage[0])
                        sprite.Draw(spriteBatch);
                    break;                        
                default:
                    foreach (var sprite in Stage[0])
                        sprite.Draw(spriteBatch);
                    break;
            }
            
        }
        public void Update(GameTime gameTime)
        {
            if (SelectedStage == -1)
            {
                Menu.Update(gameTime, this);
            }
            else if (Stage.Count >= SelectedStage)
            {
                foreach (var sprite in Stage[SelectedStage])
                {
                    sprite.Update(gameTime, Stage[SelectedStage]);
                }
            }
        }
    }
}
