using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pub
{
    public abstract class Human
    {
        public bool barkeepRefuseService = false;

        public string Name;
        public string[] Actions;        
        // abstract methods, these can be overridden in derived classes
        public abstract void Greeting();
        public abstract void OrderDrink(string drinkName);
        public abstract void ConsumeDrink();
        public abstract void PerformAction(int actionNumber);

        protected ConsoleColor textColor;
        public void ThrowPunch(Human otherGuy){
            if((int)this.currentDamageLevel < 6)
            {
                ColorLine(Name + " hits " + otherGuy.Name);
                otherGuy.currentDamageLevel++;
            }
        }
        
        public String whatsMyname()
        {
            return Name;
        }

        public enum BuzzLevel
        {
            Sober = 1,
            Rare = 2,
            Medium = 4,
            Well_Done = 6,
            Toasted = 8,
            Fairly_Silly = 10,
            Plain_Stupid = 12,
            Wasted = 14,
            Brain_Has_Left_The_Building = 20
        }

        public enum DamageLevel
        {
            Perfectly_Fine = 1,
            Off_Balance = 2,
            Dizzy = 3,
            Badly_Hurt = 4,
            Unconscious = 5,
            Dead = 6
        }

        // human properties we will want to get and set from the main method        
        public BuzzLevel currentBuzzLevel { get; set; }
        public DamageLevel currentDamageLevel { get; set; }

        public void ServeDrink(string currentDrink)
        {
            // Make a short pause before filling up customer's drink glass
            PubSimulator.Wait();
            ColorLine(Name + " serves up a " + currentDrink + " for oneself.");
        }

        public void ColorLine(string textOutput)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(textOutput);
        }

    }
}
