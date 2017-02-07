using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//SHAPES DEMO

namespace Webster_ShapesDemo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //pixel
        private Texture2D pixel;

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
            //make a pixel texture and fill it
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

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

            //Attempt to draw 3 line
            DrawLine(0, 0, 100, 100, 1, Color.White);
            DrawLine(100, 100, 200, 100, 12, Color.Red);
            DrawLine(200, 100, 300, 0, 3, Color.LightGreen);

            //Random lines drawn
            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                DrawLine(rand.Next(0, 800), rand.Next(0, 600), rand.Next(0, 400), rand.Next(0, 200), rand.Next(0, 10), new Color (rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Draws and arbitrary line on the screen. This assumes that spritebatch.Begin() has already been called.
        /// </summary>
        /// <param name="x0">X coord for first point</param>
        /// <param name="y0">Y coord for first point</param>
        /// <param name="x1">X coord for second point</param>
        /// <param name="y1">Y coord for second point</param>
        /// <param name="thickness">"width" of the line</param>
        /// <param name="color">color of the line</param>
        public void DrawLine(int x0, int y0, int x1, int y1, int thickness, Color color)
        {
            //Calculate the length of the line
            float length = Vector2.Distance(new Vector2(x0, y0), new Vector2(x1, y1));

            //Calculate the angle between our desired line and the x axis
            float angle = (float)Math.Atan2(y1 - y0, x1 - x0);

            //Create the rectangle we intend to draw
            Rectangle rectToDraw = new Rectangle(x0, y0, (int)length, thickness);

            //Use the Draw() overload that accepts a rotation
            spriteBatch.Draw(pixel, rectToDraw, null, color, angle, new Vector2(0.0f, 0.5f), SpriteEffects.None, 0.0f);
        }
    }
}
