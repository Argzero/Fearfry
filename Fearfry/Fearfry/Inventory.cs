using System;
using System.Collections.Generic;
using System.Text;

namespace Fearfry
{
    public class Inventory
    {
        // Items in the Inventory
        public List<Item> Items; 

        /// <summary>
        /// Instantiates the Inventory; 
        /// </summary>
        /// <param name="items">list of past items built in case loading save file;</param>
        public Inventory(List<Item> items = null)
        {
            items = items ?? new List<Item>();
        }

        // Access index of each Item
        public Item this[int index] {    // Indexer declaration
            get { return Items[index]; }
            set { Items[index] = value; }
        }
    }
}
