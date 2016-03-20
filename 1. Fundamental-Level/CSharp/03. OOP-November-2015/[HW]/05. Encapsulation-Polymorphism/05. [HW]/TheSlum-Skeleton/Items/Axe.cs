namespace TheSlum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Axe : Item
    {
        public Axe(string id, int healthEffect = 0, int defenseEffect = 0, int attackEffect = 75)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}