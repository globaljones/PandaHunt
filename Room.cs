using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{

    class Room
    {
        public string Description { get; }
        public Dictionary<string, Room> Exits { get; } = new Dictionary<string, Room>();
        public List<Item> Items { get; } = new List<Item>();
        public Chest LockedChest { get; set; }
        public Key Key { get; set; }
        public Chest Chest { get; internal set; }

        public Room(string description)
        {
            Description = description;
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public Item GetItem(string name)
        {
            return Items.Find(item => item.Name == name);
        }
    }
}
