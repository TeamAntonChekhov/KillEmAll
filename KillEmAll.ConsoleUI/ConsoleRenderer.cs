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
        private static List<Notification> notifications = new List<Notification>();

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
            Console.WriteLine(string.Format("{0,0} {1,0} {2,0}", new string('═', 25), "You", new string('═', 68 - (25 + "You".Length))));

            Console.WriteLine(player.ToString());
        }

        private static void RenderCurentDungeon(string currentDungeon)
        {
            Console.WriteLine(string.Format("{0,0} {1,0} {2,0}", new string('═', 25), currentDungeon, new string('═', 68 - (25 + currentDungeon.Length))));
        }

        private static void RenderDungeonItems(IEnumerable<Item> items)
        {
            Console.WriteLine("Items:");

            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void RenderDugeonExits(IEnumerable<Location> exits)
        {
            Console.WriteLine("Exits:");

            foreach (var exit in exits)
            {
                Console.WriteLine(exit.ToString());
            }
        }

        private static void RenderEnemies(IEnumerable<Character> monsters)
        {
            Console.WriteLine("Monsters:");

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

        public static void AddNotification(Notification notification)
        {
            notifications.Add(notification);
        }

        public static void RenderNotification(object sender, EventArgs e)
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 2 - i);
                Console.Write("#{0}: {1}", notifications[i].NotificationType.ToString(), notifications[i].Message);
            }

            notifications.Clear();

            SetCursorToBottom();
        }

        public static void SetCursorToBottom()
        {
            int x = 0;
            int y = Console.WindowHeight - 1;

            Console.SetCursorPosition(x, y);

            Console.Write("->");
        }
    }
}
