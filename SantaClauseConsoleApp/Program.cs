using SantaClauseConsoleApp.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1();
            //Question2();
            //Question3();
            //Question4();
            //Question5();
            //Question6();
        }

        static void Question1()
        {
            //Childs. //Consideram ca numele este unic pentru fiecare copil
            Child child1 = new Child()
            {
                Full_Name = "Nia Corinne",
                Age = 10,
                Address = "213 Green Ave. Fort Wayne, IN 46804",
                Behavior = BehaviorEnum.Good
            };
            Child child2 = new Child()
            {
                Full_Name = "Marina Lara",
                Age = 11,
                Address = "14 Winding Way Drive. Vista, CA 92083",
                Behavior = BehaviorEnum.Bad
            };
            Child child3 = new Child()
            {
                Full_Name = "Daxton Padraigin",
                Age = 12,
                Address = "6 Victoria Court. Algonquin, IL 60102",
                Behavior = BehaviorEnum.Good
            };
            //Items. //Consideram ca numele este unic pentru fiecare obiect diferit
            Item item1 = new Item() 
            {
                Name="Jucarie din plus Sonic Hedgehog"
            };
            Item item2 = new Item()
            {
                Name="Jucarie din plus Disney Minnie Mouse"
            };
            Item item3 = new Item()
            {
                Name = "Lego"
            };
            Item item4 = new Item()
            {
                Name = "Puzzle 100 de piese"
            };
            //Letters // Consideram ca Child este unic pentru fiecare scrisoare 
            Letter letter1 = new Letter()
            {
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
                Child = child3,
                Gifts = new List<Item>()
                {
                    item3,
                    item4
                },
                Date = DateTime.Now
            };

            //WriteInConsole
            Console.WriteLine("Question1: ");
            print(new List<Letter>() { letter1, letter2, letter3 });
            Console.WriteLine();
        }

        static void print(List<Letter> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine($"The child called {i.Child.Full_Name}, have {i.Child.Age} years old," +
                    $" lives in {i.Child.Address} and has behaven {i.Child.Behavior}. Has write letter the day {i.Date}," +
                    $" whith the following gifs: {i.Gifts[0].Name} and {i.Gifts[1].Name}");
            }
        }

        static void Question2()
        {
            LetterRepo repo = new LetterRepo();
            try
            {
                repo.read();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Question2: ");
            print(repo.letters);
            Console.WriteLine();
        }

        static void Question3()
        { //aceasta functie va genera 3 fisere in directoriul letters
            LetterRepo repo = new LetterRepo();
            try
            {
                repo.GenerateQ1DataInRepo();
                repo.write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Question3: ");
            print(repo.letters);
            Console.WriteLine();
        }

        static void Question4()
        {
            LetterRepo repo = new LetterRepo();
            try
            {       // adaugam date in repo
                repo.read();
                repo.GenerateQ1DataInRepo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            var query1 = repo.letters.Select(x => x.Gifts[0].Name); //query cu primulele cadoul
            var query2 = repo.letters.Select(x => x.Gifts[1].Name). //query cu aldoilea 
                Concat(query1). //concatenam informatile
                GroupBy(x=>x). //combinam cadourile de acelas tip
                Select(y=>new {Name=y.Key,Cantitate=y.Count() }). //generam o structura cu numele unice si cu cantitea care o avem de fiecare
                OrderByDescending(x=>x.Cantitate). //sortam descendent
                ToList();

            Console.WriteLine("Question4: ");
            for (int i = 0; i < query2.Count; i++)
            {
                Console.WriteLine($"{query2[i].Name} - {query2[i].Cantitate}");
            }
            Console.WriteLine("");
        }

        static void Question5()
        {
            /*
             * Nu, unicul loc in care s-ar putea aplica este la conexiunea cu fisiere, dar cum, in acest caz, acestea nu sunt unice,
             *adica se folosesc mai multe fisere, o cantitate chiar dinamica de fisiere, acesta nu se poate aplica. In schimb, 
             *daca s-ar face conexiunea doar la un fiser, la citire sau/si la scriere,
             *s-ar putea aplica pentru a crea o instanta care sa returneze conexiunea la acel fiser.
             */
        }

        static void Question6()
            //consider ca adresa are urmatorul format formata: Strada'. 'oras', 'stat
        {
            LetterRepo repo = new LetterRepo();
            try
            {       // adaugam date in repo
                repo.read();
                repo.GenerateQ1DataInRepo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            var query1 = repo.letters.
            OrderBy(y => y.Child.Address.Split('.')[1].Split(',')[0].Remove(0,1)).// ordonam dupa orase, conform formatului
            Select(x=>x.Child.Address). //selectam doar adresele
            ToList();

        Console.WriteLine("Question6: ");
            for (int i = 0; i < query1.Count; i++)
            {
                Console.WriteLine(query1[i]);
            }
            Console.WriteLine("");
        }


    }
}
