using KillEmAll.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillEmAll.ConsoleUI
{
    static class GameScreen
    {

        public static GameState GameOver()
        {
            using (StreamReader reader = new StreamReader("gameover.txt"))
            {
                string line = String.Empty;
                while (line != null)
                {
                    line = reader.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(line);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Press enter to go to the main menu");
            Console.ReadLine();
            return GameState.MainMenu;
        }

        public static void PlayMusicExit()
        {
            Console.Beep(495, 700);
            Console.Beep(528, 400);
            Console.Beep(660, 400);
            Console.Beep(880, 700);
        }
    }
}
