using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
    internal class GuiDrawer : IDrawer
    {
        public const int SIZE = 20;
        public void DrawPoint(int x, int y)
        {
            GraphicsWindow.PenColor = "Black";
            GraphicsWindow.PenWidth = 2;
            GraphicsWindow.DrawRectangle(x * SIZE, y * SIZE, SIZE, SIZE);
        }

        public void GameOver()
        {
            GraphicsWindow.BrushColor = GraphicsWindow.BackgroundColor;
            GraphicsWindow.FillRectangle(0, 0, Field.Width * SIZE, SIZE * 2);
            GraphicsWindow.BrushColor = "Black";
            GraphicsWindow.FontSize = SIZE;
            GraphicsWindow.DrawText(100, 0, "Game over");
            GraphicsWindow.DrawText(80, 20, "Finally score: " + Field.Score);
        }

        public void HidePoint(int x, int y)
        {
            GraphicsWindow.PenColor = GraphicsWindow.BackgroundColor;
            GraphicsWindow.PenWidth = 2;
            GraphicsWindow.DrawRectangle(x * SIZE, y * SIZE, SIZE, SIZE);
        }

        public void InitField()
        {
            GraphicsWindow.BackgroundColor = "LightBlue";
            GraphicsWindow.Width = Field.Width * SIZE;
            GraphicsWindow.Height = Field.Height * SIZE;
        }

        public void ShowScore()
        {
            GraphicsWindow.BrushColor = GraphicsWindow.BackgroundColor;
            GraphicsWindow.FillRectangle(0, 0, Field.Width * SIZE, SIZE);
            GraphicsWindow.BrushColor = "Black";
            GraphicsWindow.FontSize = SIZE;
            GraphicsWindow.DrawText(100, 0, "Score: " + Field.Score);
        }
    }
}
