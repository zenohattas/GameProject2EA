using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class Background
    {
        public Texture2D Texture;
        public Rectangle Rectangle;
        public Background(Texture2D texture, Rectangle rectangle)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Rectangle, Color.White);
        }
    }
}
