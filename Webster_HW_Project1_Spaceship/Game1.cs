using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//JaJuan Webster
//Professor Cascioli
//Spaceship!

namespace Webster_HW_Project1_Spaceship
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Spaceship spaceShip;
        Follower follower;
        Background background;
        Texture2D bgImageOne;
        Texture2D bgImageTwo;
        Random rng;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            rng = new Random();
            spaceShip = new Spaceship();
            follower = new Follower();
            background = new Background();
            spaceShip.ship = Content.Load<Texture2D>("ship");
            follower.asteroids = Content.Load<Texture2D>("asteroid");
            bgImageOne = Content.Load<Texture2D>("backgroundOne");
            bgImageTwo = Content.Load<Texture2D>("backgroundTwo");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
                        
            follower.Update();
            spaceShip.Update();

            //Screenwrap for Spaceship
            if (spaceShip.position.X > (GraphicsDevice.Viewport.Width + 5))
            {
                spaceShip.position.X = -5;
            }

            else if (spaceShip.position.X < -5)
            {
                spaceShip.position.X = (GraphicsDevice.Viewport.Width + 5);
            }

            if (spaceShip.position.Y > (GraphicsDevice.Viewport.Height + 5))
            {
                spaceShip.position.Y = -5;
            }

            else if (spaceShip.position.Y < -5)
            {
                spaceShip.position.Y = (GraphicsDevice.Viewport.Height + 5);
            }

            //Screenwrap for Follower
            if (follower.astPosition.X > (GraphicsDevice.Viewport.Width + 5))
            {
                follower.astPosition.X = -5;
            }

            else if (follower.astPosition.X < -5)
            {
                follower.astPosition.X = (GraphicsDevice.Viewport.Width + 5);
            }

            if (follower.astPosition.Y > (GraphicsDevice.Viewport.Height + 5))
            {
                follower.astPosition.Y = -5;
            }

            else if (follower.astPosition.Y < -5)
            {
                follower.astPosition.Y = (GraphicsDevice.Viewport.Height + 5);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            //Drawing the background image using the Random Gaussian
            if (RandomExtensionMethods.Gaussian(rng, 4.5, 1.8) > 4.5)
            {
                spriteBatch.Draw(bgImageOne, new Vector2(0, 0), Color.White);
            }

            else
            {
                spriteBatch.Draw(bgImageTwo, new Vector2(0, 0), Color.White);
            }

            follower.Draw(spriteBatch, Color.White);

            spaceShip.Draw(spriteBatch, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
