using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Key : Item
    {
        private string v;

        //public Key(string v)
        //{
        //    this.v = v;
        //}

        public Key(string name, string description) : base(name, description) { }

        public override void Use()
        {
            Console.WriteLine($"The {Name} unlocks something.");
        }
    }

}
