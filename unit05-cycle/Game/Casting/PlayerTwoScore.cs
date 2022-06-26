using System;


namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>Player Two's score.</para>
    /// <para>
    /// The responsibility of PlayerTwoScore is to keep track of the second player's score.
    /// </para>
    /// </summary>
    public class PlayerTwoScore : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of Player Two's score.
        /// </summary>
        public PlayerTwoScore()
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
            SetText($"Player Two's Score: {this.points}");
        }
    }
}