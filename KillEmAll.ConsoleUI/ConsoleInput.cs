using System;
using KillEmAll.Common;

namespace KillEmAll.ConsoleUI
{
    static public class ConsoleInput
    {
        private static readonly char[] commandSeparators = new char[] { ' ' };
        private static readonly StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries;

        public static void ReadCommand(object sender, EventArgs args)
        {
            GameManager gameManager = (sender as GameManager);

            if (gameManager != null)
            {
                var command = Console.ReadLine().Split(commandSeparators, splitOptions);

                try
                {
                    switch (command[0])
                    {
                        case "goto":
                            HandleChangeLocation(gameManager, command[1]);
                            break;
                        case "fight":
                            HandleAttackEnemy(gameManager, command[1]);
                            break;
                        //case "pickup":
                        //    HandleItemPickUp(gameManager, command[1]);
                        //    break;
                        //case "drop":
                        //    HandleItemDrop(gameManager, command[1]);
                        //    break;
                        //case "use":
                        //    HandleItemUse(gameManager, command[1]);
                        //    break;
                        default:
                            HandleInvalidCommand(command[0]);
                            break;
                    }
                }
                catch (GameObjectNotFoundException e)
                {
                    ConsoleRenderer.AddNotification(new Notification(e.Message, NotificationType.Error));
                }
            }
        }

        private static void HandleInvalidCommand(string command)
        {
            // TODO: Implement custom application exception Invalid command
            // throw new InvalidCommandException(command);
        }

        //private static void HandleItemUse(GameManager gameManager, string itemName)
        //{
        //    gameManager.HandleItemUse(itemName);
        //}

        //private static void HandleItemDrop(GameManager gameManager, string itemName)
        //{
        //    gameManager.HandleItemDrop(itemName);
        //}

        //private static void HandleItemPickUp(GameManager gameManager, string itemName)
        //{
        //    gameManager.HandleItemPickUp(itemName);
        //}

        private static void HandleAttackEnemy(GameManager gameManager, string enemyName)
        {
            gameManager.HandleAttackEnemy(enemyName);
        }

        private static void HandleChangeLocation(GameManager gameManager, string locationName)
        {
            gameManager.HandleChangeLocation(locationName);
        }

        //public static void TestReadInput(object sender, EventArgs e)
        //{
        //    Console.ReadLine();
        //}


    }
}
