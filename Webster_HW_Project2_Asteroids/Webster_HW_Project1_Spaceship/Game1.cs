using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

//JaJuan Webster
//Professor Cascioli
//Asteroids!
//ABOVE AND BEYOND: Background Music

namespace Webster_HW_Project2_Asteroids
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
        Bullet fire;
        List<Bullet> bullets;
        Circle circle;
        Background background;
        Texture2D shipImg;
        Texture2D astroidImg;
        Texture2D astroidImg2;
        Texture2D astroidImg3;
        Texture2D bulletImg;
        Texture2D bgOne;
        Texture2D bgTwo;
        Random rng;
        Song bgMusic;
        KeyboardState prevKey;

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
            shipImg = Content.Load<Texture2D>("ship");
            astroidImg = Content.Load<Texture2D>("asteroid");
            astroidImg2 = Content.Load<Texture2D>("2asteroid");
            astroidImg3 = Content.Load<Texture2D>("3asteroid");
            bulletImg = Content.Load<Texture2D>("bullet");
            bgOne = Content.Load<Texture2D>("backgroundOne");
            bgTwo = Content.Load<Texture2D>("backgroundTwo");
            bgMusic = Content.Load<Song>("bgMusic");
            MediaPlayer.Play(bgMusic);
            rng = new Random();
            spaceShip = new Spaceship(shipImg);
            asteroids = new List<Follower>();
            fire = new Bullet();
            bullets = new List<Bullet>();
            circle = new Circle(spriteBatch, GraphicsDevice);
            background = new Background();

            //Create list of asteroids
            for (int i = 0; i < 5; i++)
            {
                asteroids.Add(new Follower(GraphicsDevice, rng.Next(0, 3), rng));
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
            foreach (Follower f in asteroids)
            {
                f.Update(spaceShip, GraphicsDevice);
                if (f.Intersects(spaceShip, astroidImg) == true)
                {
                    spaceShip.isActive = false;
                    spaceShip.timer += 1.0f;
                    spaceShip.position.X = 1000;
                    spaceShip.position.Y = 1000;

                    if (spaceShip.timer >= 60.0f)
                    {
                        spaceShip.position.X = 400;
                        spaceShip.position.Y = 200;
                        spaceShip.timer = 0.0f;
                        spaceShip.isActive = true;
                    }
                }
            }            

            //bullet update
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && prevKey.IsKeyUp(Keys.Space))
            {
                fire.Shoot(bullets, spaceShip);
            }

            prevKey = Keyboard.GetState();
            fire.UpdateBullets(bullets, spaceShip);

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


            if (spaceShip.isActive == true)
            {
                spaceShip.Draw(spriteBatch, Color.White);
            }


            //draw all the asteroids
            foreach (Follower f in asteroids)
            {
                f.Draw(spriteBatch, astroidImg, Color.White);
                circle.DrawCircle((int)f.position.X, (int)f.position.Y, astroidImg.Width / 3, 1000, Color.Red);                
            }

            foreach (Bullet b in bullets)
            {
                b.Draw(spriteBatch, bulletImg, spaceShip);
                circle.DrawCircle((int)b.bulletPos.X + 18, (int)b.bulletPos.Y + 20, bulletImg.Width / 3, 1000, Color.Green);
                foreach (Follower f in asteroids)
                {
                    if (b.Intersects(f, bulletImg, astroidImg) == true)
                    {                        
                        Follower astSplit = new Follower(GraphicsDevice, rng.Next(0, 3), rng);
                        Follower astSplit2 = new Follower(GraphicsDevice, rng.Next(0, 3), rng);
                        asteroids.Add(astSplit);
                        asteroids.Add(astSplit2);
                        spriteBatch.Draw(astroidImg2, new Rectangle((int)f.position.X, (int)f.position.Y, astroidImg2.Width, astroidImg2.Height), Color.White);
                        spriteBatch.Draw(astroidImg3, new Rectangle((int)f.position.X, (int)f.position.Y, astroidImg2.Width, astroidImg2.Height), Color.White);
                        //asteroids.Remove(f);
                    }
                }
            }

            circle.DrawCircle((int)spaceShip.position.X, (int)spaceShip.position.Y, spaceShip.ship.Width / 2, 1000, Color.Blue);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
