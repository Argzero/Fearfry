using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Fearfry
{
    //---------------------------------------------------
    public class FoodItem : Item
    {
        public Vector2 Location;
        public Vector2 Dimensions; // (X = width, Y = height)
        public Texture2D Image;

        public List<RectanglePair> Divisions;

        public FoodItem(Vector2 loc, Texture2D image) {
            Location = loc;
            Divisions = new List<RectanglePair>();
        }
    }
    //---------------------------------------------------
}
