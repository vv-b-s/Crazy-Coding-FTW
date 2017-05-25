using System;
using static System.Console;

class Human
{
    internal double health = 100;
    internal string AttackPowerName { set; get; }
    internal double Damage { set; get; }
    internal bool Lives => health > 0;

    internal void AttackedBy(Human human) => health -= human.Damage;
    internal void Heal(int turn) => health += turn % 3 == 0 ? 10 : 0;
}
class Program
{
    static void Main()
    {
        Human Pesho = new Human { AttackPowerName = "Roundhouse kick", Damage = double.Parse(ReadLine()) };
        Human Gosho = new Human { AttackPowerName = "Thunderous fist", Damage = double.Parse(ReadLine()) };

        int round = 0;
        while (true)
        {
            Gosho.AttackedBy(Pesho);
            round++;
            if (!Gosho.Lives)
                break;
            WriteLine($"{nameof(Pesho)} used {Pesho.AttackPowerName} and reduced {nameof(Gosho)} to {Gosho.health} health.");



            Gosho.Heal(round);
            Pesho.Heal(round);

            Pesho.AttackedBy(Gosho);
            round++;
            if (!Pesho.Lives)
                break;
            WriteLine($"{nameof(Gosho)} used {Gosho.AttackPowerName} and reduced {nameof(Pesho)} to {Pesho.health} health.");


            Gosho.Heal(round);
            Pesho.Heal(round);
        }

        WriteLine($"{(Pesho.Lives ? nameof(Pesho) : nameof(Gosho))} won in {round}th round.");
    }
}