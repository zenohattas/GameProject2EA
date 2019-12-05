using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameProjectCode.Models;
using System;
using GameProjectCode.Objects;
using GameProjectCode.Manager;
using GameProjectCode.Factory;

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
        Random r = new Random();
        PlayerGameObject hero;
        float rotation = 0;
        float zoom = 1;
        Vector2 camPos = new Vector2();
        private SpriteFont spriteFont;

        private List<GameObject> _sprites;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            collisionManager = new CollisionManager();
            spriteLoader = new Sprite_Loader();
            objectInitialiser = new ObjectInitialiser();
            stageManager = new StageManager(new MenuManager(), new PlayerManager());
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

            stageManager.AddStage(new Stage(objectInitialiser.LoadStage(animations, objectInitialiser.Stage1, objectInitialiser.Stage1Background), new Background(Content.Load<Texture2D>("Environment/Desert"), new Rectangle(0,0, 1279, 639))));
            stageManager.AddPlayer(objectInitialiser.LoadPlayer(animations));

            hero = (PlayerGameObject)stageManager.GetPlayer();
            spriteFont = Content.Load<SpriteFont>("Misc/basicFont");
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

            stageManager.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (stageManager.SelectedStage == -2)
                    Exit();
                else
                    stageManager.SelectedStage = -1;
            }

            if (stageManager.SelectedStage == -2)
                Exit();
            
            //Implement in stagemanager
            if (stageManager.SelectedStage > -1)
                collisionManager.DetectCollisions(stageManager.GetStage());

            stageManager.ResolveCollisions();

            // TODO: Add your update logic here
            KeyboardState stateKey = Keyboard.GetState();



            if (stateKey.IsKeyDown(Keys.F1))
            {
                camPos.X -= 1;
            }
            if (stateKey.IsKeyDown(Keys.F2))
            {
                camPos.X += 1;
            }
            if (stateKey.IsKeyDown(Keys.F3))
            {
                rotation += .1f;
            }
            if (stateKey.IsKeyDown(Keys.F4))
            {
                rotation -= .1f;
            }
            if (stateKey.IsKeyDown(Keys.F5))
            {
                zoom += .1f;
            }
            if (stateKey.IsKeyDown(Keys.F6))
            {
                zoom -= .1f;
            };

            if (hero.IsMoving)
            {
                camPos.X = hero.Position.X - GraphicsDevice.Viewport.Width / 2;
                camPos.Y = hero.Position.Y - GraphicsDevice.Viewport.Height / 2;
            }

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
            var viewMatrix = camera.GetViewMatrix();
            //_camera.Position = new Vector2(theHero.position.X - 200, theHero.position.Y - 300);// new Vector2(theHero.position.X + 200, theHero.position.Y+400);
            camera.Position = camPos;
            camera.Rotation = rotation;
            camera.Zoom = zoom;


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
