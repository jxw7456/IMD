using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//JaJuan Webster
//Professor Cascioli
//MonoGame Vectors

namespace Webster_MonoGame_Vectors
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ShapeDrawer shapeDrawer;
        Random rand;
        Vector2 currentPos;
        Vector2 previousPos;
        float speed;

        Vector2 dir; //Vector direction to determine from random
        


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
            rand = new Random();
            IsMouseVisible = true;
            speed = 5.0f;          
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
            shapeDrawer = new ShapeDrawer(spriteBatch, GraphicsDevice);
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

            //Mouse State
            MouseState ms = Mouse.GetState();

            //Set previous position to current position
            previousPos = currentPos;
                        
            //Random direction
            int directon = rand.Next(8);
            
            //Random direction on Left Click
            int directonLeft = rand.Next(9);

            //If statement if Left Mouse Button is CLICKED
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                switch (directonLeft)
                {
                    case 0:
                        dir = new Vector2(0, -1);
                        break;

                    case 1:
                        dir = new Vector2(1, -2);
                        break;

                    case 2:
                        dir = new Vector2(1, 0);
                        break;

                    case 3:
                        dir = new Vector2(1, 2);
                        break;

                    case 4:
                        dir = new Vector2(0, 1);
                        break;

                    case 5:
                        dir = new Vector2(-1, 2);
                        break;

                    case 6:
                        dir = new Vector2(-1, 0);
                        break;

                    case 7:
                        dir = new Vector2(-1, -2);
                        break;

                    case 8:
                        dir = new Vector2(ms.X, ms.Y);
                        break;
                }
            }

            //If statement if Right Mouse Button is CLICKED
            else if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                dir = new Vector2(ms.X, ms.Y);
            }

            //If statement if NO Mouse Button is CLICKED
            else
            {
                switch (directon)
                {
                    case 0:
                        dir = new Vector2(0, -1);
                        break;

                    case 1:
                        dir = new Vector2(1, -2);
                        break;

                    case 2:
                        dir = new Vector2(1, 0);
                        break;

                    case 3:
                        dir = new Vector2(1, 2);
                        break;

                    case 4:
                        dir = new Vector2(0, 1);
                        break;

                    case 5:
                        dir = new Vector2(-1, 2);
                        break;

                    case 6:
                        dir = new Vector2(-1, 0);
                        break;

                    case 7:
                        dir = new Vector2(-1, -2);
                        break;
                }
            }            

            //Normalize direction
            dir.Normalize();

            //Multiple direction by the current speed
            dir.X = dir.X * speed;
            dir.Y = dir.Y * speed;

            //add random direction to current position to get a new position
            currentPos.X = currentPos.X + dir.X;
            currentPos.Y = currentPos.Y + dir.Y;

            //Increase speed if UP arrow key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Up) == true)
            {
                speed += 0.1f;
            }

            //Decrease speed if DOWN arrow key is pressed
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) == true)
            {
                speed -= 0.1f;
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
                        
            shapeDrawer.DrawLine(400, 200, (400 + (int)currentPos.X), (200 + (int)currentPos.Y), 3, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
