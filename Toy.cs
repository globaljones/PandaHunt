using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Toy : Item
    {
        private string v = "";

        //public Toy(string name)
        //{
        //    this.Name = name;
        //}

        public Toy(string name, string description) : base(name, description) { }

        public override void Use()
        {
            Console.WriteLine($"You play with the {Name} for a little while.");
        }
    }

}
