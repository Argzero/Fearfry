using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fearfry
{
    public class Player:InSceneObject
    {
        public enum Direction { L, R, Mid } // Left, right and away from Camera
        public Direction PlayerDirection = Direction.R;
        public Rectangle Rect { get; set; }
        public Texture2D[] TextureArray { get; set; }
        public Dictionary<String, Texture2D[]> Textures;
        // public int index = 0; CURRENT STATE

        public Player(Rectangle rect, Texture2D[] textures) {
            Rect = rect;
            PlayerDirection = Direction.R;
            Textures = new Dictionary<string, Texture2D[]>();
            // Set up left-facing textures
            Textures["Left"] = new Texture2D[1];
            Textures["Left"][0] = textures[0];

            // Set up right-facing textures
            Textures["Right"] = new Texture2D[1];
            Textures["Right"][0] = textures[0];

            Textures["Middle"] = new Texture2D[1];
            Textures["Middle"][0] = textures[2];

            TextureArray = Textures["Right"];
        }

        public override void Update() { /*Nothing*/ }

        public void Update(Vector2 movement = default(Vector2)) {
            if (PlayerDirection == Direction.L)
                TextureArray = Textures["Left"];
            else if (PlayerDirection == Direction.R)
                TextureArray = Textures["Right"];
            else
                TextureArray = Textures["Middle"];
            Rect = new Rectangle(Rect.X + (int)movement.X, Rect.Y + (int)movement.Y, Rect.Width, Rect.Height);
        }

        public void SetDirection(String DirectionString) {
            PlayerDirection = (DirectionString == "left") ? Direction.L : (DirectionString == "right") ? Direction.R : Direction.Mid;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(TextureArray[0], Rect, null, Color.White, 0, Vector2.Zero, (PlayerDirection == Direction.R)? SpriteEffects.FlipHorizontally:SpriteEffects.None, 0);
        }
    }
}
