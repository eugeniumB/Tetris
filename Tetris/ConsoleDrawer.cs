using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
    internal class ConsoleDrawer : IDrawer
    {
        public void ShowScore()
        {
            Console.SetCursorPosition(6, 0);
            Console.Write("Score: " + Field.Score);
        }

        public void DrawPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write('*');
            Console.SetCursorPosition(0, 0);
        }

        public void GameOver()
        {
            Console.SetCursorPosition(6, 0);
            Console.Write("Game over");
            Console.SetCursorPosition(2, 1);
            Console.Write("Final Score: " + Field.Score);
        }

        public void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            Console.SetCursorPosition(0, 0);
        }

        public void InifField()
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);
        }
    }
}
