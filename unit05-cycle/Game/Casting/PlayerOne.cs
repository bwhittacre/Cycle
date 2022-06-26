using System;
using System.Collections.Generic;
using System.Linq;

namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>The body for the first player in the game.</para>
    /// <para>The responsibility of the player is to move itself.</para>
    /// </summary>
    public class PlayerOne : Actor
    {
        private List<Actor> segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of the first player.
        /// </summary>
        public PlayerOne()
        {
            PrepareBody();
        }

        /// <summary>
        /// Gets player one's light bike segments.
        /// </summary>
        /// <returns>The bike segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the actual bike segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets player one's segments (bike included).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the bike by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(Constants.RED);
                segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the cycle in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the cycle for moving.
        /// </summary>
        private void PrepareBody()
        {
            int x = Constants.MAX_X / 4;
            int y = Constants.MAX_Y / 4;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = i == 0 ? Constants.RED : Constants.RED;

                Actor segment1 = new Actor();
                segment1.SetPosition(position);
                segment1.SetVelocity(velocity);
                segment1.SetText(text);
                segment1.SetColor(color);
                segments.Add(segment1);
            }
        }
    }
}