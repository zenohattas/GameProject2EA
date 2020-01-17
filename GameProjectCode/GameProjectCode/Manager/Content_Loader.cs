using GameProjectCode.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class Content_Loader
    {
        List<string> spriteDataLocations;
        static string[] spriteNames =
        {
            "Adventurer/adventurer-SheetRight",
            "Adventurer/adventurer-SheetLeft",
            "Environment/sheet",
            "Environment/Menu/MenuItems",
            "Monsters/Monsters",
            "Misc/ObjectAssets"
        };
        public Content_Loader()
        {
            LoadSpriteDataLocation();
        }
        private void LoadSpriteDataLocation()
        {
            spriteDataLocations = new List<string>();

            string basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            basePath = basePath.Replace(@"\bin\Windows\x86\Debug", "");

            spriteDataLocations.Add(basePath + @"\Content\Adventurer\Spritesheet_Adventurer_Right.csv");
            spriteDataLocations.Add(basePath + @"\Content\Adventurer\Spritesheet_Adventurer_Left.csv");
            spriteDataLocations.Add(basePath + @"\Content\Environment\Environment_Blocks.csv");
            spriteDataLocations.Add(basePath + @"\Content\Environment\Menu\MenuItems.csv");
            spriteDataLocations.Add(basePath + @"\Content\Monsters\Monsters.csv");
            spriteDataLocations.Add(basePath + @"\Content\Misc\ObjectAssets.csv");

        }

        public Dictionary<string, Animation> GetAnimationDictionary(ContentManager content)
        {
            //Create a Datastring containing all information about each sprite
            List<List<string>> spriteData = new List<List<string>>();
            //Create a Dictonary to return
            var dictonary = new Dictionary<string, Animation>();

            //Loading all sprite data from diffrent sheets
            for (int i = 0; i < spriteDataLocations.Count; i++)
            {
                spriteData = LoadSpriteData(spriteDataLocations[i]);

                LoadDictonary(dictonary, content, spriteData, i);
            }
            //Rest of Dictionary
            //Returning the Dictonary
            return dictonary;
        }

        private List<List<string>> LoadSpriteData(string fileLocation)
        {
            List<List<string>> spriteData = new List<List<string>>();

            string[] lines = File.ReadAllLines(fileLocation);

            for (int i = 1; i < lines.Length; i++)
            {
                spriteData.Add(new List<string>());
                string[] split = lines[i].Split(';');

                foreach (string item in split)

                {
                    spriteData[i-1].Add(item);
                }
            }

            return spriteData;
        }
        private void LoadDictonary(Dictionary<string, Animation> dictonary, ContentManager content, List<List<string>> spriteData, int i)
        {
            string checkString ="";
            foreach (var item in spriteData)
            {
                if (item.Count > 2)
                {
                    if (item[0] != "" && item[1] != "" && item[2] != "")
                    {
                        if (item[0] != checkString)
                        {
                            if (item.Count > 4)
                            {
                                if(item[3] != "" && item[4] != "")
                                {
                                    checkString = item[0];
                                    dictonary.Add(item[0], new Animation(content.Load<Texture2D>(spriteNames[i]), Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), Convert.ToInt32(item[4])));
                                    if(item.Count > 5)
                                    {
                                        if (item[5] == "false")
                                            dictonary[item[0]].IsLooping = false;
                                        if (item.Count > 6)
                                        {
                                            if (item[6] != "")
                                                dictonary[item[0]].FrameSpeed = Convert.ToInt32(item[6]);
                                            if (item.Count > 7)
                                            {
                                                if (item[7] != "" && item[8] != "")
                                                    dictonary[item[0]].Offset = new Microsoft.Xna.Framework.Vector2(Convert.ToInt32(item[7]), Convert.ToInt32(item[8])); //Convert.ToInt32(item[8])

                                            }

                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            if (item.Count > 4)
                            {
                                dictonary[item[0]].AddFrame(Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), Convert.ToInt32(item[4]));
                            }
                            else
                            {
                                dictonary[item[0]].AddFrame(Convert.ToInt32(item[1]), Convert.ToInt32(item[2]));

                            }
                        }
                    }

                }
            }
        }
        public Dictionary<string, Song> LoadSongs(ContentManager content)
        {
            Dictionary<string, Song> songs = new Dictionary<string, Song>();
            songs.Add("Main", content.Load<Song>("Music/Frozen_Forest"));
            songs.Add("End", content.Load<Song>("Music/Dead_Forest"));

            return songs;
        }
    }
}
