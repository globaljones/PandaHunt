using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set;  }

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void Use()
        {
            Console.WriteLine($"You cannot use the {Name}.");
        }
    }

}
