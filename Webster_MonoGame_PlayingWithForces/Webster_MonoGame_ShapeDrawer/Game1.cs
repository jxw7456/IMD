using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

//JaJuan Webster
//Professor Cascioli
//Playing With Forces

namespace Webster_MonoGame_PlayingWithForces
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
        Texture2D img;
        List<Mover> movers;
        int startX;
        int startY;
        int screenWidth;
        int screenHeight;

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
            IsMouseVisible = true;
            rand = new Random();
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
            img = Content.Load<Texture2D>("laser");
            movers = new List<Mover>();
            startX = -50;
            startY = -50;
            screenWidth = GraphicsDevice.Viewport.Width - 50;
            screenHeight = GraphicsDevice.Viewport.Height - 50;
            for (int i = 0; i < 4; i++)
            {
                movers.Add(new Mover(rand.Next(0, screenWidth), rand.Next(0, screenHeight), new Vector2(rand.Next(4, 7), rand.Next(4, 7)), img, spriteBatch));
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

            MouseState mouse = Mouse.GetState();
            foreach (Mover m in movers)
            {
                Vector2 cursor = new Vector2((m.position.X - mouse.X), (m.position.Y - mouse.Y));
                cursor *= 0.05f;

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    m.AddForce(cursor);
                }

                m.ApplyFriction(0.5f);
                m.FinalizeMovement();
                Bounce();
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

            foreach (Mover m in movers)
            {
                m.Draw();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// checks object boundraries and moves them back onto the screen
        /// </summary>
        public void Bounce()
        {
            foreach (Mover m in movers)
            {
                //Check ScreenX Edge Start
                if (m.position.X < startX)
                {
                    m.velocity.X *= -1.0f;
                    m.position.X = startX;
                }

                //Check ScreenX Edge Width
                if (m.position.X > screenWidth)
                {
                    m.velocity.X *= -1.0f;
                    m.position.X = screenWidth;
                }

                //Check ScreenY Edge Start
                if (m.position.Y < startY)
                {
                    m.velocity.Y *= -1.0f;
                    m.position.Y = startY;
                }

                //Check ScreenY Edge Height
                if (m.position.Y > screenHeight)
                {
                    m.velocity.Y *= -1.0f;
                    m.position.Y = screenHeight;
                }
            }
        }
    }
}
