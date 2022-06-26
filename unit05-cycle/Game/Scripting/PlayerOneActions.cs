using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the first player.</para>
    /// <para>
    /// The responsibility of PlayerOneActions is to get the direction and move the first player's cycle.
    /// </para>
    /// </summary>
    public class PlayerOneActions : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of PLayerOneActions using the given KeyboardService.
        /// </summary>
        public PlayerOneActions(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            PlayerOne playerone = (PlayerOne)cast.GetFirstActor("PlayerOne");
            playerone.TurnHead(direction);

        }
    }
} 