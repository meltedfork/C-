using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai
{
    public class Wizard : Human
    {
        public Wizard(string name)
        {
            health = 50;
            intelligence = 25;
        }

        public void heal()
        {
            health += 10 * intelligence;
        }

        public void fireball(Human enemy)
        {
            Random rand = new Random();
            int damage = rand.Next(20,50);
            enemy.health -= damage;
            System.Console.WriteLine($"{enemy.name} now has {enemy.health} health remaining.");
        }
    }
}