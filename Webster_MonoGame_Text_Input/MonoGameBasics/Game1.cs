using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//NAME: JaJuan Webster
//INSTRUCTOR: Chris Cascioli
//MonoGame Text & Input

namespace Webster_MonoGame_Text_Input
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Attributes
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont arialBold;
        Texture2D background;
        Texture2D luigi;
        Vector2 luigiPos;
        Vector2 mousePos;
        
        //Constructor
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
            luigiPos.X = 300;   //Set image at Center of the window
            luigiPos.Y = 150;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            arialBold = Content.Load<SpriteFont>("Arial14Bold");
            background = Content.Load<Texture2D>("background");
            luigi = Content.Load<Texture2D>("luigi");
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

            KeyboardState kb = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            
            //gets the mouse position
            if (ms.LeftButton == ButtonState.Pressed)
            {
                mousePos.X = ms.X;
                mousePos.Y = ms.Y;
            }

            //gets keyboard imput
            if (kb.IsKeyDown(Keys.W))
            {
                luigiPos.Y -= 5.0f;
            }

            if (kb.IsKeyDown(Keys.A))
            {
                luigiPos.X -= 5.0f;
            }

            if (kb.IsKeyDown(Keys.S))
            {
                luigiPos.Y += 5.0f;
            }

            if (kb.IsKeyDown(Keys.D))
            {
                luigiPos.X += 5.0f;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);

            spriteBatch.Begin();
                        
            spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.Draw(luigi, new Vector2(luigiPos.X, luigiPos.Y), Color.White);
            spriteBatch.DrawString(arialBold, "Image X: " + luigiPos.X + "\nImage Y: " + luigiPos.Y, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(arialBold, "Mouse X: " + mousePos.X + "\nMouse Y: " + mousePos.Y, new Vector2(0, 45), Color.White);

            //Statement if the mouse position is "inside" the image
            if (mousePos.X >= luigiPos.X && mousePos.X <= luigi.Width || mousePos.Y >= luigiPos.Y && mousePos.Y <= luigi.Height)
            {
                spriteBatch.DrawString(arialBold, "Super Mario Bros.", new Vector2(300, 200), Color.Red);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
