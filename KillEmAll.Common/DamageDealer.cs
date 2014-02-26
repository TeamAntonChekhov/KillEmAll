using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public class DamageDealer : Enemy
    {
        public DamageDealer(string name, int level)
            : base(name, level)
        {
        }

        public override void Attack(IFighter victum)
        {
            double damage = this.damage;

            bool isPlayerDead = victum.TakeHit(damage);
        }
    }
}
