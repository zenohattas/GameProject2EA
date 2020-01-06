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
        //static string[] spritePrefix =
        //{
        //    "Adventurer/",
        //    "Adventurer/",
        //    "Environment/"
        //}; //Redundant
        public Dictionary<string, Animation> GetAnimationDictionary(ContentManager content)
        {
            //Create a Datastring containing all information about each sprite
            List<List<string>> spriteData = new List<List<string>>();
            //Create a Dictonary to return
            var dictonary = new Dictionary<string, Animation>();

            //Loading all sprite data from diffrent sheets
            for (int i = 0; i < spriteDataLocations.Length; i++)
            {
                spriteData = LoadSpriteData(spriteDataLocations[i]);

                LoadDictonary(dictonary, content, spriteData, i);
            }
            //Rest of Dictionary
            dictonary.Add("Title", new Animation(content.Load<Texture2D>("Environment/Menu/GameTitle"), 0, 0, 740, 300));
            dictonary.Add("DefeatTitle", new Animation(content.Load<Texture2D>("Environment/Menu/Endscreen"), 0, 0, 740, 125));
            dictonary.Add("Start", new Animation(content.Load<Texture2D>("Environment/Menu/StartTextBox"), 0, 0, 205,77, true, 0));
            dictonary["Start"].AddFrame(0,77);
            dictonary.Add("Options", new Animation(content.Load<Texture2D>("Environment/Menu/OptionsTextBox"), 0, 0, 205, 77, true, 0));
            dictonary["Options"].AddFrame(0, 77);
            dictonary.Add("Quit", new Animation(content.Load<Texture2D>("Environment/Menu/QuitTextBox"), 0, 0, 205, 77, true, 0));
            dictonary["Quit"].AddFrame(0, 77);
            dictonary.Add("Restart", new Animation(content.Load<Texture2D>("Environment/Menu/RestartTextBox"), 0, 0, 205, 77, true, 0));
            dictonary["Restart"].AddFrame(0, 77);
            dictonary.Add("Return", new Animation(content.Load<Texture2D>("Environment/Menu/ReturnTextBox"), 0, 0, 205, 77, true, 0));
            dictonary["Return"].AddFrame(0, 77);

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
                if (item[0] != "" && item[1] != "" && item[2] != "" && item[3] != "")
                {
                    if(item[0] != checkString)
                    {
                        checkString = item[0];
                            dictonary.Add(item[0], new Animation(content.Load<Texture2D>(spriteNames[i]), Convert.ToInt32(item[1]), Convert.ToInt32(item[2]), Convert.ToInt32(item[3]), Convert.ToInt32(item[4])));
                            if (item[5] == "false")
                                dictonary[item[0]].IsLooping = false;
                            if (item[6] != "")
                                dictonary[item[0]].FrameSpeed = Convert.ToInt32(item[6]);
                            if (item[7] != "" && item[8] != "")
                                dictonary[item[0]].Offset = new Microsoft.Xna.Framework.Vector2(Convert.ToInt32(item[7]), Convert.ToInt32(item[8])); //Convert.ToInt32(item[8])
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
