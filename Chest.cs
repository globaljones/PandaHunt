using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Chest
    {
        private string v;
        //private List<Item> items;
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; } = true;
        public Item Contents { get; set; }

        public Chest(string name, string description)
        {
            Name = name;
            Description = description;
            Contents = null;
        }

        public Chest(string v, string description, bool isLocked, Item contents)
        {
            IsLocked = isLocked;
            Contents = contents;
            this.v = v;      
            Description = description;
        }


        //public Chest(string v)

        //{
        //    this.v = v;
        //    items = new List<Item>();

        //}

        //public Chest(string v, List<Item> items) 
        //{
        //    this.v = v;
        //    this.items = items;
        //}

        public void Use()
        {
            if (IsLocked)
            {
                Console.WriteLine($"The {Name} is locked.");
            }
            else if (Contents != null)
            {
                Console.WriteLine($"You find a {Contents.Name} inside the {Name}.");
            }
            else
            {
                Console.WriteLine($"The {Name} is empty.");
            }
        }

        public void Unlock(Key key)
        {
            if (IsLocked && key != null)
            {
                Console.WriteLine($"You unlock the {Name} with the {key.Name}.");
                IsLocked = false;
            }
            else if (IsLocked && key == null)
            {
                Console.WriteLine($"You need a key to unlock the {Name}.");
            }
            else
            {
                Console.WriteLine($"The {Name} is already unlocked.");
            }
        }
    }

}
