using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Directing;
using unit05_cycle.Game.Scripting;
using unit05_cycle.Game.Services;

namespace unit05_cycle
{
    //<summary>
    // Where all the programs come together to work properly, please.
    //</summary>
    class Program
    {
        //<summary>
        //Starts the game.
        //</summary>
        //<param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            //Makes the cast
            Cast cast = new Cast();
            cast.AddActor("PlayerOne", new PlayerOne());
            cast.AddActor("PlayerTwo", new PlayerTwo());
            cast.AddActor("score1", new PlayerOneScore());
            cast.AddActor("score2", new PlayerTwoScore());

            //Makes the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            //Makes the script
            Script script = new Script();
            script.AddAction("input", new PlayerOneActions(keyboardService));
            script.AddAction("input", new PlayerTwoActions(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            //Game start
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
