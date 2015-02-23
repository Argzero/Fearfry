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

namespace Fearfry {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        public enum GameState { Menu, Playing, Paused }
        public enum PlayState { Walking, Interacting, Cooking }
        GameState gameState = GameState.Menu;
        PlayState playState = PlayState.Walking;
        int Height;
        int Width;

        Vector2 TargetLocation;

        
        // XNA Vars
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<string,Texture2D> images;
        SpriteFont MurderFont;
        SpriteFont BigMurderFont;

        KeyboardState[] keyboard = new KeyboardState[2];
        MouseState[] mouse = new MouseState[2];
        Vector2[] mousePos = new Vector2[2];

        // NON-XNA Vars
        public List<InSceneObject> ObjectsInScene;
        private Player player;
        private Rectangle[] MenuRects;
        private Texture2D[] MenuImages;
        private bool[] MenuHovered;
        private Inventory inventory;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            images = new Dictionary<string, Texture2D>();
            mouse[0] = Mouse.GetState();
            keyboard[0] = Keyboard.GetState();
            mousePos[0] = new Vector2(mouse[0].X,mouse[0].Y);
            MenuHovered = new bool[2];
            ObjectsInScene = new List<InSceneObject>();
        }

        // Updates all data dependent upon XNA interaction and code
        // EX: MouseState, KeyboardState, etc...
        public void UpdateXNAData() {
            // Update Mouse Data
            mouse[1] = mouse[0];
            mouse[0] = Mouse.GetState();

            // Update KeyStates
            keyboard[1] = keyboard[0];
            keyboard[0] = Keyboard.GetState();

            // Update Mouse Position
            mousePos[1] = mousePos[0];
            mousePos[0] = new Vector2(mouse[0].X, mouse[0].Y);

            if(gameState == GameState.Menu) {
                if (MenuRects[0].Intersects(new Rectangle((int)mousePos[0].X, (int)mousePos[0].Y, 1, 1))) {
                    MenuHovered[0] = true;
                }
                else {
                    MenuHovered[0] = false;
                }
               
                if (MenuRects[1].Intersects(new Rectangle((int)mousePos[0].X, (int)mousePos[0].Y, 1, 1))) {
                    MenuHovered[1] = true;
                }
                else
                {
                    MenuHovered[1] = false;
                }
            }

            // MIN/MAX Values for Mouse location
            if (mousePos[0].X < 0) mousePos[0].X = 0;
            if (mousePos[0].Y < 0) mousePos[0].Y = 0;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Note Dimensions
            Height = graphics.GraphicsDevice.Viewport.Height;
            Width = graphics.GraphicsDevice.Viewport.Width;
            MenuRects = new Rectangle[2];
            MenuImages = new Texture2D[2];
            MenuRects[0] = new Rectangle(0, Height / 3, Width, Height / 3);
            MenuRects[1] = new Rectangle(0, 2 * Height / 3, Width, Height / 3);

            // Content Loading
            // Fonts
            MurderFont = Content.Load<SpriteFont>("Default");
            BigMurderFont = Content.Load<SpriteFont>("BigDefault");

            // Player
            Texture2D[] PlayerImages = new Texture2D[3];
            PlayerImages[0] = Content.Load<Texture2D>("LEFT");
            PlayerImages[1] = Content.Load<Texture2D>("RIGHT");
            PlayerImages[2] = Content.Load<Texture2D>("MID");
            player = new Player(new Rectangle(100, 200, 108, 272), PlayerImages);
            ObjectsInScene.Add(player);

            // Menu
            MenuImages[0] = Content.Load<Texture2D>("PLAY");
            MenuImages[1] = Content.Load<Texture2D>("QUIT");

            // Inventory
            images["inventory"] = Content.Load<Texture2D>("Inventory");
            inventory = new Inventory(images["inventory"], new Rectangle(0,0,Width, Height/6));
            ObjectsInScene.Add(inventory);
            ObjectsInScene.Add(new Fridge(new Vector2(0, 282), new Vector2(108, 190), Content.Load<Texture2D>("Fridge"), "FRIDGE"));
            ObjectsInScene.Add(new Sink(new Vector2(324, 320), new Vector2(108, 90), Content.Load<Texture2D>("Sink"), "SINK"));
            ObjectsInScene.Add(new Cabinet(new Vector2(432, 200), new Vector2(108, 90), Content.Load<Texture2D>("Cabinet"), "CABINET"));
            ObjectsInScene.Add(new Stove(new Vector2(216, 320), new Vector2(108, 90), Content.Load<Texture2D>("Stove"), "STOVE"));
            ObjectsInScene.Add(new Counter(new Vector2(108, 320), new Vector2(108, 90), Content.Load<Texture2D>("Counter"), "COUNTER"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // XNA Input Data Update
            UpdateXNAData();
///------------- :GAME LOOP LOGIC AFTER THIS LINE: --------------
///         // MAIN Loop
            switch(gameState) {
                case GameState.Menu:
                    MenuUpdate(gameTime);
                    break;
                case GameState.Paused:
                    break;
                case GameState.Playing:
                    PlayUpdate(gameTime); // Enter Game Loop
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Menu Loop Update --- While in Main Menu
        /// </summary>
        /// <param name="gameTime"></param>
        public void MenuUpdate(GameTime gameTime) {
            if (mouse[0].LeftButton == ButtonState.Pressed && mouse[1].LeftButton != ButtonState.Pressed) {
                gameState = GameState.Playing;
            }
        }

        /// <summary>
        /// Menu Loop Draw --- While in Main Menu
        /// </summary>
        /// <param name="gameTime"></param>
        public void MenuDraw(GameTime gameTime) {
            spriteBatch.Begin();
            spriteBatch.Draw(MenuImages[0], MenuRects[0], (MenuHovered[0]) ? new Color(100,0,255,200) : Color.White);
            spriteBatch.Draw(MenuImages[1], MenuRects[1], (MenuHovered[1]) ? new Color(100,0, 255, 200) : Color.White);
            spriteBatch.End();

            Console.WriteLine(MenuHovered);

            DrawString("Fearfry", new Vector2(Width / 2, Height / 6), new Color(115,6,15), 1);
        }

        /// <summary>
        /// Game Loop Update --- While Playing
        /// - Can go back to Paused mode and return regardless of PlayState
        /// </summary>
        /// <param name="gameTime"></param>
        public void PlayUpdate(GameTime gameTime) {
            if(playState == PlayState.Walking) {
                if(keyboard[0].IsKeyDown(Keys.Left)){
                    player.SetDirection("left");
                    player.Update(new Vector2(-1,0));
                }
                else if (keyboard[0].IsKeyDown(Keys.Up))
                {
                    player.SetDirection("mid");
                    player.Update();
                }
                else if (keyboard[0].IsKeyDown(Keys.Right))
                {
                    player.SetDirection("right");
                    player.Update(new Vector2(1, 0));
                }
            }
        }

        /// <summary>
        /// Game Loop Draw --- While Playing
        /// </summary>
        /// <param name="gameTime">gameTime</param>
        public void PlayDraw(GameTime gameTime) {
            spriteBatch.Begin();
            InSceneObject iso;
            for(int i = 1; i< ObjectsInScene.Count; i++) {
                iso = ObjectsInScene[i];
                iso.Draw(spriteBatch);
            }

            ObjectsInScene[0].Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(new Color(0,1,10));
            switch(gameState) {
                case GameState.Menu:
                    MenuDraw(gameTime);
                    break;
                case GameState.Playing:
                    PlayDraw(gameTime);
                    break;
                case GameState.Paused:
                    break;
            }

            DrawString("Mouse", mousePos[0], Color.Yellow, 0);
            base.Draw(gameTime);
        }

        public void DrawString(String text, Vector2 location, Color color = default(Color), int size=0) {
            // TODO: Add your drawing code here
            SpriteFont font = (size == 1) ? BigMurderFont : MurderFont;
            Vector2 Size = font.MeasureString(text);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            spriteBatch.DrawString(
                font,
                text,
                new Vector2(location.X + 2, location.Y + 2),
                new Color(5,5,5), 0.0f,
                new Vector2(Size.X / 2, Size.Y / 2),
                1.0f, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(
                font,
                text,
                location,
                color, 0.0f,
                new Vector2(Size.X / 2, Size.Y / 2),
                1.0f, SpriteEffects.None, 0.0f);
            spriteBatch.End();
        }
    }
}
