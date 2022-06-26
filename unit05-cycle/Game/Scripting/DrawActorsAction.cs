using System.Collections.Generic;
using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            PlayerOne playerone = (PlayerOne)cast.GetFirstActor("PlayerOne");
            List<Actor> segments1 = playerone.GetSegments();
            PlayerTwo playertwo = (PlayerTwo)cast.GetFirstActor("PlayerTwo");
            List<Actor> segments2 = playertwo.GetSegments();
            Actor score1 = cast.GetFirstActor("score1");
            Actor score2 = cast.GetFirstActor("score2");
            score2.SetPosition(new Point(Constants.MAX_X -200, 0));
            List<Actor> messages = cast.GetActors("messages");

            videoService.ClearBuffer();
            videoService.DrawActors(segments1);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score1);
            videoService.DrawActor(score2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}