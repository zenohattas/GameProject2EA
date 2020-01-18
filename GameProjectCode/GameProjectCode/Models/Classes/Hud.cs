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
    class Hud
    {
        List<List<HudObject>> hud;
        public Hud()
        {
            hud = new List<List<HudObject>>();
        }
        public void AddHudEllements(List<List<HudObject>> hudObjects)
        {
            this.hud = hudObjects;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var hudObjects in hud)
            {
                foreach (var item in hudObjects)
                {
                    item.Draw(spriteBatch);
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            foreach (var hudObjects in hud)
            {
                foreach (var item in hudObjects)
                {
                    item.Update(gameTime);
                }
            }
        }
        public void UpdateHudEllement(int hudEllement, int newTotal)
        {
            for (int i = 0; i < hud[hudEllement].Count; i++)
            {
                if (i < newTotal)
                {
                    if (hud[hudEllement][i].ShouldUpdate == true)
                    {
                        hud[hudEllement][i].Reset();
                        hud[hudEllement][i].ShouldUpdate = false;
                    }
                }
                else
                    hud[hudEllement][i].ShouldUpdate = true;
            }
        }
        public void Reset(int hudEllement)
        {
            foreach (var hudObjects in hud)
            {
                foreach (var item in hudObjects)
                {
                    item.Reset();
                }
            }
        }
        public void Add(int hudEllement, int toAdd)
        {
            foreach (var item in hud[hudEllement])
            {
                if (item.ShouldUpdate == true & toAdd > 0)
                {
                    item.Reset();
                    item.ShouldUpdate = false;
                    toAdd--;
                }
            }
        }
    }
}
