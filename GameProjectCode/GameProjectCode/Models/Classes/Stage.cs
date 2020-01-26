using GameProjectCode.Manager;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
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
                return GameObjects.Count;
            }
        }
        public Background Background;
        public List<GameObject> GameObjects;
        public List<GameObject> BackgroundObjects;
        public Stage(List<GameObject> forgroundObjects, Background background, PlayerManager playerManager, bool ShowPlayer = true)
        {
            this.GameObjects = forgroundObjects;
            this.BackgroundObjects = new List<GameObject>();
            this.Background = background;
            showPlayer = ShowPlayer;
            this.playerManager = playerManager;
        }
        public Stage(List<GameObject> forgroundObjects, List<GameObject> backgroundObjects, Background background, PlayerManager playerManager, bool ShowPlayer = true)
        {
            this.GameObjects = forgroundObjects;
            this.BackgroundObjects = backgroundObjects;
            this.Background = background;
            showPlayer = ShowPlayer;
            this.playerManager = playerManager;
        }
        public Stage(List<GameObject> gameObjects)
        {
            this.GameObjects = gameObjects;
        }
        public void Update(GameTime gameTime)
        {
            update(GameObjects, gameTime);
            update(BackgroundObjects, gameTime);
        }
        private void update(List<GameObject> objects, GameTime gameTime)
        {
            foreach (var item in objects)
            {
                if (item is GameSpriteObject)
                {
                    var sprite = item as GameSpriteObject;
                    sprite.Update(gameTime);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Background != null)
                Background.Draw(spriteBatch);

            this.draw(BackgroundObjects, spriteBatch);
            
            if(showPlayer)
                playerManager.Draw(spriteBatch);

            this.draw(GameObjects, spriteBatch);
        }
        private void draw(List<GameObject> objects, SpriteBatch spriteBatch)
        {
            foreach (var item in objects)
            {
                if (item is GameSpriteObject)
                {
                    var sprite = item as GameSpriteObject;
                    sprite.Draw(spriteBatch);
                }
            }
        }
    }
}
