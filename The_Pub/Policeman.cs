using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pub
{
    public class Policeman : Human
    {
        
        public Policeman(string name)  {
            this.textColor = ConsoleColor.DarkYellow;
            this.Name = name;   // access protected member
            this.Actions = new string[] { "ogles the waitress", "looks at the drinks menu", "decides to go for a pee" };
        }

        public override void Greeting() {   // implement abstract method        
            ColorLine("Hi there, I'm " + Name + " Thish here bar looks really intereshting!");
        }

        public override void PerformAction(int actionNumber) { 
            var chosenAction =  this.Actions[actionNumber];
            ColorLine(Name + " " + chosenAction);
        }

        public override void OrderDrink(string currentDrink)
        {
            // Order a specific drink
            ColorLine("Hey, Bartender - I'd like a " + currentDrink);            
        }

        public override void ConsumeDrink()
        {
            // Consume a drink
            ColorLine(Name + " dips nose into glass and contents disappear mysteriously..");
        }

        public void Arrest(Human customer, Human policeman)
        {
            ColorLine(policeman.Name + ": I am arresting " + customer.Name);
        }

        public void Fine(Human customer, Human policeman)
        {
            ColorLine(policeman.Name + ": " + customer.Name + " I am giving you af fine of 1000 kr.");
        }
       
    }
}
