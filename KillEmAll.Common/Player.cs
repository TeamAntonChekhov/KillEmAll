using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public class Player : Character, IFighter
    {
        static Player instance;
        private int experience;

        private Player(string name) : base(name, CharacterType.Player)
        {
            this.Level = 1;
            this.Experience = 0;
            this.Health += 50;
            this.Damage += 5;
        }

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player("Goshko");
                }
                return instance;
            }
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }
            private set
            {
                this.experience = value;
            }
        }


        public void Attack(IFighter victum)
        {
            // TODO: Attack logic and calculate damage
            double damage = this.damage;

            bool isDead = victum.TakeHit(damage);
            // TODO: Killed monster logic - exp gain

            if (isDead)
            {
                int expReward = BaseExp * victum.Level;
                bool isLevelUp = this.GainExpirience(expReward);
                if (isLevelUp)
                {
                    this.LevelUp();
                }
            }
        }

        private void LevelUp()
        {
            this.level++;
        }

        private bool GainExpirience(int expReward)
        {
            this.experience += expReward;
            int newLevelExp = BaseExp << (this.level + 1);

            if (this.experience >= newLevelExp)
            {
                return true;
            }

            return false;
        }


        public bool TakeHit(double damage)
        {
            // TODO: Defense logic
            double damageTaken = damage - this.armor;

            // TODO: Decrease health
            if (damageTaken > 0)
            {
                this.health -= damageTaken;
            }

            // TODO: Return if playter is dead
            if (this.health <= 0)
            {
                return true;
            }

            return false;
        }

        public bool IsAggressed
        {
            get { throw new NotImplementedException(); }
        }
    }
}
