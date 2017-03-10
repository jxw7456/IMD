using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
//JaJuan Webster
//Professor Cascioli
//Spaceship!

namespace Webster_HW_Project2_Asteroids
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Spaceship spaceship;
        Asteroid follower;
        List<Asteroid> asteroids;
        Bullet bullet;
        Background background;
        Texture2D astImg;
        Texture2D bulletImg;
        Texture2D bgOne;
        Texture2D bgTwo;
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
            rng = new Random();
            spaceship = new Spaceship();
            follower = new Asteroid();
            bullet = new Bullet(spaceship);
            asteroids = new List<Asteroid>();
            background = new Background();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spaceship.ship = Content.Load<Texture2D>("ship");
            astImg = Content.Load<Texture2D>("asteroid");
            bulletImg = Content.Load<Texture2D>("bullet");
            bgOne = Content.Load<Texture2D>("backgroundOne");
            bgTwo = Content.Load<Texture2D>("backgroundTwo");
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

            //Update methods
            for (int i = 0; i > asteroids.Count; i++)
            {
                asteroids[i].Update(spaceship);

                //Screenwrap for follower
                if (asteroids[i].position.X > (GraphicsDevice.Viewport.Width + 5))
                {
                    asteroids[i].position.X = -5;
                }

                else if (asteroids[i].position.X < -5)
                {
                    asteroids[i].position.X = (GraphicsDevice.Viewport.Width + 5);
                }

                if (asteroids[i].position.Y > (GraphicsDevice.Viewport.Height + 5))
                {
                    asteroids[i].position.Y = -5;
                }

                else if (asteroids[i].position.Y < -5)
                {
                    asteroids[i].position.Y = (GraphicsDevice.Viewport.Height + 5);
                }
            }

            //spaceship update
            spaceship.Update();

            //Screenwrap for Spaceship
            if (spaceship.position.X > (GraphicsDevice.Viewport.Width + 5))
            {
                spaceship.position.X = -5;
            }

            else if (spaceship.position.X < -5)
            {
                spaceship.position.X = (GraphicsDevice.Viewport.Width + 5);
            }

            if (spaceship.position.Y > (GraphicsDevice.Viewport.Height + 5))
            {
                spaceship.position.Y = -5;
            }

            else if (spaceship.position.Y < -5)
            {
                spaceship.position.Y = (GraphicsDevice.Viewport.Height + 5);
            }

            //bullet update
            bullet.Update(spaceship);

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
                spriteBatch.Draw(bgOne, new Vector2(0, 0), Color.White);
            }

            else
            {
                spriteBatch.Draw(bgTwo, new Vector2(0, 0), Color.White);
            }

            for (int i = 0; i > asteroids.Capacity; i++)
            {
                asteroids[i].Draw(spriteBatch, astImg, Color.White);
            }

            spaceship.Draw(spriteBatch, Color.White);

            //Draw Bullet using SPACE Key or LEFT BUTTON on mouse
            if (Keyboard.GetState().IsKeyDown(Keys.Space) || Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                bullet.Draw(spriteBatch, bulletImg, spaceship, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
