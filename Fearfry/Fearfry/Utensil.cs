using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Fearfry {
    public class Utensil : InSceneObject, Item
    {
        public string Name;
        public Vector2 Location;
        public Vector2 Dimensions; // (X = width, Y = height)
        public Texture2D Image;

        public Utensil(Vector2 loc, Texture2D image, string name) {
            Location = loc;
            Image = image;
            Name = name;
        }

        public override void Update()
        {
        }

        public override void Draw(SpriteBatch batch)
        {
            //batch.Draw(TextureArray[0], Rect, Color.White);
        }
    }
}