using GameProjectCode.Models;
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
    class HudManager
    {
        Hud hud;
        PlayerManager playerManager;
        public HudManager(Hud hud, PlayerManager playerManager)
        {
            this.hud = hud;
            this.playerManager = playerManager;
        }
        public void AddHudEllements(List<List<HudObject>> hudObjects)
        {
            hud.AddHudEllements(hudObjects);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            hud.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            hud.UpdateHudEllement(0, playerManager.GetPlayer().HP);
            hud.UpdateHudEllement(1, playerManager.GetPlayer().Breath);

            hud.Update(gameTime);
        }
    }
}
