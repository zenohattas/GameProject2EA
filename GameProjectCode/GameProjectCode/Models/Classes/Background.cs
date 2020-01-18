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
        public int ScaleFactor;
        public Background(Texture2D texture, Rectangle rectangle, int scaleFactor)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            ScaleFactor = scaleFactor;
        }
        public Background(Texture2D texture, Rectangle rectangle)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            ScaleFactor = 1;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, new Rectangle(Rectangle.X*ScaleFactor, Rectangle.Y * ScaleFactor, Rectangle.Width * ScaleFactor, Rectangle.Height * ScaleFactor), Color.White);
        }
    }
}
