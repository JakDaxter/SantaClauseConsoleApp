using SantaClauseConsoleApp.Repo;
using System;
using System.Collections.Generic;
using System.IO;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
        }

        static void Question1()
        {
            //Childs
            Child child1 = new Child()
            {
                Id = 1,
                Full_Name = "Nia Corinne",
                Age = 10,
                Address = "213 Green Ave. Fort Wayne, IN 46804",
                Behavior = BehaviorEnum.Good
            };
            Child child2 = new Child()
            {
                Id = 2,
                Full_Name = "Marina Lara",
                Age = 11,
                Address = "14 Winding Way Drive. Vista, CA 92083",
                Behavior = BehaviorEnum.Bad
            };
            Child child3 = new Child()
            {
                Id = 3,
                Full_Name = "Daxton Padraigin",
                Age = 12,
                Address = "6 Victoria Court. Algonquin, IL 60102",
                Behavior = BehaviorEnum.Good
            };
            //Items
            Item item1 = new Item()
            {
                Id=1,
                Name="Jucarie din plus Sonic Hedgehog"
            };
            Item item2 = new Item()
            {
                Id=2,
                Name="Jucarie din plus Disney Minnie Mouse"
            };
            Item item3 = new Item()
            {
                Id = 3,
                Name = "Lego"
            };
            Item item4 = new Item()
            {
                Id = 4,
                Name = "Puzzle 100 de piese"
            };
            //Letters
            Letter letter1 = new Letter()
            {
                Id = 1,
                Child = child1,
                Gifts = new List<Item>() 
                {
                    item1,
                    item3
                },
                Date = DateTime.Now
            };
            Letter letter2 = new Letter()
            {
                Id = 2,
                Child = child2,
                Gifts = new List<Item>()
                {
                    item2,
                    item4
                },
                Date = DateTime.Now
            };
            Letter letter3 = new Letter()
            {
                Id = 3,
                Child = child3,
                Gifts = new List<Item>()
                {
                    item3,
                    item4
                },
                Date = DateTime.Now
            };

            //WriteInConsole
            print(new List<Letter>() { letter1, letter2, letter3 });
        }

        static void print(List<Letter> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine($"The child {i.Child.Id} is called {i.Child.Full_Name}, he have {i.Child.Age} years old," +
                    $" lives in {i.Child.Address} and has behaven {i.Child.Behavior}. Has write letter {i.Id} the day {i.Date.Date}," +
                    $" whith the following gifs: {i.Gifts[0].Name} and {i.Gifts[1].Name}");
            }
        }

        static void Question2()
        {
            LetterRepo repo = new LetterRepo();
            repo.read();
        }

        static void Question3()
        {
            
        }

        static void Question4()
        {
            
        }

        static void Question5()
        {
            
        }

        static void Question6()
        {
            
        }
    }
}
