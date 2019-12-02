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
        public Stage(List<GameObject> gameObjects, Background background)
        {
            this.GameObjects = gameObjects;
            this.Background = background;
        }
        public Stage(List<GameObject> gameObjects)
        {
            this.GameObjects = gameObjects;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Background != null)
                Background.Draw(spriteBatch);
            foreach (var sprite in GameObjects)
                sprite.Draw(spriteBatch);
        }
    }
}
