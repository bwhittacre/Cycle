using System;


namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class PlayerOneScore : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of PlayerOne's score.
        /// </summary>
        public PlayerOneScore()
        {
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Player One Score: {this.points}");
        }
    }
}