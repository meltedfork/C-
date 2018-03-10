using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai
{
    public class Samurai : Human
    {
        public Samurai(string name)
        {
          health = 200;  
        }
        public void death_blow(Human enemy)
        {
            if(enemy.health < 50)
            {
                enemy.health = 0;
                System.Console.WriteLine($"{enemy.name} has received the final blow! DEATH!");
            }
        }
        public void meditate(string name)
        {
            health = 200;
            System.Console.WriteLine($"{name} is restored to full health. Namaste.");
        }
    }

}