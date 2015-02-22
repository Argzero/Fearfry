using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Fearfry {
    //---------------------------------------------------
    public class FoodItem : InSceneObject, Item {
        public string name;
        public Vector2 Location;
        public Vector2 Dimensions; // (X = width, Y = height)
        public Texture2D Image;

        public List<RectanglePair> Divisions;

        public FoodItem(Vector2 loc, Texture2D image, string name) {
            Location = loc;
            Divisions = new List<RectanglePair>();
            Image = image;
        }

        public override void Update()
        {
            // DOES NOTHING
        }

        public override void Draw(SpriteBatch batch)
        {
            //batch.Draw(TextureArray[0], Rect, Color.White);
        }
    }
    //---------------------------------------------------
}
