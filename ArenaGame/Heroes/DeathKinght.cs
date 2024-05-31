using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class DeathKinght : Hero
    {

        private int hits;
        public DeathKinght(string name, double armor, double strenght, IWeapon weapon) :
            base(name, armor, strenght, weapon)
        {

            hits = 0;

        }

        public override double Attack()
        {

            double damage = base.Attack();
            double ShadowDamage = 0.05 * damage;

            double realDamage = damage + ShadowDamage;

            return realDamage;

        }

        public override double Defend(double damage)
        {
            double boneShield = 5.0;
            hits++;
            if(hits % 2 == 0)
            {
                boneShield += boneShield / 2;
            }

            double damageTaken = damage - boneShield;

            base.Defend(damageTaken);
            return damageTaken;

        }

    }
}
