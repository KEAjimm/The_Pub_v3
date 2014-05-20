using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pub
{
    public class Charlie : Human
    {
        
        public Charlie(string name)  {
            this.textColor = ConsoleColor.Green;
            this.Name = name;   // access protected member
            this.Actions = new string[] { "pats the waitress on the rear", "looks at the drinks menu upside down and crosseyed", "decides to pee behind the bar" };
        }

        public override void Greeting() {   // implement abstract method 
            ColorLine(Name + ": Hi there, I need a drink 'cause I'm thirsty!");
        }

        public override void PerformAction(int actionNumber) {
            var chosenAction =  this.Actions[actionNumber];
            ColorLine(Name + " " + chosenAction);
        }

        public override void OrderDrink(string currentDrink)
        {
            // Order a specific drink
            ColorLine(Name + ": Gimme a " + currentDrink);            
        }

        public override void ConsumeDrink()
        {
            // Consume a drink
            ColorLine(Name + " slurps the drink through a straw..");
        }
    }
}