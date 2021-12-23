
using System;
using System.Collections.Generic;

namespace SantaClauseConsoleApp
{
    public class Letter
    {//se considera Child unic
        public Child Child {get;set;}
        public List<Item> Gifts { get; set; }
        public DateTime Date { get; set; }

    }
}
