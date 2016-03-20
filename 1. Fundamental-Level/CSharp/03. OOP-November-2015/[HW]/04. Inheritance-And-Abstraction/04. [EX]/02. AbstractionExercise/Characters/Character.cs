using System;

public abstract class Character : IAttak
{
    protected Character(int health, int mana, int damange)
    {
        this.Health = health;
        this.Mana = mana;
        this.Damage = damange;
    }

    public int Health { get; set; }
    public int Mana { get; set; }
    public int Damage { get; set; }

    public abstract void Attack(Character target);
}