
using System;
using System.Collections.Generic;
namespace AdventureGame
{
    class Program
    {
        static void Main()
        {
            // Initialize rooms and objects
            Room startRoom = new Room("You are standing in a room in what appears to be an enchanted castle.");
            Room westRoom = new Room("You are in a room to the west. There is a locked chest here.");
            Room eastRoom = new Room("You are in a room to the east. There is a key here.");
            Room northRoom = new Room("You are in a room to the north.");
            Room southRoom = new Room("You are in a room to the south.");
            westRoom.LockedChest = new Chest("locked chest", "a locked chest");
            eastRoom.Key = new Key("key", "A silver key");
            westRoom.Chest = new Chest("chest", "an old chest", true, new Toy("panda", "A cuddly panda"));

            // Set up exits
            startRoom.Exits.Add("north", northRoom);
            startRoom.Exits.Add("south", southRoom);
            startRoom.Exits.Add("east", eastRoom);
            startRoom.Exits.Add("west", westRoom);
            westRoom.Exits.Add("north", null);
            westRoom.Exits.Add("south", null);
            westRoom.Exits.Add("east", startRoom);
            westRoom.Exits.Add("west", null);
            eastRoom.Exits.Add("north", null);
            eastRoom.Exits.Add("south", null);
            eastRoom.Exits.Add("east", null);
            eastRoom.Exits.Add("west", startRoom);
            northRoom.Exits.Add("south", startRoom);
            southRoom.Exits.Add("north", startRoom);

            // Set up player inventory
            List<Item> inventory = new List<Item>();

            // Game loop
            Room currentRoom = startRoom;
            while (true)
            {
                // Print room description
                Console.WriteLine(currentRoom.Description);

                // Print available exits
                Console.Write("Exits:");
                foreach (KeyValuePair<string, Room> exit in currentRoom.Exits)
                {
                    if (exit.Value != null)
                    {
                        Console.Write(" " + exit.Key);
                    }
                }
                Console.WriteLine();

                // Print inventory
                if (inventory.Count > 0)
                {
                    Console.Write("You are carrying:");
                    foreach (Item item in inventory)
                    {
                        Console.Write(" " + item.Name);
                    }
                    Console.WriteLine();
                }

                // Parse input
                string[] input = Console.ReadLine().ToLower().Split(' ');

                if (input[0] == "go")
                {
                    if (input.Length < 2)
                    {
                        Console.WriteLine("Go where?");
                    }
                    else if (!currentRoom.Exits.ContainsKey(input[1]))
                    {
                        Console.WriteLine("You can't go that way.");
                    }
                    else if (currentRoom.Exits[input[1]] == null)
                    {
                        Console.WriteLine("There is no exit in that direction.");
                    }
                    else
                    {
                        currentRoom = currentRoom.Exits[input[1]];
                    }
                }
                else if (input[0] == "get" || input[0] == "take")
                {
                    if (input.Length < 2)
                    {
                        Console.WriteLine("Get what?");
                    }
                    else
                    {
                        Item item = currentRoom.GetItem(input[1]);
                        if (item == null)
                        {
                            Console.WriteLine("You don't see that here.");
                        }
                        else
                        {
                            inventory.Add(item);
                            Console.WriteLine("You pick up the " + item.Name + ".");
                        }
                    }
                }
                else if (input[0] == "drop")
                {
                    if (input.Length < 2)
                    {
                        Console.WriteLine("Drop what?");
                    }
                    else
                    {
                        Item item = inventory.Find(i => i.Name == input[1]);
                        if (item == null)
                        {
                            Console.WriteLine("You are not carrying that.");
                        }
                        else
                        {
                            inventory.Remove(item);
                            currentRoom.AddItem(item);
                            Console.WriteLine("You drop the " + item.Name + ".");
                        }
                    }
                }
            }


        }
    }
}

