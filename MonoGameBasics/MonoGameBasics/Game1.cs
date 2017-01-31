using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//NAME: JaJuan Webster
//INSTRUCTOR: Chris Cascioli
//MonoGame Basics

namespace MonoGameBasics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //Attributes
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D uncharted;
        Texture2D theLastOfUs;
        Texture2D watchDogs;
        Vector2 unchPosition;
        Vector2 tlouPosition;
        Vector2 wdPosition;

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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            uncharted = Content.Load<Texture2D>("uncharted");
            theLastOfUs = Content.Load<Texture2D>("tlou");
            watchDogs = Content.Load<Texture2D>("watchdogs");

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
            //Moving Image Positions
            //images in front MOVE FASTER than those in the background
            unchPosition.X += 3.2f;

            tlouPosition.X += 3.7f;

            wdPosition.X += 4.2f;

            //ScreenWrap
            //move images to the start of the viewport once they reach the end
            if (unchPosition.X > GraphicsDevice.Viewport.Width)
            {
                unchPosition.X = -620;    //Width of the Uncharted Image            
            }

            if (tlouPosition.X > GraphicsDevice.Viewport.Width)
            {
                tlouPosition.X = -450;  //Width of the Last of Us Image 
            }

            if (wdPosition.X > GraphicsDevice.Viewport.Width)
            {
                wdPosition.X = -750;    //Width of the Watch Dogs Image 
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

            // TODO: Add your drawing code here
            //Drawing Images
            spriteBatch.Begin();

            spriteBatch.Draw(uncharted, new Vector2(unchPosition.X, 0), Color.White);

            spriteBatch.Draw(theLastOfUs, new Vector2(tlouPosition.X, 0), Color.White);

            spriteBatch.Draw(watchDogs, new Vector2(wdPosition.X, 0), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
