using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pub
{
    class PubSimulator
    {
        static public Random random = new Random();
        static public int delay = 3000; // Delay in millisecs to wait between each text output
        public static List<Human> myHumans = new List<Human>();
        
        public void RunPubSimulation() {
            
            // assign derived Human class instance to base reference. Andy can then do only what all humans can do.
            Human andy = new Andy("Andy Capp");
            Human chalkie = new Charlie("Chalkie");
            
            // assign the bartender instance as a Bartender object. The bartender can make use of his unique methods.
            Bartender bartender = new Bartender("George");

            // greetings and an action from each human            
            myHumans.Add(andy);
            myHumans.Add(chalkie);
            myHumans.Add(bartender);

            Console.WriteLine(DateTime.Now.ToShortTimeString());

            andy.Greeting();
            chalkie.Greeting();
            bartender.Greeting();
            PubSimulator.Wait();

            foreach (Human dude in myHumans)
            {                
                var actionInt = PubSimulator.random.Next(dude.Actions.Count());
                dude.PerformAction(actionInt);
            }

             
            // let's start him out sober
            andy.currentBuzzLevel = Human.BuzzLevel.Sober;
            chalkie.currentBuzzLevel = Human.BuzzLevel.Sober;
            andy.currentDamageLevel = Human.DamageLevel.Perfectly_Fine;
            chalkie.currentDamageLevel = Human.DamageLevel.Perfectly_Fine;


            //// let the Bartender object serve up all drinks in the menu for Andy
            Array values = Enum.GetValues(typeof(The_Pub.Bartender.Recipes));
            

            for (int counter = 0; counter < values.Length; counter++)
            {

                Random r = new Random();
                The_Pub.Bartender.Recipes drinkName = (The_Pub.Bartender.Recipes)values.GetValue(r.Next(values.Length));
                int andydrinkValue = (int)drinkName;
                andy.OrderDrink(drinkName.ToString());
                
                PubSimulator.Wait();

                Random r2 = new Random();
                The_Pub.Bartender.Recipes chalkiedrinkName = (The_Pub.Bartender.Recipes)values.GetValue(r2.Next(values.Length));
                int chalkiedrinkValue = (int)chalkiedrinkName;
                chalkie.OrderDrink(chalkiedrinkName.ToString());

                bartender.Comment(andy);
                if (andy.currentBuzzLevel >= Human.BuzzLevel.Plain_Stupid)
                {
                    bartender.ColorLine("Andy, you cannot get any more to drink!");
                    andy.barkeepRefuseService = true;
                    andy.ServeDrink(drinkName.ToString());
                }
                else
                {
                    bartender.ServeDrink(drinkName.ToString(), "Andy");
                }

                if (chalkie.currentBuzzLevel >= Human.BuzzLevel.Plain_Stupid)
                {
                    
                    bartender.ColorLine("Chalkie, you cannot get any more to drink!");
                    chalkie.barkeepRefuseService = true;
                    chalkie.ServeDrink(chalkiedrinkName.ToString());
                } else {
                    bartender.ServeDrink(chalkiedrinkName.ToString(), "Chalkie");
                }

                PubSimulator.Wait();

                andy.ConsumeDrink();
                chalkie.ConsumeDrink();
                andy.currentBuzzLevel = (Human.BuzzLevel)andy.currentBuzzLevel + andydrinkValue;
                chalkie.currentBuzzLevel = (Human.BuzzLevel)chalkie.currentBuzzLevel + chalkiedrinkValue;

                if ((int)andy.currentBuzzLevel >= 20)
                {
                    bartender.ServeDrink("Coffee", "Andy");
                    andy.currentBuzzLevel = andy.currentBuzzLevel - 14;
                }

                if ((int)chalkie.currentBuzzLevel >= 20)
                {
                    bartender.ServeDrink("Coffee", "Chalkie");
                    chalkie.currentBuzzLevel = chalkie.currentBuzzLevel - 14;

                }

                if ((int)chalkie.currentBuzzLevel >= 10)
                {
                    chalkie.ThrowPunch(andy);
                }
                
                if ((int)andy.currentBuzzLevel >= 14)
                {
                    andy.ThrowPunch(chalkie); 
                }

                if ((andy.currentDamageLevel >= Human.DamageLevel.Unconscious) && (chalkie.currentDamageLevel < Human.DamageLevel.Unconscious))
                {
                    Human flo = new Andy("Flo Capp");
                    myHumans.Add(flo);
                    flo.OrderDrink(drinkName.ToString());
                    bartender.ServeDrink(drinkName.ToString(), "Flo");
                    flo.ConsumeDrink();
                    flo.ThrowPunch(chalkie);
                    //break; //Programme stops
                }

                if (andy.currentDamageLevel >= Human.DamageLevel.Dead)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + "      (x.x) Andy is {0}", andy.currentDamageLevel);
                    Policeman policeman = new Policeman("Officer Jones");
                    policeman.Arrest(chalkie, policeman);
                    break;
                }

                if (chalkie.currentDamageLevel >= Human.DamageLevel.Dead)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + "      (x.x) Chalkie is {0}", chalkie.currentDamageLevel);
                    Policeman policeman = new Policeman("Officer Jones");
                    policeman.Arrest(andy, policeman);
                    break;
                }

                if (((int)andy.currentBuzzLevel >= 11) && ((int)andy.currentBuzzLevel <= 19))
                {
                    Policeman policeman = new Policeman("Officer Smith");
                    policeman.Fine(andy, policeman);
                    //break;
                }

                if (((int)chalkie.currentBuzzLevel >= 11) && ((int)andy.currentBuzzLevel <= 19))
                {
                    Policeman policeman = new Policeman("Officer Sam");
                    policeman.Fine(chalkie, policeman);
                    //break;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Andy({2}) now has a buzz Level of {0}\n...and Chalkie({3}) has a buzz Level of {1}", andy.currentBuzzLevel, chalkie.currentBuzzLevel, andy.currentDamageLevel, chalkie.currentDamageLevel);


            }
        }

        static void Main(string[] args)
        {
            PubSimulator p = new PubSimulator();
            p.RunPubSimulation();
        }

        static public void Wait()
        {
            System.Threading.Thread.Sleep(delay);
        }
    }
}
