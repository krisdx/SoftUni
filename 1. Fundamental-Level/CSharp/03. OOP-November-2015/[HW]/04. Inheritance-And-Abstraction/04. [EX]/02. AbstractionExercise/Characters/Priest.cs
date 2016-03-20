using System;

public class Priest : Character, IHeal
{
    public Priest()
        : base(125, 200, 100)
    {
    }

    public override void Attack(Character target)
    {
        this.Mana -= 100;
        target.Health -= this.Damage;
        this.Health += this.Damage / 10;
    }

    public void Heal()
    {
        this.Mana -= 100;
        this.Health += 150;
    }
}