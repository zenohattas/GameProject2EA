using GameProjectCode.Manager;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class Stage
    {
        PlayerManager playerManager;
        bool showPlayer;
        public int Count
        {
            get
            {
                return gameSpriteObjects.Count;
            }
        }
        public Background Background;
        public List<GameObject> GameObjects;
        public List<GameSpriteObject> gameSpriteObjects;
        public Stage(List<GameObject> gameObjects, Background background, PlayerManager playerManager, bool ShowPlayer = true)
        {
            this.GameObjects = gameObjects;
            this.Background = background;
            gameSpriteObjects = new List<GameSpriteObject>();
            foreach (var gameObject in gameObjects)
            {
                if (gameObject is GameSpriteObject)
                {
                    gameSpriteObjects.Add(gameObject as GameSpriteObject);
                }
            }
            showPlayer = ShowPlayer;
            this.playerManager = playerManager;
        }
        public Stage(List<GameObject> gameObjects)
        {
            this.GameObjects = gameObjects;
        }
        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            for (int i = 0; i < gameSpriteObjects.Count; i++)
            {
                gameSpriteObjects[i].Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Background != null)
                Background.Draw(spriteBatch);
            
            if(showPlayer)
                playerManager.Draw(spriteBatch);

            foreach (var o in gameSpriteObjects)
            {
                o.Draw(spriteBatch);
            }
        }
    }
}
