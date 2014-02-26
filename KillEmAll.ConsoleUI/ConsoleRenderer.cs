using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillEmAll.Common;

namespace KillEmAll.ConsoleUI
{
    public static class ConsoleRenderer
    {

        public static void DrawTextOnPostion(int row, int col, string text, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void ClearConsoleBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        internal static void RenderLocationInfo(object sender, EventArgs e)
        {
            ClearRender();
            Location currentLocation = (sender as GameManager).CurrentLocation;

            RenderCurentDungeon(currentLocation.Name);
            RenderDugeonExits(currentLocation.Exits);
            RenderDungeonItems(currentLocation.Items);
            RenderEnemies(currentLocation.Characters);
        }

        public static void RenderPlayerInfo(object sender, EventArgs e)
        {
            Player player = (sender as GameManager).Player;

            RenderPlayerStats(player);
            SetCursorToBottom();
        }

        private static void RenderPlayerStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0,0} {1,0} {2,0}", new string('═', 30), "You", new string('═', 68 - (30 + "You".Length))));
            Console.ResetColor();
            Console.WriteLine(player.ToString());
        }

        private static void RenderCurentDungeon(string currentDungeon)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("{0,0} {1,0} {2,0}", new string('═', 25), currentDungeon, new string('═', 68 - (25 + currentDungeon.Length))));
            Console.ResetColor();
        }

        private static void RenderDungeonItems(IEnumerable<Item> items)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Items:");
            Console.ResetColor();

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void RenderDugeonExits(IEnumerable<Location> exits)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Exits:");
            Console.ResetColor();

            foreach (var exit in exits)
            {
                Console.WriteLine(exit.ToString());
            }
        }

        private static void RenderEnemies(IEnumerable<Character> monsters)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Monsters:");
            Console.ResetColor();

            foreach (var monster in monsters)
            {
                Console.WriteLine(monster.ToString());
            }
            Console.WriteLine();
        }

        private static void ClearRender()
        {
            Console.Clear();
        }

        private static void RenderNotification()
        {
            //DrawTextOnPostion(49, 0 , )
        }

        public static void SetCursorToBottom()
        {
            int x = 0;
            int y = Console.WindowHeight - 1;

            Console.SetCursorPosition(x, y);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("->");
        }
    }
}
