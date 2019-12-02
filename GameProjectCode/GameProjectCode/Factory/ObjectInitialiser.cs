using GameProjectCode.Models;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Factory
{
    class ObjectInitialiser
    {
        private Vector2 _initiasePos;
        private Vector2 _spriteSize;
        public int[,] Stage1 =
        {
            { },
        };
        public int[,] Stage2 =
        {
            { },
        };
        public ObjectInitialiser()
        {
            _initiasePos = new Vector2(0, 0);
            _spriteSize = new Vector2(16,16);
        }
        public ObjectInitialiser(Vector2 initialisePos, Vector2 spriteSize)
        {
            _initiasePos = initialisePos;
            _spriteSize = spriteSize;
        }
        public List<GameObject> LoadStage(Dictionary<string, Animation> animations, int[,] Stage)
        {
            List<GameObject> sprites = new List<GameObject>();
            for (int i = 0; i < Stage.GetLength(0); i++)
            {
                for (int j = 0; j < Stage.GetLength(1); j++)
                {
                    string animationName = GetAnimationName(Stage[i, j]);

                    if (animationName.Last() == 'S')
                        sprites.Add(new BlockSolidGameObject(animations, animations[animationName], _initiasePos));
                    else if (animationName.Last() == 'L')
                        sprites.Add(new BlockLiquidGameObject(animations, animations[animationName], _initiasePos));
                    else if (animationName.Last() == 'T')
                        sprites.Add(new BlockTransparentGameObject(animations, animations[animationName], _initiasePos));
                    else if(animationName.Last() == 'F')
                        sprites.Add(new BlockFallThroughGameObject(animations, animations[animationName], _initiasePos));

                    _initiasePos.Y += _spriteSize.Y;
                }
                _initiasePos.Y += 0;
                _initiasePos.X += _spriteSize.X;
            }
            _initiasePos.X = 0;
            return sprites;
        }
        public string GetAnimationName(int i)
        {
            switch (i)
            {
                case 1:
                    return "Environment/Grass_brown_dirtedge_left_S";
                case 2:
                    return "Environment/Grass_brown_dirtedge_right_S";
                case 3:
                    return "Environment/Grass_brown_top_S";
                case 4:
                    return "Environment/Grass_brown_middle_S";
                case 5:
                    return "Environment/Grass_brown_corner_left_S";
                case 6:
                    return "Environment/Grass_brown_corner_right_S";
                case 7:
                    return "Environment/Dirt_brown_top_S";
                case 8:
                    return "Environment/Dirt_brown_corner_left_S";
                case 9:
                    return "Environment/Dirt_brown_corner_right_S";
                case 10:
                    return "Environment/Dirt_brown_corner_double_S";
                case 11:
                    return "Environment/Dirt_brown_side_left_S";
                case 12:
                    return "Environment/Dirt_brown_side_right_S";
                case 13:
                    return "Environment/Dirt_brown_side_double_S";
                case 14:
                    return "Environment/Block_filler_S";
                case 15:
                    return "Environment/Grass_blue_dirtedge_left_S";
                case 16:
                    return "Environment/Grass_blue_dirtedge_right_S";
                case 17:
                    return "Environment/Grass_blue_top_S";
                case 18:
                    return "Environment/Grass_blue_middle_S";
                case 19:
                    return "Environment/Grass_blue_corner_left_S";
                case 20:
                    return "Environment/Grass_blue_corner_right_S";
                case 21:
                    return "Environment/Dirt_blue_top_S";
                case 22:
                    return "Environment/Dirt_blue_corner_left_S";
                case 23:
                    return "Environment/Dirt_blue_corner_right_S";
                case 24:
                    return "Environment/Dirt_blue_corner_double_S";
                case 25:
                    return "Environment/Dirt_blue_side_left_S";
                case 26:
                    return "Environment/Dirt_blue_side_right_S";
                case 27:
                    return "Environment/Dirt_blue_side_double_S";
                case 28:
                    return "Environment/Grass_corner_left_S";
                case 29:
                    return "Environment/Grass_corner_right_S";
                case 30:
                    return "Environment/Grass_corner_left_bottom_S";
                case 31:
                    return "Environment/Grass_corner_right_bottom_S";
                case 32:
                    return "Environment/Grass_top_S";
                case 33:
                    return "Environment/Grass_bottom_S";
                case 34:
                    return "Environment/Grass_filler_S";
                case 35:
                    return "Environment/Grass_side_left_S";
                case 36:
                    return "Environment/Grass_side_right_S";
                case 37:
                    return "Environment/Grass_patch_S";
                case 38:
                    return "Environment/Grass_inside_corner_top_right_S";
                case 39:
                    return "Environment/Grass_inside_corner_top_left_S";
                case 40:
                    return "Environment/Grass_inside_corner_bottom_right_S";
                case 41:
                    return "Environment/Grass_inside_corner_bottom_left_S";
                case 42:
                    return "Environment/Grass_inside_pattern1_S";
                case 43:
                    return "Environment/Grass_inside_pattern2_S";
                case 44:
                    return "Environment/Water_top_L";
                case 45:
                    return "Environment/Water_inside_L";
                case 46:
                    return "Environment/Ladder_top_S";
                case 47:
                    return "Environment/Ladder_bottom_S";
                case 48:
                    return "Environment/Ladder_middle_S";
                case 49:
                    return "Environment/Box_S";
                case 50:
                    return "Environment/Chest_closed_T";
                case 51:
                    return "Environment/Chest_open_full_T";
                case 52:
                    return "Environment/Chest_open_empty_T";
                case 53:
                    return "Environment/Fence_light_left_T";
                case 54:
                    return "Environment/Fence_light_right_T";
                case 55:
                    return "Environment/Fence_ligt_middle_T";
                case 56:
                    return "Environment/Fence_dark_left_T";
                case 57:
                    return "Environment/Fence_dark_rigth_T";
                case 58:
                    return "Environment/Fence_dark_middle_T";
                case 59:
                    return "Environment/Boulder_small_T";
                case 60:
                    return "Environment/Boulder_big_T";
                case 61:
                    return "Environment/Signpost_dark_left_T";
                case 62:
                    return "Environment/Signpost_dark_center_mono_T";
                case 63:
                    return "Environment/Signpost_dark_center_shaded_T";
                case 64:
                    return "Environment/Signpost_light_left_T";
                case 65:
                    return "Environment/Signpost_light_center_mono_T";
                case 66:
                    return "Environment/Signpost_light_center_shaded_T";
                case 67:
                    return "Environment/Flower_white_1_T";
                case 68:
                    return "Environment/Flower_white_2_T";
                case 69:
                    return "Environment/Flower_orange_1_T";
                case 70:
                    return "Environment/Flower_orange_2_T";

                default:
                    return "";

            }
        }
        public GameObject LoadPlayer(Dictionary<string, Animation> animations)
        {
            return new PlayerGameObject(animations)
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
            };
        }
        public List<GameObject> LoadStage1(Dictionary<string, Animation> animations, GraphicsDeviceManager graphics)
        {
            List<GameObject> sprites = new List<GameObject>();
            sprites.Add(new Ground(animations, graphics.GraphicsDevice.Viewport, animations["Environment/Water_top_L"], new Vector2(0, 200)));
            sprites.Add(new Ground(animations, graphics.GraphicsDevice.Viewport, animations["Environment/Water_top_L"], new Vector2(0, 50)));
            sprites.Add(new Block(animations, animations["Environment/Box_S"])
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
