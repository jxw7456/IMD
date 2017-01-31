using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//NAME: JaJuan Webster
//INSTRUCTOR: Chris Cascioli
//MonoGame Basics
//PERSONAL
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
        //Texture2D uncharted;
        //Texture2D theLastOfUs;
        //Texture2D watchDogs;
        Texture2D background;
        Texture2D mario;
        Texture2D luigi;
        Texture2D bowser;
        //Vector2 unchPosition;
        //Vector2 tlouPosition;
        //Vector2 wdPosition;
        Vector2 marioPosition;
        Vector2 luigiPosition;
        Vector2 bowserPosition;
        Song yoshi;

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
            //uncharted = Content.Load<Texture2D>("uncharted");
            //theLastOfUs = Content.Load<Texture2D>("tlou");
            //watchDogs = Content.Load<Texture2D>("watchdogs");
            background = Content.Load<Texture2D>("background");
            mario = Content.Load<Texture2D>("mario");
            luigi = Content.Load<Texture2D>("luigi");
            bowser = Content.Load<Texture2D>("bowser");
            yoshi = Content.Load<Song>("music");
            MediaPlayer.Volume = 0.2f;
            MediaPlayer.Play(yoshi);
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
            //unchPosition.X += 3.2f;

            //tlouPosition.X += 3.7f;

            //wdPosition.X += 4.2f;            

            marioPosition.X += 3.5f;

            luigiPosition.X += 3.5f;

            bowserPosition.X += 3.5f;

            //ScreenWrap
            //move images to the start of the viewport once they reach the end
            /*
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
            */

            //EXTRA PLAY AROUND
            if (marioPosition.X > GraphicsDevice.Viewport.Width)
            {
                marioPosition.X = -350;            
            }

            if (luigiPosition.X > GraphicsDevice.Viewport.Width)
            {
                luigiPosition.X = -350;
            }

            if (bowserPosition.X > GraphicsDevice.Viewport.Width)
            {
                bowserPosition.X = -350; 
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

            //spriteBatch.Draw(uncharted, new Vector2(unchPosition.X, 0), Color.White);

            //spriteBatch.Draw(theLastOfUs, new Vector2(tlouPosition.X, 0), Color.White);

            //spriteBatch.Draw(watchDogs, new Vector2(wdPosition.X, 0), Color.White);

            spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            spriteBatch.Draw(mario, new Rectangle((260 + (int)marioPosition.X), (GraphicsDevice.Viewport.Height - 125), 80, 80), Color.White);

            spriteBatch.Draw(luigi, new Rectangle((160 + (int)luigiPosition.X), (GraphicsDevice.Viewport.Height - 125), 80, 80), Color.White);

            spriteBatch.Draw(bowser, new Rectangle((10 + (int)bowserPosition.X), (GraphicsDevice.Viewport.Height - 140), 130, 100), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
