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
    }
}
