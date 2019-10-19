using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameProjectCode.Models;
using System;
using GameProjectCode.Objects;

namespace GameProjectCode
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Manager.CollisionManager collisionManager;
        Random r = new Random();

        private List<GameObject> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            collisionManager = new Manager.CollisionManager();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var animations = new Dictionary<string, Animation>()
            {
                //{"WalkUp", new Animation(Content.Load<Texture2D>("Player/WalkUp"), 6) },
                //{"WalkDown", new Animation(Content.Load<Texture2D>("Player/WalkDown"), 6) },
                //{"WalkLeft", new Animation(Content.Load<Texture2D>("Player/WalkLeft"), 6) },
                //{"WalkRight", new Animation(Content.Load<Texture2D>("Player/WalkRight"), 6) },

                //{"Adventurer/Right_AirAttack1", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_AirAttack2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_AirAttack3End", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_AirAttack3Loop", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_AirAttack3Ready", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Attack1", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Attack2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Attack3", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Cast", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_CastLoop", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_CornerClimb", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_CornerGrab", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_CornerJump", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Crouch", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Die", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Fall", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Hurt", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                {"Adventurer/Right_Idle", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), 0, 0, 50, 36) },
                //{"Adventurer/Right_Idle2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Items", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                {"Adventurer/Right_Jump", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), 0, 72, 50, 36, isLooping:false) },
                //{"Adventurer/Right_LadderClimb", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                {"Adventurer/Right_Run", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), 50, 36, 50, 36) },
                //{"Adventurer/Right_Slide", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_RollDodge", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_Stand", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_SwordDraw", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_SwordSheat", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },
                //{"Adventurer/Right_WallSlide", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetRight"), , , 36, 50) },

                //{"Adventurer/Left_AirAttack1", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_AirAttack2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_AirAttack3End", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_AirAttack3Loop", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_AirAttack3Ready", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Attack1", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Attack2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Attack3", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Cast", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_CastLoop", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_CornerClimb", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_CornerGrab", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_CornerJump", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Crouch", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Die", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Fall", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Hurt", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                {"Adventurer/Left_Idle", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), 300, 0, 50, 36) },
                //{"Adventurer/Left_Idle2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Items", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                {"Adventurer/Left_Jump", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), 300, 72, 50, 36, isLooping:false) },
                //{"Adventurer/Left_LadderClimb", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                {"Adventurer/Left_Run", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), 250, 36, 50, 36) },
                //{"Adventurer/Left_Slide", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_RollDodge", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_Stand", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_SwordDraw", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_SwordSheat", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },
                //{"Adventurer/Left_WallSlide", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-SheetLeft"), , , 36, 50) },

                {"Environment/sheet.png", new Animation(Content.Load<Texture2D>("Environment/sheet"), 80, 128, 16, 32, isLooping: false) },
                //{ "", new Animation(Content.Load<Texture2D>(""), , ,) },
            };

            animations["Adventurer/Right_Jump"].AddFrame(100, 36);
            animations["Adventurer/Right_Run"].AddFrame(150, 36);
            animations["Adventurer/Right_Run"].AddFrame(200, 36);
            animations["Adventurer/Right_Run"].AddFrame(250, 36);
            animations["Adventurer/Right_Run"].AddFrame(300, 36);

            animations["Adventurer/Right_Idle"].AddFrame(50, 0);
            animations["Adventurer/Right_Idle"].AddFrame(100, 0);
            animations["Adventurer/Right_Idle"].AddFrame(150, 0);

            animations["Adventurer/Right_Jump"].AddFrame(50, 72);
            animations["Adventurer/Right_Jump"].AddFrame(100, 72);
            animations["Adventurer/Right_Jump"].AddFrame(150, 72);

            animations["Adventurer/Left_Run"].AddFrame(200,36);
            animations["Adventurer/Left_Run"].AddFrame(150,36);
            animations["Adventurer/Left_Run"].AddFrame(100,36);
            animations["Adventurer/Left_Run"].AddFrame(50,36);
            animations["Adventurer/Left_Run"].AddFrame(0,36);

            animations["Adventurer/Left_Idle"].AddFrame(300,0);
            animations["Adventurer/Left_Idle"].AddFrame(250,0);
            animations["Adventurer/Left_Idle"].AddFrame(200,0);

            animations["Adventurer/Left_Jump"].AddFrame(300,72);
            animations["Adventurer/Left_Jump"].AddFrame(250,72);
            animations["Adventurer/Left_Jump"].AddFrame(200,72);

            _sprites = new List<GameObject>()
            {
                new PlayerGameObject(animations)
                {
                    Position = new Vector2(100,100),
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
                },
                //new ControlledGameObject(animations)
                //{
                //    Position = new Vector2(150,100),
                //    Input = new Input()
                //    {
                //        Up = Keys.Up,
                //        Down = Keys.Down,
                //        Left = Keys.Left,
                //        Right = Keys.Right,

                //    },
                //},
            };
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);

            List<ICollidable> collidables = collisionManager.GetCollidableList(_sprites);
            for (int i = 0; i < collidables.Count-1; i++)
            {
                if (collidables[i] is MoveableGameObject)
                {
                for (int j = 0; i < collidables.Count-1; i++)
                    {
                        if (collisionManager.DetectCollision(collidables[i], collidables[j]))
                        {
                            collidables[i].Collide(collidables[j]);
                            if (collidables[j] is MoveableGameObject)
                                collidables[j].Collide(collidables[i]);
                        }
                    }
                }
            }
            //foreach (var spriteToCheck in collisionManager.GetCollidableList(_sprites))
            //{
            //    foreach (var sprite in _sprites)
            //    {
            //        if (collisionManager.DetectCollision(spriteToCheck, sprite))
            //        {
            //            GraphicsDevice.Clear(Color.FromNonPremultiplied(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256), 255));
            //        }
            //    }
            //}

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
