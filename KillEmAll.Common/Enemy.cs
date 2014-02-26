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
            : base(name, CharacterType.Enemy)
        {
            this.level = level;
            this.isAggressed = aggressive;

            double statLevelMultiplier = Math.Pow(levelIncreaseFactor, level);
            this.Health *= statLevelMultiplier;
            this.Armor *= statLevelMultiplier;
            this.Damage *= statLevelMultiplier;
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

        public int Level
        {
            get
            {
                return this.level;
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

        public bool IsDestroyed
        {
            get { return this.Health <= 0; }
        }
    }
}
