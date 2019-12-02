using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    //FONT TO USE = RINGBEARER
    class MenuManager
    {
        Color color;
        Color colorSelected;
        List<List<string>> Menu;
        private int selectedElement;
        private int selectedMenu;
        private float _timer;
        private Keys _perviousPressedKey;

        public MenuManager()
        {
            Menu = new List<List<string>>();
            Menu.Add(new List<string>
            {
                "Start",
                "Options",
                "Quit"
            });
            Menu.Add(new List<string>
            {
                "To be implemented",
                "Back"
            });
            Menu.Add(new List<string>
            {
                "Contact",
                "Start again"
            });

            color = Color.White;
            colorSelected = Color.SeaGreen;
            selectedMenu = 0;
            selectedElement = 0;
            _timer = 0;
        }
        public void Update(GameTime gameTime, StageManager stageManager)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer > 0.05f )
            {
                _timer = 0;
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if(Keys.Up != _perviousPressedKey)
                    {
                        if (selectedElement > 0)
                            selectedElement--;
                        else
                            selectedElement = 0;
                    }
                    _perviousPressedKey = Keys.Up;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if(Keys.Down != _perviousPressedKey)
                    {
                        if (selectedElement < Menu[selectedMenu].Count - 1)
                            selectedElement++;
                    }
                    _perviousPressedKey = Keys.Down;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    if (Keys.Enter != _perviousPressedKey)
                    {
                        switch (selectedMenu)
                        {
                            case 0:
                                switch (selectedElement)
                                {
                                    case 0:
                                        stageManager.SelectedStage = 0;
                                        break;
                                    case 1:
                                        selectedMenu = 1;
                                        selectedElement = 0;
                                        break;
                                    case 2:
                                        stageManager.SelectedStage = -2;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 1:
                                switch (selectedElement)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        selectedMenu = 0;
                                        selectedElement = 0;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    _perviousPressedKey = Keys.Enter;
                }
                else
                    _perviousPressedKey = Keys.End;
            }
        }
        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            if(selectedMenu >= 0 && selectedMenu < Menu.Count)
                Draw(Menu[selectedMenu], spriteBatch, spriteFont);
        }
        private void Draw(List<string> menu, SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            for (int i = 0; i < menu.Count; i++)
            {
                //spriteBatch.Begin();
                
                if(i == selectedElement)
                    spriteBatch.DrawString(spriteFont, menu[i], new Vector2(100, 100 + i * 20), colorSelected);
                else
                    spriteBatch.DrawString(spriteFont, menu[i], new Vector2(100, 100 + i * 20), color);
                
                //spriteBatch.End();
            }
        }
    }
}
