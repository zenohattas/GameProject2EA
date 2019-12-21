using GameProjectCode.Models;
using GameProjectCode.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Factory
{
    class ObjectInitialiser
    {
        static string[] stageDataLocations =
        {
            @"C:\Electronica-ICT\Game Development\Projects\GameProject2EA\GameProjectCode\GameProjectCode\Content\Stages\WaterBackground.csv",
            @"C:\Electronica-ICT\Game Development\Projects\GameProject2EA\GameProjectCode\GameProjectCode\Content\Stages\Stage1.csv"
        };
        private Vector2 _initiasePos;
        private Vector2 _spriteSize;
        public string[,] Stage1 =
        {
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },

            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "3","3","3","6","0","0","0","5","3","3","3","6","0","0","0","0","0","0","0","0","0","0"},
            { "4","4","4","12","0","0","0","11","4","4","4","12","0","0","0","0","0","0","0","0","0","0"},
            { "4","4","4","12","0","0","0","11","4","4","4","12","0","0","0","0","0","0","0","0","0","0" }
        };
        public string[,] Stage1Background =
        {
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },

            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "","","","","","","","","","","","","","","","","","","","","","", },
            { "44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L","44,L", },
            { "45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L","45,L",}
        };
        public string[,] Stage2 =
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
        public List<GameObject> LoadStage(Dictionary<string, Animation> animations, int Stage, int StageWidth, int StageHeight)
        {
            List<GameObject> sprites = new List<GameObject>();

            sprites.AddRange(this.LoadObjects(animations, LoadStageData(stageDataLocations[0])));
            sprites.AddRange(this.LoadObjects(animations, LoadStageData(stageDataLocations[Stage])));
            sprites.AddRange(this.LoadBoundaries(StageWidth, StageHeight));

            return sprites;
        }
        private List<GameObject> LoadObjects(Dictionary<string, Animation> animations, List<List<string>> objects)
        {
            List<GameObject> sprites = new List<GameObject>();
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < objects[0].Count; j++)
                {
                    string[] ellement = objects[i][j].Split('.');
                    if (ellement.Length > 0)
                    {
                        string animationName = GetAnimationName(ellement[0]);
                        if (animationName != "0")
                        {
                            //Optional parameter
                            if (ellement.Length > 1)
                            {
                                if (ellement[1] == "L")
                                    sprites.Add(new BlockLiquidGameObject(animations, animations[animationName], _initiasePos));
                                else if (ellement[1] == "T")
                                    sprites.Add(new BlockTransparentGameObject(animations, animations[animationName], _initiasePos));
                                else if (ellement[1] == "F")
                                    sprites.Add(new BlockFallThroughGameObject(animations, animations[animationName], _initiasePos));
                                //else
                                //Do nothing
                            }
                            else
                                sprites.Add(new BlockSolidGameObject(animations, animations[animationName], _initiasePos));
                        }

                    }

                    _initiasePos.X += _spriteSize.X;
                }
                _initiasePos.X = 0;
                _initiasePos.Y += _spriteSize.Y;
            }
            _initiasePos.Y = 0;
            return sprites;
        }
        public string GetAnimationName(string i)
        {
            switch (i)
            {
                case "1":
                    return "Environment/Grass_brown_dirtedge_left";
                case "2":
                    return "Environment/Grass_brown_dirtedge_right";
                case "3":
                    return "Environment/Grass_brown_top";
                case "4":
                    return "Environment/Grass_brown_middle";
                case "5":
                    return "Environment/Grass_brown_corner_left";
                case "6":
                    return "Environment/Grass_brown_corner_right";
                case "7":
                    return "Environment/Dirt_brown_top";
                case "8":
                    return "Environment/Dirt_brown_corner_left";
                case "9":
                    return "Environment/Dirt_brown_corner_right";
                case "10":
                    return "Environment/Dirt_brown_corner_double";
                case "11":
                    return "Environment/Dirt_brown_side_left";
                case "12":
                    return "Environment/Dirt_brown_side_right";
                case "13":
                    return "Environment/Dirt_brown_side_double";
                case "14":
                    return "Environment/Block_filler";
                case "15":
                    return "Environment/Grass_blue_dirtedge_left";
                case "16":
                    return "Environment/Grass_blue_dirtedge_right";
                case "17":
                    return "Environment/Grass_blue_top";
                case "18":
                    return "Environment/Grass_blue_middle";
                case "19":
                    return "Environment/Grass_blue_corner_left";
                case "20":
                    return "Environment/Grass_blue_corner_right";
                case "21":
                    return "Environment/Dirt_blue_top";
                case "22":
                    return "Environment/Dirt_blue_corner_left";
                case "23":
                    return "Environment/Dirt_blue_corner_right";
                case "24":
                    return "Environment/Dirt_blue_corner_double";
                case "25":
                    return "Environment/Dirt_blue_side_left";
                case "26":
                    return "Environment/Dirt_blue_side_right";
                case "27":
                    return "Environment/Dirt_blue_side_double";
                case "28":
                    return "Environment/Grass_corner_left";
                case "29":
                    return "Environment/Grass_corner_right";
                case "30":
                    return "Environment/Grass_corner_left_bottom";
                case "31":
                    return "Environment/Grass_corner_right_bottom";
                case "32":
                    return "Environment/Grass_top";
                case "33":
                    return "Environment/Grass_bottom";
                case "34":
                    return "Environment/Grass_filler";
                case "35":
                    return "Environment/Grass_side_left";
                case "36":
                    return "Environment/Grass_side_right";
                case "37":
                    return "Environment/Grass_patch";
                case "38":
                    return "Environment/Grass_inside_corner_top_right";
                case "39":
                    return "Environment/Grass_inside_corner_top_left";
                case "40":
                    return "Environment/Grass_inside_corner_bottom_right";
                case "41":
                    return "Environment/Grass_inside_corner_bottom_left";
                case "42":
                    return "Environment/Grass_inside_pattern1";
                case "43":
                    return "Environment/Grass_inside_pattern2";
                case "44":
                    return "Environment/Water_top";
                case "45":
                    return "Environment/Water_inside";
                case "46":
                    return "Environment/Ladder_top";
                case "47":
                    return "Environment/Ladder_bottom";
                case "48":
                    return "Environment/Ladder_middle";
                case "49":
                    return "Environment/Box";
                case "50":
                    return "Environment/Chest_closed";
                case "51":
                    return "Environment/Chest_open_full";
                case "52":
                    return "Environment/Chest_open_empty";
                case "53":
                    return "Environment/Fence_light_left";
                case "54":
                    return "Environment/Fence_light_right";
                case "55":
                    return "Environment/Fence_light_middle";
                case "56":
                    return "Environment/Fence_dark_left";
                case "57":
                    return "Environment/Fence_dark_rigth";
                case "58":
                    return "Environment/Fence_dark_middle";
                case "59":
                    return "Environment/Boulder_small";
                case "60":
                    return "Environment/Boulder_big";
                case "61":
                    return "Environment/Signpost_dark_left";
                case "62":
                    return "Environment/Signpost_dark_center_mono";
                case "63":
                    return "Environment/Signpost_dark_center_shaded";
                case "64":
                    return "Environment/Signpost_light_left";
                case "65":
                    return "Environment/Signpost_light_center_mono";
                case "66":
                    return "Environment/Signpost_light_center_shaded";
                case "67":
                    return "Environment/Flower_white_1";
                case "68":
                    return "Environment/Flower_white_2";
                case "69":
                    return "Environment/Flower_orange_1";
                case "70":
                    return "Environment/Flower_orange_2";
                case "71":
                    return "Environment/Dirt_brown_bottom_corner_left";
                case "72":
                    return "Environment/Dirt_brown_bottom_corner_right";
                case "73":
                    return "Environment/Dirt_brown_bottom_middle";
                case "74":
                    return "Environment/Dirt_brown_bottom_double";
                case "75":
                    return "Environment/Dirt_blue_bottom_corner_left";
                case "76":
                    return "Environment/Dirt_blue_bottom_corner_right";
                case "77":
                    return "Environment/Dirt_blue_bottom_middle";
                case "78":
                    return "Environment/Dirt_blue_bottom_double";

                default:
                    return "0";

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
        private List<List<string>> LoadStageData(string fileLocation)
        {
            List<List<string>> spriteData = new List<List<string>>();

            string[] lines = File.ReadAllLines(fileLocation);

            for (int i = 0; i < lines.Length; i++)
            {
                spriteData.Add(new List<string>());
                string[] split = lines[i].Split(',');

                foreach (string item in split)
                {
                    spriteData[i].Add(item);
                }
            }

            return spriteData;
        }
        private List<GameObject> LoadBoundaries(int StageWidth, int StageHeight)
        {
            List<GameObject> boundries = new List<GameObject>();

            boundries.Add(new BoundryObject(new Rectangle(0, -16, StageWidth, 16)));
            boundries.Add(new BoundryObject(new Rectangle(-16, 0, 16, StageHeight)));
            boundries.Add(new BoundryObject(new Rectangle(0, StageHeight, StageWidth, 16)));
            boundries.Add(new BoundryObject(new Rectangle(StageWidth, 0, 16, StageHeight)));

            return boundries;
        }
    }
}
