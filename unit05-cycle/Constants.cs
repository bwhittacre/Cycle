using System;
using Microsoft.VisualBasic;
using unit05_cycle.Game.Casting;

namespace unit05_cycle.Game
{
    /// <summary>
    /// <para>The constants for the game board and colors.</para>
    /// <para>
    /// The measurements used in the rest of the program.
    /// </para>
    /// </summary>
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Cycle";
        public static int SNAKE_LENGTH = 8;

        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
    }
}