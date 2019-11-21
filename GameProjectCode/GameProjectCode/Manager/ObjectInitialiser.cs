using GameProjectCode.Models;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class ObjectInitialiser
    {
        public List<GameObject> LoadStage1(Dictionary<string, Animation> animations, GraphicsDeviceManager graphics)
        {
            List<GameObject> sprites = new List<GameObject>();
            sprites.Add(
                new PlayerGameObject(animations)
                {
                    Position = new Vector2(100, 100),
                    Input = new Input()
                    {
                        Up = Keys.Z,
                        Down = Keys.S,
                        Left = Keys.Q,
                        Right = Keys.D,
                        Jump = Keys.Space,
                        Sprint = Keys.LeftShift,
                        Dodge = Keys.L,
                        Attack = Keys.J,
                        Spell = Keys.K,
                    },
                }
                );
            sprites.Add(new Ground(animations, graphics.GraphicsDevice.Viewport, animations["Environment/Water_top"], new Vector2(0, 200)));
            sprites.Add(new Ground(animations, graphics.GraphicsDevice.Viewport, animations["Environment/Water_top"], new Vector2(0, 50)));
            sprites.Add(new Block(animations, animations["Environment/Box"])
            {
                Position = new Vector2(200, 188)
            });


            sprites.Add(new PlayerGameObject(animations)
            {
                Position = new Vector2(150, 100),
                Input = new Input()
                {
                    Up = Keys.Up,
                    Down = Keys.Down,
                    Left = Keys.Left,
                    Right = Keys.Right,

                },
            });

            return sprites;
        }
        public List<GameObject> LoadStage2()
        {
            List<GameObject> stage = new List<GameObject>();

            return stage;
        }

    }
}
