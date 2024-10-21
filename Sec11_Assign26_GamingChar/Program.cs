using ClassLibrary1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sec11_Assign26_GamingChar
{
    internal class Game
    {
        static void Main(string[] args)
        {


            
            Warrior w1 = new Warrior("asa", 500, 70, 30);
            Warrior w2 = new Warrior("sam", 200, 95, 20);
            w1.Charge(w2);
            w1.Defend();
            System.Console.WriteLine("--------------------------------------------------------\n");

            Mage m1 = new Mage(w1.name,w1.health,w1.attack,w1.defense);
            Mage m2 = new Mage(w2.name, w2.health, w2.attack, w2.defense);
            m1.CastSpell(m2);
            m1.Defend();
            System.Console.WriteLine("--------------------------------------------------------\n");

            Dragon d1 = new Dragon(m1.name, m1.health, m1.attack, m1.defense);
            Dragon d2 = new Dragon(m2.name, m2.health, m2.attack, m2.defense);
            d1.BreatheFire(d2);
            d1.Attack(d2);
            System.Console.WriteLine("--------------------------------------------------------\n");

            Character c1 = new Character(d1.name, d1.health, d1.attack, d1.defense); // Name, Health, Attack, Defense
            Character c2 = new Character(d2.name, d2.health, d2.attack, d2.defense);
            c1.Attack(c2);
            c1.Defend();
            c2.Defend();
            System.Console.WriteLine("--------------------------------------------------------\n");

            System.Console.ReadKey();

        }
    }
}
