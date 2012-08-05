using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FanmadeV2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Base Game Properties

        //basic setup
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;

        //core variables
        GameState currState;
 
        //Screenshot variables
        bool isScreenshot;  //are we drawing a screenshot right now?
        RenderTarget2D screenShot;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
                           {IsFullScreen = true, PreferredBackBufferHeight = 720, PreferredBackBufferWidth = 1366};
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
            currState = GameState.MainMenu;  //start at the main menu
            isScreenshot = false;   //we're not initially taking screenshots
            
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
            map = Content.Load<Map>("Maps//001");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            KeyboardState keyState = Keyboard.GetState();
            // Allows the game to exit
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                (keyState.IsKeyDown(Keys.Escape)))
                this.Exit();

            //Take a screenshot!
            if (keyState.IsKeyDown(Keys.F12))
                isScreenshot = true;

            // TODO: Add your update logic here



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            // TODO: Add your drawing code here
            #region Set up screenshots
            if (isScreenshot)
            {
                Color[] screenData = new Color[GraphicsDevice.PresentationParameters.BackBufferWidth *
                                           GraphicsDevice.PresentationParameters.BackBufferHeight];

                screenShot = new RenderTarget2D(GraphicsDevice,
                    GraphicsDevice.PresentationParameters.BackBufferWidth,
                    GraphicsDevice.PresentationParameters.BackBufferHeight);

                GraphicsDevice.SetRenderTarget(screenShot);

                map.Draw(spriteBatch);
                base.Draw(gameTime);
            
                GraphicsDevice.SetRenderTarget(null);

                //save to disk 
                string fileName = DateTime.Now.ToString();
                fileName = fileName.Replace('/', '-');
                fileName = fileName.Replace(':', '-');

                Stream stream = File.OpenWrite("\\Screens\\" + fileName + ".jpg");
                screenShot.SaveAsJpeg(stream,
                                        1280,
                                        720);
                stream.Dispose();
                screenShot.Dispose();

                //reset the screenshot flag
                isScreenshot = false;
            }
            #endregion

            map.Draw(spriteBatch);
            base.Draw(gameTime);
 
        }
    }
}
