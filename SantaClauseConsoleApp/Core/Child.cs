using SantaClauseConsoleApp.Core;

namespace SantaClauseConsoleApp
{
    public class Child : Entity
    {
        public string Full_Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public BehaviorEnum Behavior { get; set; }

    }
}
