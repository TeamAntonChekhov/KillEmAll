using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public class Player : Character, IFighter
    {
        static Player instance;
        private int expirience;

        private Player(string name) : base(name, 1, CharacterType.Player)
        {
            this.expirience = 0;
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

        public void Attack(IFighter victum)
        {
            // TODO: Attack logic and calculate damage
            double damage = this.damage;

            bool isDead = victum.TakeHit(damage);
            // TODO: Killed monster logic - exp gain
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
