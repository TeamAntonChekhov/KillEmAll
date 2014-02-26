using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public abstract class Character : GameObject, IDestroyable
    {
        protected const int BaseExp = 5;
        protected double levelIncreaseFactor;
        protected int level;
        protected double health;
        protected double damage;
        protected double armor;

        protected Character(string name, CharacterType characterType)
            : base(name)
        {
            this.CharacterType = characterType;
            this.levelIncreaseFactor = 1.2;
            // Base stats
            this.health = 20;
            this.damage = 5;
            this.armor = 3;
        }

        public CharacterType CharacterType { get; private set; }

        public int Level
        {
            get
            {
                return this.level;
            }
            protected set
            {
                this.level = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }

            protected set
            {
                this.health = value;
            }
        }

        public double Damage
        {
            get
            {
                return this.damage;
            }
            protected set
            {
                this.damage = value;
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            protected set
            {
                this.armor = value;
            }
        }

        public virtual bool IsDestroyed
        {
            get { return this.Health <= 0; }
        }

        public override string ToString()
        {
            StringBuilder characterInfo = new StringBuilder();
            string separator = " | ";

            characterInfo.AppendFormat("{0}{1}" , base.ToString(), separator);
            characterInfo.AppendFormat("HP - {0}{1}", this.Health, separator);
            characterInfo.AppendFormat("D - {0}{1}", this.Damage, separator);
            characterInfo.AppendFormat("A - {0}{1}", this.Armor, separator);
            characterInfo.AppendFormat("Lv - {0}{1}", this.Level, separator);

            return characterInfo.ToString();
        }
    }
}
