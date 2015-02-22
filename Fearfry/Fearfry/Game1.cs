using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fearfry
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public enum GameState { Menu, Playing, Paused }
        public enum PlayState { Walking, Interacting, Cooking }
        GameState gameState = GameState.Menu;
        PlayState playState = PlayState.Walking;

        // XNA Vars
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<string,Texture2D> images;

        MouseState[] mouse = new MouseState[2];
        Vector2[] mousePos = new Vector2[2];

        // NON-XNA Vars

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            images = new Dictionary<string, Texture2D>();
            mouse[0] = Mouse.GetState();
            mousePos[0] = new Vector2(mouse[0].X,mouse[0].Y);
        }

        // Updates all data dependent upon XNA interaction and code
        // EX: MouseState, KeyboardState, etc...
        public void UpdateXNAData(){
            mouse[1] = mouse[0];
            mouse[0] = Mouse.GetState();
            mousePos[0] = new Vector2(mouse[0].X, mouse[0].Y);
            mousePos[1] = mousePos[0];
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

            // TODO: use this.Content to load your game content here
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            UpdateXNAData();

///------------- :GAME LOOP LOGIC AFTER THIS LINE: --------------
            switch(gameState){
                
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
