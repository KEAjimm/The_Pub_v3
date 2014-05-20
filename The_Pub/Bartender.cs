using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pub
{
    public class Bartender : Human
    {
        //public string[] Recipes = { "Sex on the Beach", "Vodka Martini", "Screwdriver", "Bloody Mary", "Alien Turpentine", "Lemon Twister" };

        public enum Recipes
        {
            Rum_and_Coke = 1,
            Screwdriver = 2,
            Bloody_Mary = 3,
            Sex_on_the_Beach = 4,
            Vodka_Martini = 5,
            Daiquiri = 6,
            Gin_and_Tonic = 7,
            Mojito = 8,
            Cosmopolitan = 9,
            Lemon_Twister = 10,
            Alien_Turpentine = 11
        }

        public Bartender(string name)
        {
            this.textColor = ConsoleColor.Magenta;
            this.Name = name;   // access protected member
            this.Actions = new string[] { "checks the cash register.. yep, it's full!", 
                                          "gives the pub dog a fresh bowl of water.", 
                                          "fills up the peanut bag dispenser.",
                                          "washes his hands and looks into the sink, and wishes he hadn't!",
                                          "looks in the fridge to check for possible aliens on the lam."};
        }

        public override void Greeting()   // implement abstract method
        {
            ColorLine("Hi there, I'm " + Name +" This is my bar, and you will be well served!");
        }

        public override void PerformAction(int actionNumber)
        {
            var chosenAction = this.Actions[actionNumber];
            ColorLine(Name + " " + chosenAction);
        }

        public override void OrderDrink(string currentDrink)
        {
            // If the barkeep is asked to order a specific drink for himself, he won't do so..
            ColorLine("I'm the Bartender - I don't drink " + currentDrink);
        }

        public override void ConsumeDrink()
        {
            // Consume a drink.. ah well. I'm the barkeep, so I will wait till much later.
            ColorLine("Barkeep disappears the drink mysteriously, to be scrutinized later on.");
        }

       
        // switch statement here, giving a measured response according to current BuzzLevel
        public void Comment(Human myCustomer)
        {

            switch (myCustomer.currentBuzzLevel)
            {
                case Human.BuzzLevel.Sober:
                    ColorLine("Bartender: Hello "+myCustomer.Name +", your drink is coming right up.. how is the weather outside?");
                    break;
                case Human.BuzzLevel.Rare:
                    ColorLine("Bartender: Your drink is coming right up " + myCustomer.Name + ", it's a rare treat in here to have customers like you!");
                    break;
                case Human.BuzzLevel.Medium:
                    ColorLine("Bartender: Ok, " + myCustomer.Name + ", your drink is coming right up, medium size..");
                    break;
                case Human.BuzzLevel.Well_Done:
                    ColorLine("Bartender: Your drink is coming right up " + myCustomer.Name + ", almost done..");
                    break;
                case Human.BuzzLevel.Toasted:
                    ColorLine("Bartender: Here you go " + myCustomer.Name + ", this is the right one..");
                    break;
                case Human.BuzzLevel.Fairly_Silly:
                    ColorLine("Bartender: " + myCustomer.Name +", your drink is coming right up, this is silly..");
                    break;
                case Human.BuzzLevel.Plain_Stupid:
                    ColorLine("Bartender: " +myCustomer.Name +", is this not a bit stupid..");
                    break;
                case Human.BuzzLevel.Wasted:
                    ColorLine("Bartender: A drink is wasted on you " + myCustomer.Name + "...");
                    break;
                case Human.BuzzLevel.Brain_Has_Left_The_Building:
                    ColorLine("Bartender: " + myCustomer.Name +", your brain has left the building");
                    break;
                default:
                    ColorLine("Bartender: One moment, " + myCustomer.Name + "...");
                    break;
            }
            
        }

        public void ServeDrink(string currentDrink, string person)
        {
            // Make a short pause before filling up customer's drink glass
            PubSimulator.Wait();
            ColorLine(Name + " serves up a " + currentDrink + " to " + person);
        }

    }
}
