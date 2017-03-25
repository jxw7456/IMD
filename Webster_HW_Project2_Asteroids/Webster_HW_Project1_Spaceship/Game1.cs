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
        GameManager game;
        SpriteBatch spriteBatch;
        Spaceship spaceShip;
        List<Texture2D> lives;
        List<Follower> asteroids;
        List<Follower> newAsteroids;
        Bullet fire;
        List<Bullet> bullets;
        Circle circle;
        Background background;
        Texture2D shipImg;
        Texture2D astroidImg;
        Texture2D bulletImg;
        Texture2D bgOne;
        Texture2D bgTwo;
        Random rng;
        Song bgMusic;
        KeyboardState prevKey;
        SpriteFont bold;
        SpriteFont menu;
        bool alive;

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
            //Fields
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipImg = Content.Load<Texture2D>("ship");
            astroidImg = Content.Load<Texture2D>("asteroid");
            bulletImg = Content.Load<Texture2D>("bullet");
            bgOne = Content.Load<Texture2D>("backgroundOne");
            bgTwo = Content.Load<Texture2D>("backgroundTwo");
            bold = Content.Load<SpriteFont>("boldFont");
            menu = Content.Load<SpriteFont>("menu");
            bgMusic = Content.Load<Song>("bgMusic");
            MediaPlayer.Play(bgMusic);
            rng = new Random();
            spaceShip = new Spaceship(shipImg);
            asteroids = new List<Follower>();
            newAsteroids = new List<Follower>();
            fire = new Bullet();
            bullets = new List<Bullet>();
            lives = new List<Texture2D>();
            circle = new Circle(spriteBatch, GraphicsDevice);
            background = new Background();
            alive = true;
            game = new GameManager();
            game.state = GameState.START;

            //Create list of asteroids
            for (int i = 0; i < 5; i++)
            {
                asteroids.Add(new Follower(GraphicsDevice, rng, new Rectangle(0, 0, astroidImg.Width, astroidImg.Height), astroidImg));
            }

            //Create list of lives
            for (int i = 0; i < 3; i++)
            {
                lives.Add(shipImg);
            }

            for (int i = 0; i < 3; i++)
            {
                spaceShip.lives.Add(alive);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

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

            //Switch statement for game states
            switch (game.state)
            {
                //START MENU
                case GameState.START:
                    if (Keyboard.GetState().IsKeyDown(Keys.F3))
                    {
                        game.state = GameState.GAME;
                    }
                    break;

                //GAME MENU
                case GameState.GAME:
                    //Randomize for the optional images
                    if (rng.Next(0, 3) == 0)
                    {
                        astroidImg = Content.Load<Texture2D>("asteroid");
                    }

                    else if (rng.Next(0, 3) == 1)
                    {
                        astroidImg = Content.Load<Texture2D>("2asteroid");
                    }

                    else if (rng.Next(0, 3) == 2)
                    {
                        astroidImg = Content.Load<Texture2D>("3asteroid");
                    }

                    //foreach loop for asteroid update
                    foreach (Follower f in asteroids)
                    {
                        f.Update(spaceShip, GraphicsDevice);

                        //the asteroid intersects ONLY when the ship is active
                        if (f.Intersects(spaceShip, astroidImg) == true && spaceShip.isActive == true)
                        {
                            spaceShip.isActive = false;

                            spaceShip.position.X = 2000;    //move ship off the screen
                            spaceShip.position.Y = 2000;
                            spaceShip.lives[spaceShip.i] = false;
                            spaceShip.i = spaceShip.i - 1;
                        }

                        if (spaceShip.isActive == false)
                        {
                            spaceShip.timer++;

                            //move the ship back onto the screen
                            if (spaceShip.timer >= 600.0f)
                            {
                                spaceShip.position.X = 400;
                                spaceShip.position.Y = 200;
                                spaceShip.timer = 0.0f;
                                spaceShip.speed = 0.0f;
                                spaceShip.rotation = 4.75f;
                                spaceShip.isActive = true;
                            }
                        }
                    }

                    //foreach loop for the second stage of asteroids
                    foreach (Follower f in newAsteroids)
                    {
                        f.Update(spaceShip, GraphicsDevice);

                        //the asteroid intersects ONLY when the ship is active
                        if (f.Intersects(spaceShip, astroidImg) == true && spaceShip.isActive == true)
                        {
                            spaceShip.isActive = false;
                            spaceShip.position.X = 2000;    //move ship off the screen
                            spaceShip.position.Y = 2000;
                            spaceShip.lives[spaceShip.i] = false;
                            spaceShip.i = spaceShip.i - 1;
                        }

                        if (spaceShip.isActive == false)
                        {
                            spaceShip.timer++;

                            //move the ship back onto the screen
                            if (spaceShip.timer >= 600.0f)
                            {
                                spaceShip.position.X = 400;
                                spaceShip.position.Y = 200;
                                spaceShip.timer = 0.0f;
                                spaceShip.speed = 0.0f;
                                spaceShip.rotation = 4.75f;
                                spaceShip.isActive = true;
                            }
                        }
                    }

                    //foreach loop for checking bullet collision
                    foreach (Bullet b in bullets)
                    {
                        for (int i = 0; i < asteroids.Count; i++)
                        {
                            if (b.Intersects(asteroids[i], bulletImg, astroidImg) == true)
                            {
                                fire.score += 100;
                                b.isActive = false;
                                newAsteroids.Add(new Follower(GraphicsDevice, rng, new Rectangle(0, 0, astroidImg.Width, astroidImg.Height), astroidImg));
                                newAsteroids.Add(new Follower(GraphicsDevice, rng, new Rectangle(0, 0, astroidImg.Width, astroidImg.Height), astroidImg));
                                asteroids.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < newAsteroids.Count; i++)
                        {
                            if (b.Intersects(newAsteroids[i], bulletImg, astroidImg) == true)
                            {
                                fire.score += 100;
                                newAsteroids.RemoveAt(i);
                            }
                        }
                    }


                    //shoot bullets ONLY if the ship is active
                    if (spaceShip.isActive == true)
                    {
                        //bullet update
                        if (Keyboard.GetState().IsKeyDown(Keys.Space) && prevKey.IsKeyUp(Keys.Space))
                        {
                            fire.Shoot(bullets, spaceShip);
                        }

                        prevKey = Keyboard.GetState();
                        fire.UpdateBullets(bullets, spaceShip);
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

                    if (spaceShip.i == 0)
                    {
                        MediaPlayer.Stop();
                        game.state = GameState.GAMEOVER;
                    }

                    break;

                //GAME OVER MENU
                case GameState.GAMEOVER:
                    if (Keyboard.GetState().IsKeyDown(Keys.F3))
                    {
                        //Reset key attritbutes
                        MediaPlayer.Play(bgMusic);
                        spaceShip.forward = new Vector2((float)Math.Cos(spaceShip.rotation), (float)Math.Sin(spaceShip.rotation));
                        spaceShip.position.X = 400;
                        spaceShip.position.Y = 200;
                        spaceShip.timer = 0.0f;
                        spaceShip.speed = 0.0f;
                        spaceShip.rotation = 4.75f;
                        spaceShip.isActive = true;
                        spaceShip.i = 2;
                        fire.score = 0;
                        asteroids.Clear();
                        newAsteroids.Clear();

                        //Create new list of lives
                        for (int i = 0; i < 3; i++)
                        {
                            lives.Add(shipImg);
                        }

                        //Create new list of asteroids
                        for (int i = 0; i < 5; i++)
                        {
                            asteroids.Add(new Follower(GraphicsDevice, rng, new Rectangle(0, 0, astroidImg.Width, astroidImg.Height), astroidImg));
                        }
                        game.state = GameState.GAME;
                    }
                    break;
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

            //Switch case for drawing proper images on the correct Scene!
            switch (game.state)
            {
                //START MENU
                case GameState.START:
                    //Drawing the background image using the Random Gaussian
                    if (RandomExtensionMethods.Gaussian(rng, 4.5, 1.8) > 4.5)
                    {
                        spriteBatch.Draw(bgOne, new Vector2(0, 0), Color.DarkGray);
                    }

                    else
                    {
                        spriteBatch.Draw(bgTwo, new Vector2(0, 0), Color.DarkGray);
                    }
                    spriteBatch.DrawString(menu, "ASTEROIDS", new Vector2(200, 200), Color.White);
                    spriteBatch.DrawString(menu, "press 'F3' to start", new Vector2(200, 250), Color.White);
                    break;

                //GAME MENU
                case GameState.GAME:
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
                        f.Draw(spriteBatch, Color.White);
                    }

                    //draw all the asteroids
                    foreach (Follower f in newAsteroids)
                    {
                        f.DrawNewAsteroids(spriteBatch, Color.White);
                    }

                    foreach (Bullet b in bullets)
                    {
                        if (spaceShip.isActive == true)
                        {
                            b.Draw(spriteBatch, bulletImg, spaceShip);
                        }
                    }

                    if (spaceShip.lives[0] == true)
                    {
                        spriteBatch.Draw(shipImg, new Rectangle(1, 20, (shipImg.Width / 4), (shipImg.Height / 4)), Color.White);
                    }

                    if (spaceShip.lives[1] == true)
                    {
                        spriteBatch.Draw(shipImg, new Rectangle(30, 20, (shipImg.Width / 4), (shipImg.Height / 4)), Color.White);
                    }

                    if (spaceShip.lives[2] == true)
                    {
                        spriteBatch.Draw(shipImg, new Rectangle(59, 20, (shipImg.Width / 4), (shipImg.Height / 4)), Color.White);
                    }

                    spriteBatch.DrawString(bold, "Score: " + fire.score, Vector2.One, Color.White);

                    if (fire.score == 1500)
                    {
                        spriteBatch.DrawString(menu, "YOU WIN!", new Vector2(300, 200), Color.White);
                    }
                    break;

                //GAME OVER MENU
                case GameState.GAMEOVER:
                    //Drawing the background image using the Random Gaussian
                    if (RandomExtensionMethods.Gaussian(rng, 4.5, 1.8) > 4.5)
                    {
                        spriteBatch.Draw(bgOne, new Vector2(0, 0), Color.DarkGray);
                    }

                    else
                    {
                        spriteBatch.Draw(bgTwo, new Vector2(0, 0), Color.DarkGray);
                    }
                    spriteBatch.DrawString(bold, "Score: " + fire.score, Vector2.One, Color.White);
                    spriteBatch.DrawString(menu, "GAME OVER", new Vector2(200, 200), Color.White);
                    spriteBatch.DrawString(menu, "press 'F3' to start", new Vector2(200, 250), Color.White);

                    //draw all the asteroids
                    foreach (Follower f in asteroids)
                    {
                        f.Draw(spriteBatch, Color.White);
                    }

                    //draw all the asteroids
                    foreach (Follower f in newAsteroids)
                    {
                        f.DrawNewAsteroids(spriteBatch, Color.White);
                    }
                    break;

            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
