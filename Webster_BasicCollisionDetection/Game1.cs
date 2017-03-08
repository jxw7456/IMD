﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//JaJuan Webster
//Professor Cascioli
//Basic Collision Detection

namespace Webster_BasicCollisionDetection
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Circle circleOne;
        Circle circleTwo;
        AABB aabbOne;
        AABB aabbTwo;
        Texture2D circle;
        Texture2D rectangle;
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
            circleOne = new Circle(rng.Next(400, 600), rng.Next(5, 400), rng.Next(25, 75));
            circleTwo = new Circle(rng.Next(400, 600), rng.Next(5, 400), rng.Next(25, 75));
            aabbOne = new AABB(rng.Next(5, 250), rng.Next(5, 250), rng.Next(100, 200), rng.Next(100, 200));
            aabbTwo = new AABB(rng.Next(5, 250), rng.Next(5, 250), rng.Next(100, 200), rng.Next(100, 200));

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
            circle = Content.Load<Texture2D>("circle");
            rectangle = Content.Load<Texture2D>("rectangle");
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

            //Set new position and size for rectangle if "A" is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                aabbOne = new AABB(rng.Next(5, 250), rng.Next(5, 250), rng.Next(100, 200), rng.Next(100, 200));
                aabbTwo = new AABB(rng.Next(5, 250), rng.Next(5, 250), rng.Next(100, 200), rng.Next(100, 200));
            }

            //Set new position and radii for circle if "C" is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                circleOne = new Circle(rng.Next(400, 600), rng.Next(5, 400), rng.Next(25, 75));
                circleTwo = new Circle(rng.Next(400, 600), rng.Next(5, 400), rng.Next(25, 75));
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

            //Draw Rectangles and Circles white
            spriteBatch.Draw(circle, new Rectangle((int)circleOne.X, (int)circleOne.Y, (int)(circleOne.Radius * 2), (int)(circleOne.Radius * 2)), Color.White);
            spriteBatch.Draw(circle, new Rectangle((int)circleTwo.X, (int)circleTwo.Y, (int)(circleTwo.Radius * 2), (int)(circleTwo.Radius * 2)), Color.White);
            spriteBatch.Draw(rectangle, new Rectangle((int)aabbOne.X, (int)aabbOne.Y, (int)aabbOne.Width, (int)aabbOne.Height), Color.White);
            spriteBatch.Draw(rectangle, new Rectangle((int)aabbTwo.X, (int)aabbTwo.Y, (int)aabbTwo.Width, (int)aabbTwo.Height), Color.White);

            //If circles intersect, change their color to red
            if (circleOne.Intersects(circleTwo) == true)
            {
                spriteBatch.Draw(circle, new Rectangle((int)circleOne.X, (int)circleOne.Y, (int)(circleOne.Radius * 2), (int)(circleOne.Radius * 2)), Color.Red);
                spriteBatch.Draw(circle, new Rectangle((int)circleTwo.X, (int)circleTwo.Y, (int)(circleTwo.Radius * 2), (int)(circleTwo.Radius * 2)), Color.Red);
            }

            //If rectangles intersect, change their color to red
            if (aabbOne.Intersects(aabbTwo) == true)
            {
                spriteBatch.Draw(rectangle, new Rectangle((int)aabbOne.X, (int)aabbOne.Y, (int)aabbOne.Width, (int)aabbOne.Height), Color.Red);
                spriteBatch.Draw(rectangle, new Rectangle((int)aabbTwo.X, (int)aabbTwo.Y, (int)aabbTwo.Width, (int)aabbTwo.Height), Color.Red);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
