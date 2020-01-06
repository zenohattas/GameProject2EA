using GameProjectCode.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProjectCode.Objects;

namespace GameProjectCode.Manager
{
    //FONT TO USE = RINGBEARER
    class MenuManager
    {
        Color color;
        Color colorSelected;
        List<Stage> Menu;
        List<List<MenuObject>> menuObjects;
        private int selectedElement;
        private int selectedMenu;
        private float _timer;
        private Vector2 position;
        private Keys _perviousPressedKey;

        public MenuManager(Vector2 Position)
        {
            Menu = new List<Stage>();
            menuObjects = new List<List<MenuObject>>();

            position = Position;

            color = Color.White;
            colorSelected = Color.SeaGreen;
            selectedMenu = 0;
            selectedElement = 1;
            _timer = 0;
        }
        public void AddMenu(Stage menu)
        {
            Menu.Add(menu);
            menuObjects.Add(new List<MenuObject>());
            foreach (var item in menu.gameSpriteObjects)
            {
                if (item is MenuObject)
                {
                    menuObjects[menuObjects.Count-1].Add(item as MenuObject);
                }
            }
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
                        if (selectedElement > 1)
                        {
                            menuObjects[selectedMenu][selectedElement].Revert();
                            selectedElement--;
                        }
                    }
                    _perviousPressedKey = Keys.Up;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if(Keys.Down != _perviousPressedKey)
                    {
                        if (selectedElement < menuObjects[selectedMenu].Count-1)
                        {
                            menuObjects[selectedMenu][selectedElement].Revert();
                            selectedElement++;

                        }
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
                                    case 1:
                                        stageManager.SelectedStage = 0;
                                        break;
                                    case 2:
                                        menuObjects[selectedMenu][selectedElement].Revert();
                                        selectedMenu = 1;
                                        selectedElement = 1;
                                        break;
                                    case 3:
                                        stageManager.SelectedStage = -2;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 1:
                                switch (selectedElement)
                                {
                                    case 1:
                                        menuObjects[selectedMenu][selectedElement].Revert();
                                        selectedMenu = 0;
                                        selectedElement = 1;
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
            menuObjects[selectedMenu][selectedElement].Invert();
            Menu[selectedMenu].Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(selectedMenu >= 0 && selectedMenu < Menu.Count)
                    Menu[selectedMenu].Draw(spriteBatch);
        }
    }
}
