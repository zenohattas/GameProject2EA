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
        public Background Background;
        public List<GameObject> GameObjects;
        public List<GameSpriteObject> gameSpriteObjects;
        public Stage(List<GameObject> gameObjects, Background background)
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
        }
        public Stage(List<GameObject> gameObjects)
        {
            this.GameObjects = gameObjects;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Background != null)
                Background.Draw(spriteBatch);
            foreach (var o in gameSpriteObjects)
            {
                o.Draw(spriteBatch);
            }
        }
    }
}
