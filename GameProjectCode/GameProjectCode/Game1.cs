using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameProjectCode.Models;
using System;
using GameProjectCode.Objects;
using GameProjectCode.Manager;
using GameProjectCode.Factory;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace GameProjectCode
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        CollisionManager collisionManager;
        Sprite_Loader spriteLoader;
        ObjectInitialiser objectInitialiser;
        StageManager stageManager;
        Camera2D camera;
        Random r;
        PlayerGameObject hero;
        float rotation = 0;
        float zoom = 1;
        Vector2 camPos;
        private SpriteFont spriteFont;
        private int gameWidth = 1600;
        private int gameHeight = 960;
        SoundEffectManager soundEffectManager;
        Song backgroundSong;

        public Game1()
        {
            camPos = new Vector2();
            r = new Random();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            collisionManager = new CollisionManager();
            spriteLoader = new Sprite_Loader();
            objectInitialiser = new ObjectInitialiser();
            soundEffectManager = new SoundEffectManager();
            stageManager = new StageManager(new MenuManager(new Vector2(gameWidth/2-10, gameHeight/2)), new PlayerManager(), soundEffectManager);

            //Graphics
            graphics.PreferredBackBufferWidth = gameWidth;
            graphics.PreferredBackBufferHeight = gameHeight;
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
            camera = new Camera2D(GraphicsDevice.Viewport);
            //camera.
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

            var animations = spriteLoader.GetAnimationDictionary(Content);

            stageManager.AddPlayer(objectInitialiser.LoadPlayer(animations));
            stageManager.AddMenu(new Stage(objectInitialiser.LoadMenu(animations, 0, gameWidth, gameHeight), new Background(Content.Load<Texture2D>("Environment/MysticalForestMain"), new Rectangle(0, 0, 1601, 961)), stageManager.playerManager, false));
            stageManager.AddMenu(new Stage(objectInitialiser.LoadMenu(animations, 1, gameWidth, gameHeight), new Background(Content.Load<Texture2D>("Environment/MysticalForestMain"), new Rectangle(0, 0, 1601, 961)), stageManager.playerManager, false));
            stageManager.AddMenu(new Stage(objectInitialiser.LoadMenu(animations, 2, gameWidth, gameHeight), new Background(Content.Load<Texture2D>("Environment/MysticalDeadForest"), new Rectangle(0, 0, 1600, 965)), stageManager.playerManager, false));
            stageManager.AddStage(new Stage(objectInitialiser.LoadStage(animations, 1, gameWidth, gameHeight), new Background(Content.Load<Texture2D>("Environment/MysticalForest"), new Rectangle(0,0, 1613, 1008)), stageManager.playerManager));
            stageManager.GetPlayer().Position = new Vector2(69, 887);

            soundEffectManager.LoadSounds(Content);
            backgroundSong = Content.Load<Song>("Music/Frozen_Forest");

            MediaPlayer.Play(backgroundSong);
            MediaPlayer.IsRepeating = true;

            hero = (PlayerGameObject)stageManager.GetPlayer();
            spriteFont = Content.Load<SpriteFont>("Misc/basicFont");
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

            stageManager.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (stageManager.SelectedStage == -3)
                    Exit();
                else
                    stageManager.SelectedStage = -1;
            }

            if (stageManager.SelectedStage == -3)
                Exit();
            
            //Implement in stagemanager
            if (stageManager.SelectedStage > -1)
                collisionManager.DetectCollisions(stageManager.GetStage());

            stageManager.ResolveCollisions();

            // TODO: Add your update logic here
            KeyboardState stateKey = Keyboard.GetState();



            //if (stateKey.IsKeyDown(Keys.F1))
            //{
            //    camPos.X -= 1;
            //}
            //if (stateKey.IsKeyDown(Keys.F2))
            //{
            //    camPos.X += 1;
            //}
            //if (stateKey.IsKeyDown(Keys.F3))
            //{
            //    rotation += .1f;
            //}
            //if (stateKey.IsKeyDown(Keys.F4))
            //{
            //    rotation -= .1f;
            //}
            //if (stateKey.IsKeyDown(Keys.F5))
            //{
            //    zoom += .1f;
            //}
            //if (stateKey.IsKeyDown(Keys.F6))
            //{
            //    zoom -= .1f;
            //};

            if (stateKey.IsKeyDown(Keys.F5))
            {
                graphics.ToggleFullScreen();
            }

            //if (hero.IsMoving)
            //{
            //    camPos.X = hero.Position.X - GraphicsDevice.Viewport.Width / 2;
            //    //camPos.Y = hero.Position.Y - GraphicsDevice.Viewport.Height / 2;
            //}

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
            var viewMatrix = camera.GetViewMatrix();
            //_camera.Position = new Vector2(theHero.position.X - 200, theHero.position.Y - 300);// new Vector2(theHero.position.X + 200, theHero.position.Y+400);
            //camera.Origin = camPos;
            //camera.Rotation = rotation;
            //camera.Zoom = zoom;


            spriteBatch.Begin(transformMatrix: viewMatrix);

            //foreach (var sprite in _sprites)
            //    sprite.Draw(spriteBatch);

            //spriteBatch.DrawString(spriteFont, "Hello World", new Vector2(200, 300), Color.White);
            stageManager.Draw(spriteBatch, spriteFont);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
