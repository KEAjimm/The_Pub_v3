using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pub
{
    public class Andy : Human
    {
        public Andy(string name)  {
            this.textColor = ConsoleColor.Cyan;
            this.Name = name;   // access protected member
            this.Actions = new string[] { "oogles the waitress", "looks at the drinks menu", "decides to go for a pee" };
        }

        public override void Greeting() {   // implement abstract method
            ColorLine(Name + ": Hi there! This here bar looks really interesting!");
        }

        public override void PerformAction(int actionNumber) {
            var chosenAction =  this.Actions[actionNumber];
            ColorLine(Name + " " + chosenAction);
        }

        public override void OrderDrink(string currentDrink)
        {
            // Order a specific drink
            ColorLine(Name + ": Hey, Bartender - I'd like a " + currentDrink);            
        }

        public override void ConsumeDrink()
        {
            // Consume a drink
            ColorLine(Name + " dips nose into glass and contents disappear mysteriously..");
        }
    }
}
