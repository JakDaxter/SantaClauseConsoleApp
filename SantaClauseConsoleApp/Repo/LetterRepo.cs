using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string[] dir = Directory.GetFiles(System.AppContext.BaseDirectory.Remove(System.AppContext.BaseDirectory.Length - 17) + "Letters");//Letters directory
            foreach(var file2 in dir)
            {
                using (StreamReader file = new StreamReader(file2)) //citim din fiser
                {

                    List<string> data = new List<string>();

                    string ln;
                    while ((ln = file.ReadLine()) != null) //pe lini
                    {
                        string complexWord = "";
                        bool flag = false;
                        foreach (var i in ln.Split(' ',',','.')) // cautam fiecare cuvant
                        {
                            if (i != "") 
                            {

                                if (i[0] == '[' && i[i.Length - 1] == ']' && flag == false) // daca informatia care trebuie salvata este formata dintr-un singur cuvant
                                {
                                    string save=i.Remove(0, 1);
                                    save=save.Remove(save.Length - 1);
                                    data.Add(save);
                                }
                                if (i[0] == '[' && i[i.Length - 1] != ']' && flag == false) //daca este formata din 2 sau mai multe, incepem sa cream stringul
                                {
                                    flag = true;
                                    complexWord = complexWord + $"{i.Remove(0, 1)}";
                                }
                                if (i[0] != '[' && i[i.Length - 1] == ']' && flag == true) //finalul stringului si salvarea informatiei
                                {
                                    flag = false;
                                    complexWord = complexWord + $" {i.Remove(i.Length - 1)}";
                                    data.Add(complexWord);
                                    complexWord = "";
                                }
                                if (i[0] != '[' && i[i.Length - 1] != ']' && flag == true) //daca inca nu sa ajuns la finalul stringului, se continua 
                                {
                                    complexWord = complexWord + $" {i}";
                                }
                            }
                        }
                    }
                    foreach(var i in data)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine();
                    file.Close();
                }
            }
        }
    }
}
