using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//JaJuan Webster
//Professor Cascioli
//MonoGame Random

namespace Webster_MonoGame_Random
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
        Random rng;
        GameState gameState;

        enum GameState
        {
            TAB = Keys.Tab,
            SHIFT = Keys.LeftShift
        }

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
            rng = new Random();
            gameState = GameState.TAB;
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

            //TAB Game State with multi color changes
            if (gameState == GameState.TAB)
            {
                //Button will ONLY change colors if the cursor is being clicked AND is inside of the button image
                if (RandomExtensionMethods.Gaussian(rng, 4.5, 1.8) > 4.5)
                {
                    button.color = Color.Blue;
                }

                else if (RandomExtensionMethods.Gaussian(rng, 4.5, 1.8) < 4.5)
                {
                    button.color = Color.IndianRed;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    gameState = GameState.SHIFT;
                }
            }

            //SHIFT Game State with Shapes
            if (gameState == GameState.SHIFT)
            {
                double pn = RandomExtensionMethods.PerlinNoise(rng, 0.001);

                if (pn > 0.5)
                {
                    button.color = Color.Purple;
                }

                else if (pn < 0.5)
                {
                    button.color = Color.Green;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                {
                    gameState = GameState.TAB;
                }
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

            if (gameState == GameState.SHIFT)
            {
                shapeDrawer.DrawLine(500, 200, 100, 100, 5, Color.Fuchsia);

                shapeDrawer.DrawPoint(400, 50, Color.GhostWhite);

                shapeDrawer.DrawRectFilled(300, 400, 50, 50, Color.Maroon);

                shapeDrawer.DrawRectOutline(500, 200, 50, 50, Color.DarkGoldenrod);
            }

            //Draws the button image
            button.Draw();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
