using System;
using System.Collections.Generic;
using System.IO;

namespace SantaClauseConsoleApp.Repo
{
    class LetterRepo
    {
        public List<Letter> letters { get; }

        public LetterRepo()
        {
            letters = new List<Letter>();
        }
        public void Add(Letter letter)
        {
            this.letters.Add(letter);
        }

        public void read()
        {
            try //Consideram ca toate informatile au urmatorul format '['informatie']'
            {  //si nu sunt '['']' in afara informatilor 
                string[] dir = Directory.GetFiles(System.AppContext.BaseDirectory.Remove(System.AppContext.BaseDirectory.Length - 17) + "Letters");//Letters directory
                foreach (var file2 in dir)
                {
                    int count = 0;
                    using (StreamReader file = new StreamReader(file2)) //citim din fiser
                    {

                        List<string> data = new List<string>();
                        count += 1;
                        string ln;
                        while ((ln = file.ReadLine()) != null) //pe lini
                        {
                            string complexWord = "";
                            int flag = 0;
                            try
                            {
                                foreach (var i in ln) // cautam litera cu litera, fiecare informatie care trebuie salvata
                                {
                                    if (i == ']' && flag > 0) //daca este un posibil final al unei informatie
                                    {
                                        flag -=1;
                                        if (flag == 0) //daca chiar e dinaul
                                        {
                                            data.Add(complexWord); //salvam
                                            complexWord = ""; //continuam
                                        }
                                    }
                                    if (flag > 0) //daca nu e finalul unei informatie
                                    {
                                        complexWord = complexWord + i;
                                    }
                                    if (i == '[' && flag==0) //daca este inceputul
                                    {
                                        flag += 1;
                                    }
                                    
                                }
                            }
                            catch (Exception ex)
                            {
                                file.Close();
                                throw new Exception($"Eroare aparuta la citirea fiserului {count}");
                            }
                        }
                        try
                        {
                            Letter newLetter = new Letter()//Cream scrisoare
                            {
                                Date = System.IO.File.GetLastWriteTime(file2),
                                Child = new Child()
                                {
                                    Full_Name = data[0],
                                    Age = Convert.ToInt32(data[1]),
                                    Address = data[2],
                                    Behavior = (BehaviorEnum)Enum.Parse(typeof(BehaviorEnum), data[3], true)
                                },
                                Gifts = new List<Item>()
                                {
                                    new Item()
                                    {
                                        Name=data[4]
                                    },
                                    new Item()
                                    {
                                        Name=data[5]
                                    }
                                }
                            };
                            this.Add(newLetter); //adaugam scrisoarea
                        } catch (Exception ex)
                        {
                            throw new Exception($"Eroare apartura la generarea si adaugari unei scrisori in memorie dupa citire. la scrisoare {count}");
                        }
                        finally
                        {
                            file.Close();
                        }
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception("Eroare la path");
            }
        }

        public void GenerateQ1DataInRepo()
        {
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
            //Items
            Item item1 = new Item()
            {
                Name = "Jucarie din plus Sonic Hedgehog"
            };
            Item item2 = new Item()
            {
                Name = "Jucarie din plus Disney Minnie Mouse"
            };
            Item item3 = new Item()
            {
                Name = "Lego"
            };
            Item item4 = new Item()
            {
                Name = "Puzzle 100 de piese"
            };
            //Letters
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
            this.Add(letter1);
            this.Add(letter2);
            this.Add(letter3);
        }
        
        public void write()
        {
            try
            {
                int nr = Directory.GetFiles(System.AppContext.BaseDirectory.Remove(System.AppContext.BaseDirectory.Length - 17) + "Letters").Length + 1;
                string path = System.AppContext.BaseDirectory.Remove(System.AppContext.BaseDirectory.Length - 17) + "Letters";//Letters directory 
                for (int i = 0; i < letters.Count; i++)    
                {
                    using (StreamWriter writer = new StreamWriter(path + $"\\letter{i + nr}.txt"))
                    {
                        try
                        {
                            writer.WriteLine("Dear Santa,");
                            writer.WriteLine($"I am [{letters[i].Child.Full_Name}]");
                            writer.WriteLine($"I am [{letters[i].Child.Age}] years old. I live at [{letters[i].Child.Address}]. " +
                                $"I have been a very [{letters[i].Child.Behavior.ToString()}] child this year");
                            writer.WriteLine("What I would like the most this Christmas is:");
                            writer.WriteLine($"[{letters[i].Gifts[0].Name}],[{letters[i].Gifts[1].Name}]");
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Eroare la salvarea in fiser pentru scrisoarea lui {letters[i].Child.Full_Name}");
                        }
                        finally
                        {
                            writer.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare la path");
            }
        }



    }
}
