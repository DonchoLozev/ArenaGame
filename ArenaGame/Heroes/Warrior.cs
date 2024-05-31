using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Warrior : Hero
    {
        private double rage;
        public Warrior(string name, double armor, double strenght, IWeapon weapon) :
           base(name, armor, strenght, weapon)
        {
            rage = 0.0;
        }

        public override double Attack()
        {

            double damage = base.Attack();

            if(rage <= 10)
            {
                double angerManegment = 0.05 * base.Attack();
                rage = angerManegment;
            }
            if(rage > 10 && rage <= 50)
            {
                double angerManegment = 0.1 * base.Attack();
                rage = angerManegment;
            }
            if(rage > 50 && rage < 100)
            {
                double angerManegment = 0.15 * base.Attack();
                rage = angerManegment;
            }
            if(rage >= 100)
            {
                double angerManegment = 2 * base.Attack();
                rage = angerManegment;
            }

            double realDamage = base.Attack() + rage;

            if(rage >= 100)
            {
                rage = 0.0;
            }


            return realDamage;
        }

        public override double Defend(double damage)
        {

            double damageTaken = 0.0;

            if(rage <= 10)
            {
                double warriorsWill = 0.05 * damage;
                 damageTaken = damage - warriorsWill;
            }
            if(rage > 10 && rage < 50)
            {
                double warriorsWill = 0.1 * damage;
                 damageTaken = damage - warriorsWill;
            }
            if (rage >= 50 && rage < 100)
            {
                double warriorsWill = 0.15 * damage;
                 damageTaken = damage - warriorsWill;
            }if(rage >= 100)
            {
                 damageTaken = 0.0;
                rage = 0.0;
            }

            base.Defend(damageTaken);
            return damageTaken;
            
        }

    }
}
