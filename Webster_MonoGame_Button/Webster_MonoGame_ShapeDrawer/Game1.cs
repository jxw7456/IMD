using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//JaJuan Webster
//Professor Cascioli
//MonoGame Button

namespace Webster_MonoGame_Button
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ShapeDrawer shapeDrawer;
        Texture2D img;
        Button button;

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
            // TODO: Add your initialization logic here

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
            img = Content.Load<Texture2D>("button");
            button = new Button(spriteBatch, img, Color.White, 20, 20);
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

            this.IsMouseVisible = true;

            //Button will ONLY change colors if the cursor is being clicked AND is inside of the button image
            if (button.Clicked() == true)
            {
                button.color = Color.Purple;
            }

            else
            {
                button.color = Color.White;
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
            
            //Draw the shapes from the last exercise
            if (button.Clicked() == true)
            {
                shapeDrawer.DrawLine(500, 200, 100, 100, 5, Color.Maroon);

                shapeDrawer.DrawPoint(400, 50, Color.Green);

                shapeDrawer.DrawRectFilled(300, 400, 50, 50, Color.Bisque);

                shapeDrawer.DrawRectOutline(500, 200, 50, 50, Color.Blue);
            }      
            
            //Draws the button image
            button.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
