using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace KillEmAll.Common
{
    internal static class World
    {
        private static Location entranceLocation;

        public static Location Init()
        {
            InitializeDungeons();

            return entranceLocation;
        }

        private static void InitializeDungeons()
        {
            Dungeon firstDungeon = new Dungeon("ZombieLake",
                new HashSet<Character>()
                {
                    new DamageDealer("DeadCrusader", 1),
                    new DamageDealer("ZombieSoldier", 1),
                    new DamageDealer("DragonZombie", 1),
                },
                new Collection<Item>()
                {
                    new Potion("HealPotion"),
                    new Potion("PoisonPotion"),
                });

            Dungeon secondDungeon = new Dungeon("InsectBeehive",
                new HashSet<Character>()
                {
                    new DamageDealer("GiantSpider", 1),
                    new DamageDealer("LadyOfTheCrypt", 1),
                    new DamageDealer("Larva", 1),
                },
                new Collection<Item>()
                {
                    new Potion("Heal Potion"),
                });
            Dungeon thirdDungeon = new Dungeon("SpiderNest",
               new HashSet<Character>()
                {
                    new DamageDealer("GiantSpider", 1),
                    new DamageDealer("LadyOfTheCrypt", 1),
                    new DamageDealer("BlackWidow", 1),
                },
               new Collection<Item>()
                {
                    new Potion("Heal Potion"),
                });
            Dungeon fourthDungeon = new Dungeon("SpiritForest",
               new HashSet<Character>()
                {
                    new DamageDealer("Ghost", 1),
                    new DamageDealer("Wraith", 1),
                    new DamageDealer("Banshee", 1),
                },
               new Collection<Item>()
                {
                    new Potion("Heal Potion"),
                });


            firstDungeon.AddExit(secondDungeon, thirdDungeon);
            secondDungeon.AddExit(firstDungeon, fourthDungeon);
            thirdDungeon.AddExit(firstDungeon, fourthDungeon);
            fourthDungeon.AddExit(secondDungeon, thirdDungeon);

            entranceLocation = firstDungeon;
        }

    }
}
