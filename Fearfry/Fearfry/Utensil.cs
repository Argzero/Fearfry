using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Fearfry {
    public class Utensil : InSceneObject
    {
        public string Name;
        public Vector2 Location;
        public Vector2 Dimensions; // (X = width, Y = height)
        public Texture2D Image;

        public Utensil(Vector2 loc, Vector2 dimensions, Texture2D image, string name) {
            Location = new Vector2(loc.X+75,loc.Y);
            Image = image;
            Name = name;
            Dimensions = dimensions;
        }

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Image, new Rectangle((int)Location.X, (int)Location.Y, (int)Dimensions.X, (int)Dimensions.Y), Color.White);
        }
    }
}