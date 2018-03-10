using System;
using System.Collections.Generic;
namespace WizardNinjaSamurai
{
    public class Ninja : Human
    {
        public Ninja(string name)
        {
            dexterity = 175;
        }
        public void steal()
        {
            health += 10;
        }
        public void get_away()
        {
            health -= 15;
        }
    }
}    