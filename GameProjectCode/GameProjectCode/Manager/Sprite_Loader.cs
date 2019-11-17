using GameProjectCode.Models;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Manager
{
    class Sprite_Loader
    {
        static string[] spriteDataLocations =
        {
            @"C:\Electronica-ICT\Game Development\Projects\GameProject2EA\GameProjectCode\GameProjectCode\Content\Spritesheet_Adventurer_Right.csv",
            @"C:\Electronica-ICT\Game Development\Projects\GameProject2EA\GameProjectCode\GameProjectCode\Content\Spritesheet_Adventurer_Left.csv",
            @"C:\Electronica-ICT\Game Development\Projects\GameProject2EA\GameProjectCode\GameProjectCode\Content\Environment_Blocks.csv"
        };
        static string[] spriteNames =
        {
            "Adventurer/adventurer-SheetRight",
            "Adventurer/adventurer-SheetLeft",
            "Environment/sheet"
        };
        static string[] spritePrefix =
        {
            "Adventurer/",
            "Adventurer/",
            "Environment/"
        };
        public Dictionary<string, Animation> GetAnimationDictionary(ContentManager content)
        {
            //Create a Datastring containing all information about each sprite
            List<List<string>> spriteData = new List<List<string>>();
            //Create a Dictonary to return
            var dictonary = new Dictionary<string, Animation>();

            //Loading all sprite data from difrent sheets
            for (int i = 0; i < spriteDataLocations.Length; i++)
            {
                spriteData = LoadSpriteData(spriteDataLocations[i]);

                LoadDictonary(dictonary, content, spriteData, i);
            }

            //Returning the Dictonary
            return dictonary;
        }

        private List<List<string>> LoadSpriteData(string fileLocation)
        {
            List<List<string>> spriteData = new List<List<string>>();

            string[] lines = File.ReadAllLines(fileLocation);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');

                foreach (string item in split)
                {
                    spriteData[i].Add(item);
                }
            }

            return spriteData;
        }
        private void LoadDictonary(Dictionary<string, Animation> dictonary, ContentManager content, List<List<string>> spriteData, int i)
        {
            string checkString ="";
            foreach (var item in spriteData)
            {
                if(checkString != item[0])
                {
                    checkString = item[0];
                    dictonary.Add(spritePrefix[i] + item[0], new Animation(content.Load<Texture2D>(spriteNames[i]), Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), Convert.ToInt32(item[4])));
                    if (item[5] == "false")
                        dictonary[item[0]].IsLooping = false;
                    if (item[6] != "")
                        dictonary[item[0]].FrameSpeed = Convert.ToInt32(item[6]);
                    if (item[7] != "" && item[8] !="")
                        dictonary[item[0]].Offset = new Microsoft.Xna.Framework.Vector2(Convert.ToInt32(item[7]), Convert.ToInt32(item[8]));
                }
                else
                {
                    dictonary[item[0]].AddFrame(Convert.ToInt32(item[1]), Convert.ToInt32(item[2]));
                }
            }
        }
    }
}
