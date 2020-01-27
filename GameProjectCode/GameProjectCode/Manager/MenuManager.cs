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
using GameProjectCode.Extensions;

namespace GameProjectCode.Manager
{
    //FONT TO USE = RINGBEARER
    class MenuManager
    {
        Color color;
        Color colorSelected;
        bool UpdateMenu;
        List<Stage> Menu;
        List<List<MenuObject>> menuObjects;
        private int selectedElement;
        private int selectedMenu;
        private Timer _timer;
        private Vector2 position;
        private Keys _previousPressedKey;
        private MouseState _previousMouseState;

        public MenuManager(Vector2 Position)
        {
            Menu = new List<Stage>();
            menuObjects = new List<List<MenuObject>>();

            position = Position;

            color = Color.White;
            colorSelected = Color.SeaGreen;
            selectedMenu = 0;
            selectedElement = 1;
            _timer = new Timer();
            UpdateMenu = false;
            _previousMouseState = Mouse.GetState();
        }
        public void AddMenu(Stage menu)
        {
            Menu.Add(menu);
            menuObjects.Add(new List<MenuObject>());
            foreach (var item in menu.GameObjects)
            {
                if (item is MenuObject)
                {
                    menuObjects[menuObjects.Count-1].Add(item as MenuObject);
                }
            }
        }
        public void Update(GameTime gameTime, StageManager stageManager)
        {
            _timer.Time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer.Time > 0.05f )
            {
                int _itemToSelect = selectedElement;
                _timer.Time = 0;
                
                for (int i = 1; i < menuObjects[selectedMenu].Count; i++)
                {
                    var depth = RectangleExtension.GetIntersectionDepth(menuObjects[selectedMenu][i].CollisionRectangle, new Rectangle(Mouse.GetState().X - 15, Mouse.GetState().Y - 15, 30, 30));
                    if (depth.X > 0 || depth.Y > 0)
                    {
                        _itemToSelect = i;
                        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                        {
                            if (_previousMouseState.LeftButton != Mouse.GetState().LeftButton)
                            {
                                UpdateMenu = true;
                            }
                        }
                    }
                }
                _previousMouseState = Mouse.GetState();

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if(Keys.Up != _previousPressedKey)
                    {
                        if (selectedElement > 1)
                        {
                            _itemToSelect--;
                        }
                    }
                    _previousPressedKey = Keys.Up;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if(Keys.Down != _previousPressedKey)
                    {
                        if (selectedElement < menuObjects[selectedMenu].Count-1)
                        {
                            _itemToSelect++;

                        }
                    }
                    _previousPressedKey = Keys.Down;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    if (Keys.Enter != _previousPressedKey)
                    {
                        UpdateMenu = true;
                    }
                    _previousPressedKey = Keys.Enter;
                }
                else
                    _previousPressedKey = Keys.End;
                if (_itemToSelect != selectedElement)
                {
                    menuObjects[selectedMenu][selectedElement].Revert();
                    selectedElement = _itemToSelect;
                    menuObjects[selectedMenu][selectedElement].Invert();

                }
                if (UpdateMenu)
                {
                    menuObjects[selectedMenu][selectedElement].Revert();
                    SetMenu(stageManager);
                    UpdateMenu = false;
                    menuObjects[selectedMenu][selectedElement].Invert();
                }
            }
            Menu[selectedMenu].Update(gameTime);
        }
        private void SetMenu(StageManager stageManager)
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
                            stageManager.SelectedStage = -3;
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
                case 2:
                    switch (selectedElement)
                    {
                        case 1:
                            stageManager.SelectedStage = -2;
                            break;
                        case 2:
                            stageManager.SelectedStage = -3;
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    switch (selectedElement)
                    {
                        case 1:
                            stageManager.SelectedStage = -2;
                            break;
                        case 2:
                            stageManager.SelectedStage = -3;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(selectedMenu >= 0 && selectedMenu < Menu.Count)
                    Menu[selectedMenu].Draw(spriteBatch);
        }
        public void ShowEndScreen()
        {
            selectedMenu = 2;
        }
        public void ShowWinScreen()
        {
            selectedMenu = 3;
        }

    }
}
