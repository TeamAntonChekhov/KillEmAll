using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public abstract class Enemy : Character, IFighter
    {
        private bool isAggressed;

        public Enemy(string name, int level, bool aggressive = false)
            : base(name, level, CharacterType.Enemy)
        {
            this.isAggressed = aggressive;
        }

        public bool IsAggressed 
        {
            get
            {
                return this.isAggressed;
            }
            protected set 
            {
                this.isAggressed = value;
            } 
        }

        public abstract void Attack(IFighter victum);

        public bool TakeHit(double damage)
        {
            this.IsAggressed = true;
            double damageTaken = damage - this.armor;

            if (damageTaken > 0)
            {
                this.health -= damageTaken;
            }

            if (this.health <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
