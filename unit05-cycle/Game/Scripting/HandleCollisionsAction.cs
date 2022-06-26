using System;
using System.Collections.Generic;
using System.Data;
using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private bool PlayerOneLose = false;
        private bool PlayerTwoLose = false;
        private int Counter = 0;
        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleGrowth(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGrowth(Cast cast)
        {
            PlayerOne playerone = (PlayerOne)cast.GetFirstActor("PlayerOne");
            PlayerTwo playertwo = (PlayerTwo)cast.GetFirstActor("PlayerTwo");
            PlayerOneScore score1 = (PlayerOneScore)cast.GetFirstActor("score1");
            PlayerTwoScore score2 = (PlayerTwoScore)cast.GetFirstActor("score2");
            Counter = Counter +1;

            if (Counter % 15 == 0)
            {
                playerone.GrowTail(1);
                playertwo.GrowTail(1);
                score1.AddPoints(1);
                score2.AddPoints(1);
            }
        }

        /// <summary>
        /// Sets the game over flag if the players collide with one another.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            PlayerOne playerone = (PlayerOne)cast.GetFirstActor("PlayerOne");
            PlayerTwo playertwo = (PlayerTwo)cast.GetFirstActor("PlayerTwo");
            Actor head1 = playerone.GetHead();
            Actor head2 = playertwo.GetHead();
            List<Actor> body1 = playerone.GetBody();
            List<Actor> body2 = playertwo.GetBody();

            foreach (Actor segment1 in body1)
            {
                foreach (Actor segment2 in body2)
                if (segment1.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    PlayerTwoLose = true;
                }
                else if(segment2.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    PlayerOneLose = true;
                }
                else if(segment2.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    PlayerTwoLose = true;
                }
                else if(segment1.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    PlayerOneLose = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                PlayerOne playerone = (PlayerOne)cast.GetFirstActor("PlayerOne");
                List<Actor> segments1 = playerone.GetSegments();
                PlayerTwo playertwo = (PlayerTwo)cast.GetFirstActor("PlayerTwo");
                List<Actor> segments2 = playertwo.GetSegments();
                //Decides the losing player and sets them to white.
                if(PlayerOneLose == true)
                {
                    foreach (Actor segment in segments1)
                    {
                        int x = Constants.MAX_X / 2;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Player Two Wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);

                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.GREEN);
                    }

                }
                if(PlayerTwoLose == true)
                {
                    foreach (Actor segment in segments2)
                    {
                        int x = Constants.MAX_X / 2;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Player One Wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);

                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.RED);
                    }

                }
            }
        }

    }
} 