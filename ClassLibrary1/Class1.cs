using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1
{
    public class Character
    {
        public string name;
        public int health;
        public int attack;
        public int defense;

        public Character (string Name, int Health, int Attack, int Defense)
        {
            name = Name;
            health = Health;
            attack = Attack;
            defense = Defense;
            System.Console.WriteLine ("Initial players Stats: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", Defense = " + defense);
        }
        
        public virtual void Attack(Character target)
        {
            if (target.attack < defense)
            {
                System.Console.WriteLine(target.name + " attacks " + name + " for " + target.attack + " damages.");
                //System.Console.WriteLine(defense - target.attack);               
                defense = defense - target.attack;
                target.attack = 0;
                System.Console.WriteLine("After battle: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", Defense = " + defense);
                System.Console.WriteLine("After battle: Name = " + target.name + ", Health = " + target.health + ", Attack = " + target.attack + ", Defense = " + target.defense);
            }
            else
            {
                System.Console.WriteLine(target.name + " attacks " + name + " for " + target.attack + " damages.");
                //System.Console.WriteLine(target.attack - defense);
                target.attack = target.attack - defense;
                defense = 0;
                health = health - target.attack;
                target.attack = 0;
                System.Console.WriteLine("After battle: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", Defense = " + defense);
                System.Console.WriteLine("After battle: Name = " + target.name + ", Health = " + target.health + ", Attack = " + target.attack + ", Defense = " + target.defense);
            }

            if (attack < target.defense)
            {
                System.Console.WriteLine(name + " attacks " + target.name + " for " + attack + " damages.");
                //System.Console.WriteLine(target.defense - attack);
                target.defense = target.defense - attack;
                attack = 0;
                System.Console.WriteLine("After battle: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", Defense = " + defense);
                System.Console.WriteLine("After battle: Name = " + target.name + ", Health = " + target.health + ", Attack = " + target.attack + ", Defense = " + target.defense);
                if (target.health < health)
                {
                    System.Console.WriteLine(name + " wins.");
                }
                else
                {
                    System.Console.WriteLine(target.name + " wins.");
                }
            }
            else
            {
                System.Console.WriteLine(name + " attacks " + target.name + " for " + attack + " damages.");
                //System.Console.WriteLine(attack - target.defense);
                attack = attack - target.defense;
                target.defense = 0;
                target.health = target.health - attack;
                attack = 0;
                System.Console.WriteLine("After battle: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", Defense = " + defense);
                System.Console.WriteLine("After battle: Name = " + target.name + ", Health = " + target.health + ", Attack = " + target.attack + ", Defense = " + target.defense);

                if (target.health < health)
                {
                    System.Console.WriteLine(name + " wins.");
                }
                else
                {
                    System.Console.WriteLine(target.name + " wins.");
                }
            }
          
        }
        public virtual void Defend()
        {
            if (defense != 0)
            {
                System.Console.WriteLine(name + " defends.");
            }
            //how to print name of bigger health number
        }
    }

    public class Warrior : Character
    {
        public Warrior(string Name, int Health, int Attack, int Defense) : base (Name, Health, Attack, Defense)
        {
        }
        public void Charge(Character target)
        {
            System.Console.WriteLine(name + " is charging at " + target.name);
            System.Console.WriteLine("After Charge: Name = " + target.name + ", Health = " + target.health + ", Attack = " + target.attack + ", Defense = " + target.defense);
        }
        public override void Defend()
        {
            defense = defense + 5;
            System.Console.WriteLine("After Charge: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", New Defense = " + defense);
        }

    }

    public class Mage : Character
    {
        public Mage(string Name, int Health, int Attack, int Defense) : base(Name, Health, Attack, Defense)
        {

        }
        public void CastSpell(Character target)
        {
            System.Console.WriteLine(name + " is casting a spell at " + target.name);
            target.defense = 0;
            System.Console.WriteLine("After Casting Spell: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", Defense = " + defense);
            System.Console.WriteLine("After Casting Spell: Name = " + target.name + ", Health = " + target.health + ", Attack = " + target.attack + ", New Defense = " + target.defense);
        }
        public override sealed void Defend()
        {
            System.Console.WriteLine("Defend sealed");
        }

    }

    public class Dragon : Character
    {
        public Dragon(string Name, int Health, int Attack, int Defense) : base(Name, Health, Attack, Defense)
        {

        }
        public void BreatheFire(Character target)
        {
            System.Console.WriteLine(name + " the dragon breathes fire at " + target.name);
        }
        public override void Attack(Character target)
        {
            target.health = target.health - 20;
            System.Console.WriteLine("After Attacking Again: Name = " + name + ", Health = " + health + ", Attack = " + attack + ", Defense = " + defense);
            System.Console.WriteLine("After Attacking Again: Name = " + target.name + ", New Health = " + target.health + ", Attack = " + target.attack + ", Defense = " + target.defense);
        }

    }
}
