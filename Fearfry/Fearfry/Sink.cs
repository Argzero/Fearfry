using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fearfry
{
    public class Sink : Utensil
    {
        public Sink(Vector2 loc, Vector2 dimensions, Texture2D image, string name)
            :base(loc, dimensions, image, name){
            
        }
    }
    public class Fridge : Utensil
    {
        public Fridge(Vector2 loc, Vector2 dimensions, Texture2D image, string name)
            : base(loc, dimensions, image, name)
        {

        }
    }
    public class Counter : Utensil
    {
        public Counter(Vector2 loc, Vector2 dimensions, Texture2D image, string name)
            : base(loc, dimensions, image, name)
        {

        }
    }
    public class Stove : Utensil
    {
        public Stove(Vector2 loc, Vector2 dimensions, Texture2D image, string name)
            : base(loc, dimensions, image, name)
        {

        }
    }
    public class Cabinet : Utensil
    {
        public Cabinet(Vector2 loc, Vector2 dimensions, Texture2D image, string name)
            : base(loc, dimensions, image, name)
        {

        }
    }
}
