using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class MenuElement
    {
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public MenuElement(string text, Vector2 position)
        {
            Text = text;
            Position = position;
        }
    }
}
