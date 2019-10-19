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
                {"WalkUp", new Animation(Content.Load<Texture2D>("Player/WalkUp"), 6) },
                {"WalkDown", new Animation(Content.Load<Texture2D>("Player/WalkDown"), 6) },
                {"WalkLeft", new Animation(Content.Load<Texture2D>("Player/WalkLeft"), 6) },
                {"WalkRight", new Animation(Content.Load<Texture2D>("Player/WalkRight"), 6) },
                {"Adventurer/AirAttack1", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-air-attack1"),4) },
                {"Adventurer/AirAttack2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-air-attack2"),3) },
                {"Adventurer/AirAttack3End", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-air-attack3-end"),3) },
                {"Adventurer/AirAttack3Loop", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-air-attack3-loop"),2) },
                {"Adventurer/AirAttack3Ready", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-air-attack3-rdy"),1) },
                {"Adventurer/Attack1", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-attack1"),5) },
                {"Adventurer/Attack2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-attack2"),6) },
                {"Adventurer/Attack3", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-attack3"),6) },
                {"Adventurer/Cast", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-cast"),4) },
                {"Adventurer/CastLoop", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-cast-loop"),4) },
                {"Adventurer/CornerClimb", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-crnr-clmb"),5) },
                {"Adventurer/CornerGrab", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-crnr-grb"),4) },
                {"Adventurer/CornerJump", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-crnr-jmp"),2) },
                {"Adventurer/Crouch", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-crouch"),4) },
                {"Adventurer/Die", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-die"),7) },
                {"Adventurer/Fall", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-fall"),2) },
                {"Adventurer/Hurt", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-hurt"),3) },
                {"Adventurer/Idle", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-idle"),4) },
                {"Adventurer/Idle2", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-idle-2"),4) },
                {"Adventurer/Items", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-items"),3) },
                {"Adventurer/Jump", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-jump"),4) },
                {"Adventurer/LadderClimb", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-ladder-climb"),4) },
                {"Adventurer/Run", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-run"),6) },
                {"Adventurer/Slide", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-slide"),2) },
                {"Adventurer/RollDodge", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-smrslt"),4) },
                {"Adventurer/Stand", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-stand"),3) },
                {"Adventurer/SwordDraw", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-swrd-drw"),4) },
                {"Adventurer/SwordSheat", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-swrd-shte"),4) },
                {"Adventurer/WallSlide", new Animation(Content.Load<Texture2D>("Adventurer/adventurer-wall-slide"),2) },
            };

            _sprites = new List<Sprite_Base>()
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
