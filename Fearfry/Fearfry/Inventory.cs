using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fearfry
{
    public class Inventory : InSceneObject
    {
        // Items in the Inventory
        public List<Item> Items;
        public Rectangle Rect { get; set; }
        public Texture2D background;

        /// <summary>
        /// Instantiates the Inventory; 
        /// </summary>
        /// <param name="items">list of past items built in case loading save file;</param>
        public Inventory(Texture2D bg, Rectangle rect, List<Item> items = null)
        {
            background = bg;
            Items = items ?? new List<Item>();
            Rect = rect;
        }

        // Access index of each Item
        public Item this[int index] {    // Indexer declaration
            get { return Items[index]; }
            set { Items[index] = value; }
        }

        public override void Update()
        {
            // DOES NOTHING
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(background, Rect, Color.White);
            int y = Rect.Height / 10;
            int height = 8 * Rect.Height / 10;
            int width = 8 * Rect.Height / 10;
            int x = Rect.Height / 10;

            foreach (Item item in Items)
            {
                item.Draw(batch);
                x += Rect.Height / 10;
            }
        }
    }
}
