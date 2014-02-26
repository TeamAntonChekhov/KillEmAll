using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillEmAll.Common
{
    public class GameManager
    {
        private Location currentLocation;

        public Player Player
        {
            get
            {
                return Player.Instance;
            }
        }

        public Location CurrentLocation
        {
            get
            {
                return currentLocation;
            }
        }

        public event EventHandler Render;
        public event EventHandler UserInput;

        public GameManager()
        {
            currentLocation = World.Init();
        }

        public GameState Run()
        {
            GameState gameState = GameState.NewGame;

            while (true)
            {
                // Draw world event
                if (Render != null)
                {
                    this.OnRender();
                }

                // Player's turn (take action event)
                if (UserInput != null)
                {
                    this.OnUserInput();
                }

                // NPC's turn 
                // TODO: NPC AI class
                TryAttack();

                // If game is ended
                if (gameState != GameState.NewGame)
                {
                    return gameState;
                }
            }
        }

        public void ChangeLocation(Location newLocation)
        {
            // TODO: Validation of newLocation (is it reachable)
            this.currentLocation = newLocation;
        }

        private void TryAttack()
        {
            IEnumerable<IFighter> enemies =
                from enemy in this.CurrentLocation.Characters
                where enemy.CharacterType == CharacterType.Enemy
                select enemy as IFighter;

            foreach (var enemy in enemies)
            {
                if (enemy.IsAggressed)
                {
                    enemy.Attack(this.Player);
                }
            }
        }

        private void OnRender()
        {
            Render(this, new EventArgs());
        }

        private void OnUserInput()
        {
            UserInput(this, new EventArgs());
        }

        public void HandleItemUse(string itemName)
        {
            var item = FindObjectByName(this.Player.Inventory, itemName);

            this.Player.Use(item);
        }

        public void HandleItemDrop(string itemName)
        {
            var item = FindObjectByName(this.Player.Inventory, itemName);

            this.Player.RemoveItem(item);
            this.currentLocation.AddItem(item);
        }

        public void HandleItemPickUp(string itemName)
        {
            var item = FindObjectByName(this.currentLocation.Items, itemName);

            this.Player.AddItem(item);
            this.currentLocation.RemoveItem(item);
        }

        public void HandleAttackEnemy(string enemyName)
        {
            var enemy = FindObjectByName(this.currentLocation.Characters, enemyName);

            this.Player.Attack(enemy);
        }

        public void HandleChangeLocation(string locationName)
        {
            var location = FindObjectByName(this.currentLocation.Exits, locationName);

            this.currentLocation = location;
        }

        private GameObject FindObjectByName(IEnumerable<GameObject> gameObjectCollection, string objectName)
        {
            GameObject foundGameObject = null;

            foreach (var gameObject in gameObjectCollection)
            {
                if (gameObject.Name == objectName)
                {
                    foundGameObject = gameObject;
                }
            }

            if (foundGameObject == null)
            {
                // TODO: 
                // Implement GameObjectNotFoundException(string objectName)

                //throw new GameObjectNotFoundException(objectName);

                throw new NotImplementedException();
            }
            else
            {
                return foundGameObject;
            }
        } 
    }
}
