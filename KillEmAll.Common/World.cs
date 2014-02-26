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
        private static List<Dungeon> dungeons;
        private static List<Item> items;
        private static List<Character> characters;

        static World()
        {
            dungeons = new List<Dungeon>();
            items = new List<Item>();
            characters = new List<Character>();
        }

        public static Location Init()
        {
            InitializeDungeons();

            return entranceLocation;
        }

        private static void InitializeDungeons()
        {
            Dungeon firstDungeon = new Dungeon("InitialDungeon",
                new HashSet<Character>()
                {
                    new DamageDealer("Monster1", 1),
                    new DamageDealer("Monster2", 1),
                    new DamageDealer("Monster3", 1),
                },
                new Collection<Item>()
                {
                    new Potion("Heal Potion"),
                    new Potion("Heal Potion"),
                });

            Dungeon secondDungeon = new Dungeon("SecondaryDungeon",
                new HashSet<Character>()
                {
                    new DamageDealer("Monster1", 1),
                    new DamageDealer("Monster2", 1),
                    new DamageDealer("Monster3", 1),
                },
                new Collection<Item>()
                {
                    new Potion("Heal Potion"),
                    new Potion("Heal Potion"),
                });

            dungeons.Add(new Dungeon("FirstDungeon", new HashSet<Character>(), new Collection<Item>()));
            dungeons.Add(new Dungeon("SecondDungeon", new HashSet<Character>(), new Collection<Item>()));
            dungeons.Add(new Dungeon("ThirdDungeon", new HashSet<Character>(), new Collection<Item>()));

            firstDungeon.AddExit(dungeons[0], secondDungeon);
            secondDungeon.AddExit(firstDungeon);
            dungeons[0].AddExit(dungeons[1], dungeons[2], firstDungeon);
            dungeons[1].AddExit(dungeons[0], dungeons[2]);
            dungeons[2].AddExit(dungeons[0], dungeons[1]);

            entranceLocation = firstDungeon;
        }

    }
}
