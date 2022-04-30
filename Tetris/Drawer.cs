using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal static class Drawer
    {
        public const char DEFAULT_SYMB = '*';
        internal static void DrawPoint(int x, int y, char c = DEFAULT_SYMB)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }

        internal static void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }
    }
}
