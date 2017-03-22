﻿using Microsoft.Xna.Framework;
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
        List<Bullet> bullets;
        Background background;
        Texture2D astroidImage;
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
            rng = new Random();
            spaceShip = new Spaceship();
            asteroids = new List<Follower>();
            bullets = new List<Bullet>();
            background = new Background();
            spaceShip.ship = Content.Load<Texture2D>("ship");
            astroidImage = Content.Load<Texture2D>("asteroid");
            bulletImg = Content.Load<Texture2D>("bullet");
            bgOne = Content.Load<Texture2D>("backgroundOne");
            bgTwo = Content.Load<Texture2D>("backgroundTwo");
            bgMusic = Content.Load<Song>("bgMusic");
            MediaPlayer.Play(bgMusic);

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
            }

            //bullet update
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && prevKey.IsKeyUp(Keys.Space))
            {
                Shoot();
            }

            prevKey = Keyboard.GetState();
            UpdateBullets();

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
            foreach (Follower f in asteroids)
            {
                f.Draw(spriteBatch, astroidImage, Color.White);
            }

            foreach (Bullet b in bullets)
            {
                b.Draw(spriteBatch, bulletImg, spaceShip);
            }
            
            //draw the spaceShip
            spaceShip.Draw(spriteBatch, Color.White);



            spriteBatch.End();

            base.Draw(gameTime);
        }

        //Update moving and removing bullets from list
        public void UpdateBullets()
        {
            foreach (Bullet b in bullets)
            {
                b.bulletPos += b.velocity;

                if (Vector2.Distance(b.bulletPos, spaceShip.position) > 900)
                {
                    b.isActive = false;
                }

            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isActive)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        //Update method
        public void Shoot()
        {
            Bullet newBullet = new Bullet();
            newBullet.velocity = new Vector2((float)(Math.Cos(spaceShip.rotation)), (float)Math.Sin(spaceShip.rotation)) * 5.0f + spaceShip.velocity;
            newBullet.bulletPos.X += ((spaceShip.Position.X - 20) + newBullet.velocity.X * 15.0f);
            newBullet.bulletPos.Y += (spaceShip.Position.Y + newBullet.velocity.Y * 15.0f);
            newBullet.isActive = true;

            if (bullets.Count < 20)
            {
                bullets.Add(newBullet);
            }
        }
    }
}
