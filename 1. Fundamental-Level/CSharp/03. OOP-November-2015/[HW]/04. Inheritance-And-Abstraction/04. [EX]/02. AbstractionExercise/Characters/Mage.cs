using System;

public class Mage : Character
{
    public Mage()
        : base(100, 300, 75)
    {
    }

    public override void Attack(Character target)
    {
        this.Mana -= 100;
        target.Health -= this.Damage * 2;
    }
}
