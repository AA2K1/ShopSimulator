using System;
using System.Collections.Generic;
using System.Drawing;
using ConsoleTables;
using Console = Colorful.Console;

namespace ShopSimulator
{
    class Program
    {

        class Shop
        {
            public List<Tuple<string, string, int>> items;
            public List<Tuple<string, string, int>> inventory;

            public Shop()
            {
                items = new List<Tuple<string, string, int>>();
                inventory = new List<Tuple<string, string, int>>();
            }
        }

        static void Main(string[] args)
        {

            var coins = 1000;
            var random = new Random();
            var shop = new Shop();
            string[] phrases = {
                "des schryari crizzling overfaintly",
                "des melezitose preexpand unsurrealistically",
                "aslant selenodonty preseparated nonparentally",
                "abaft clinidae repenalize supermedially",
                "fer europe outwander overloftily",
                "atop trinidad outjetted overmellowly",
                "sans lofoten unpaste orinasally",
                "abaft nonnegotiability overgrieving overforwardly",
                "fer arriccio decarbonylate gibbosely",
                "mid unrelatedness preoppose subsynodically",
                "sans pteroclididae effigiating unabstemiously",
                "ex qiana outstatured nonsimilarly",
                "ere benghazi preexcept presentively",
                "atop barbados intersqueezed oversuperstitiously",
                "thru nematocera mispurchased unappallingly"
                };

            shop.items.Add(Tuple.Create<string, string, int>("Tiny Meme Coin", "A coin for the starters.", 5));
            void startScreen()
            {
                Console.Title = "Shop Simulator";
                Console.WriteAscii("Shop Simulator", Color.LightBlue);
                Console.BackgroundColor = Color.Black;
                Console.WriteLine("Welcome to the shop. Here you have 3 options:\n1: Get coins.\n2: Visit shop.\n3. Show inventory\n4. Exit game.\nWhat will it be? ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        randomPhrase();
                        break;
                    case "2":
                        showShop();
                        break;
                    case "3":
                        showInventory();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;

                }
            }

            void randomPhrase()
            {
                Console.Clear();
                var ran = random.Next(0, phrases.Length);
                Console.WriteLine("Your very obscure phrase is: \n" + phrases[ran]);
                var input = Console.ReadLine();
                if (input == phrases[ran])
                {
                    coins += 5;
                    if(coins == 20)
                    {
                        shop.items.Add(Tuple.Create<string, string, int>("Small Meme Coin", "A coin for the early-goers.", 10));
                    } else if(coins == 50)
                    {
                        Tuple.Create<string, string, int>("Slightly-larger-than-Medium Meme Coin", "A coin for those who stayed a little longer.", 25);
                    } else if(coins == 100)
                    {
                        Tuple.Create<string, string, int>("Medium Meme Coin", "A coin for those who perservered through 100 coins.", 75);
                    } else if(coins == 500)
                    {
                        Tuple.Create<string, string, int>("Large Meme Coin", "A coin for the people who type really well.", 250);
                    } else if(coins == 1000)
                    {
                        Tuple.Create<string, string, int>("Extra Large Meme Coin", "A coin for the absolute chads.", 500);
                    }       
                    Console.WriteLine("Congrats! You got 5 coins. Press enter to continue...", Color.LightGreen);
                    Console.ReadLine();
                    Console.Clear();
                    startScreen();
                }

            }

            void showShop()
            {
                //Display shop
                Console.Clear();
                var shopTable = new ConsoleTable("Item", "Description", "Price");
                foreach (var tuple in shop.items)
                {
                    Console.WriteLine();
                    shopTable.AddRow(tuple.Item1, tuple.Item2, tuple.Item3.ToString());
                    shopTable.Write(Format.Alternative);
                    Console.WriteLine();
                    // Console.WriteLine("| {0} | {1} | {2} |", tuple.Item1, tuple.Item2, tuple.Item3.ToString());

                }
                Console.WriteLine("So, what do you want to buy? If you don't want to buy anything, just type cancel.");
                Console.WriteLine("Your balance is: " + coins);
                string itemToBuy = Console.ReadLine();
                if (itemToBuy.ToLower() == "cancel")
                {
                    //if player types cancel go back to start screen
                    Console.Clear();
                    startScreen();
                }
                else
                {
                    foreach (var tuple in shop.items)
                    {
                        //for each item in the items, if they have enough coins then buy it.
                        if (itemToBuy.ToLower() == tuple.Item1.ToLower())
                        {
                            if (coins >= Convert.ToInt32(tuple.Item3))
                            {
                                Console.WriteLine("Successfully bought: " + tuple.Item1 + ". Press enter to go to main menu.");
                                shop.inventory.Add(Tuple.Create<string, string, int>(tuple.Item1, tuple.Item2, tuple.Item3));
                                Console.ReadLine();
                                Console.Clear();
                                startScreen();
                            }
                            else
                            {
                                Console.WriteLine("Sorry, you don't have enough money to buy that. Would you like to try again?", Color.LightPink);
                                string ans = Console.ReadLine();
                                while (ans.ToLower() != "yes" || ans.ToLower() != "no")
                                {
                                    if (ans.ToLower() == "yes")
                                    {
                                        Console.Clear();
                                        showShop();
                                    }
                                    else if (ans.ToLower() == "no")
                                    {
                                        Console.Clear();
                                        startScreen();
                                    }
                                }
                                startScreen();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that item isn't available in the store. Please try again.", Color.LightPink);
                            Console.ReadLine();
                            Console.Clear();
                            startScreen();
                        }
                    }
                }
            }

            void showInventory()
            {
                Console.Clear();
                Console.WriteLine("Your inventory: ", Color.LightGreen);
                var inventoryTable = new ConsoleTable("Item", "Description", "Price");
                foreach (var tuple in shop.inventory)
                {
                    Console.WriteLine();
                    
                    inventoryTable.AddRow(tuple.Item1, tuple.Item2, tuple.Item3.ToString());
                    // Console.WriteLine("| {0} | {1} | {2} |", tuple.Item1, tuple.Item2, tuple.Item3.ToString());

                }
                inventoryTable.Write(Format.Alternative);
                Console.WriteLine();
                Console.ReadLine();
                Console.Clear();
                startScreen();
            }

            startScreen();
        }
    }
}

