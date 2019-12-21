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
    class PlayerManager
    {
        private List<GameSpriteObject> Player;
        public PlayerManager()
        {
            Player = new List<GameSpriteObject>();
        }
        public GameSpriteObject GetPlayer()
        {
            return Player[0];
        }
        public void AddPlayer(GameSpriteObject player)
        {
            Player.Add(player);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Player[0].Draw(spriteBatch);
        }
        public void Update(GameTime gametime)
        {
            Player[0].Update(gametime);
        }
        public void ResolveCollision()
        {
            IInteractable i = Player[0] as IInteractable;
            i.ResolveCollisions();
        }
    }
}
