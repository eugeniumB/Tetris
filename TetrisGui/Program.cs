using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
    public class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer aTimer;
        static private object _lockObject = new object();

        static Figure figure;
        static Factory factory;
        static bool gameOver = false;
        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InitField();
            DrawerProvider.Drawer.ShowScore();
            Point p = new Point(Field.Width / 2, 4);

            factory = new Factory(p);

            SetTimer();

            figure = factory.GetNewFigure();
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
        }

        private static void GraphicsWindow_KeyDown()
        {
            Monitor.Enter(_lockObject);
            Strike result = HandleKey(figure, GraphicsWindow.LastKey);
            if (GraphicsWindow.LastKey == "Down")
                gameOver = ProcessResult(result, ref figure);
            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(Strike result, ref Figure s)
        {
            if (result == Strike.HEAP_STRIKE || result == Strike.DOWN_STRIKE)
            {
                Field.AddFigure(s);
                Field.CheckAndBreakFullString(figure);
                DrawerProvider.Drawer.ShowScore();

                if (result == Strike.GAME_OVER)
                {
                    DrawerProvider.Drawer.GameOver();
                    aTimer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    figure = factory.GetNewFigure();
                    return false;
                }
            }
            else
                return false;

            //if (result == Strike.HEAP_STRIKE || result == Strike.DOWN_STRIKE)
            //{
            //    Field.AddFigure(s);
            //    Field.CheckAndBreakFullString();
            //    DrawerProvider.Drawer.ShowScore();
            //    s = factory.GetNewFigure();
            //    return true;
            //}
            //else
            //    if (result == Strike.GAME_OVER)
            //{
            //    DrawerProvider.Drawer.GameOver();
            //    aTimer.Elapsed -= OnTimedEvent;
            //    return true;
            //}
            //else
            //    return false;

        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(TIMER_INTERVAL);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            Strike result = figure.TryMove(Direction.DOWN);
            ProcessResult(result, ref figure);
            Monitor.Exit(_lockObject);
        }

        private static Strike HandleKey(Figure s, String key)
        {
            switch (key)
            {
                case "Space":
                    return s.TryRotate();
                case "Left":
                    return s.TryMove(Direction.LEFT);
                case "Right":
                    return s.TryMove(Direction.RIGHT);
                case "Down":
                    return s.TryMove(Direction.DOWN);
                case "A":
                    return s.TryMove(Direction.LEFT);
                case "D":
                    return s.TryMove(Direction.RIGHT);
                case "S":
                    return s.TryMove(Direction.DOWN);
                case "NumPad2":
                    return s.TryMove(Direction.DOWN);
                case "NumPad4":
                    return s.TryMove(Direction.LEFT);
                case "NumPad6":
                    return s.TryMove(Direction.RIGHT);
            }
            return Strike.NOTHING;
        }
}

}