using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public abstract class Character : GameObject
    {
        protected const int BaseExp = 5;
        protected int level;
        protected double health;
        protected double damage;
        protected double armor;

        protected Character(string name, int level, CharacterType characterType)
            : base(name)
        {
            this.level = level;
            this.CharacterType = characterType;

            // Base stats
            this.health = 50;
            this.damage = 10;
            this.armor = 3;
        }

        public CharacterType CharacterType { get; private set; }

        public void Attack(IFighter victum)
        {
            throw new NotImplementedException();
        }

        public bool TakeHit(double damage)
        {
            throw new NotImplementedException();
        }
    }
}
