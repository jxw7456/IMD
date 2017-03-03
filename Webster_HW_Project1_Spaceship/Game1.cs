using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
//JaJuan Webster
//Professor Cascioli
//Spaceship!
//ABOVE AND BEYOND: Background Music

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
        List<Follower> asteroids;
        Background background;
        Texture2D astroidImage;
        Texture2D bgOne;
        Texture2D bgTwo;
        Random rng;
        Song bgMusic;

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
            asteroids = new List<Follower>();
            background = new Background();
            spaceShip.ship = Content.Load<Texture2D>("ship");
            astroidImage = Content.Load<Texture2D>("asteroid");
            bgOne = Content.Load<Texture2D>("backgroundOne");
            bgTwo = Content.Load<Texture2D>("backgroundTwo");
            bgMusic = Content.Load<Song>("bgMusic");
            MediaPlayer.Play(bgMusic);

            //Add followers to the list of asteroids
            for (int i = 0; i < 10; i++)
            {
                asteroids.Add(new Follower(new Rectangle(rng.Next(0, 600), rng.Next(0, 200), 
                    rng.Next(60, 150), rng.Next(60, 150)), 
                    rng.Next(7)));  //Random position, size, and speed
            }
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
            
            //foreach loop for asteroid update
            foreach(Follower f in asteroids)
            {
                f.Update(spaceShip);
            }

            //spaceShip update
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

            //draw all the asteroids
            foreach(Follower f in asteroids)
            {
                f.Draw(spriteBatch, astroidImage, Color.White);
            }

            //draw the spaceShip
            spaceShip.Draw(spriteBatch, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
