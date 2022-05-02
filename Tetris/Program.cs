using System.Timers;

namespace Tetris
{
    public class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer aTimer;
        static private object _lockObject = new object();

        static Figure s;
        static RandFig generator;
        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InifField();
            DrawerProvider.Drawer.ShowScore();
            Point p = new(Field.Width / 2, 4);

            generator = new RandFig(p);
            s = generator.GetNewFigure();
            SetTimer();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    Strike result = HandleKey(s, key);
                    ProcessResult(result, ref s);
                    Monitor.Exit(_lockObject);
                }
            }
        }

        private static bool ProcessResult(Strike result, ref Figure s)
        {

            if (result == Strike.HEAP_STRIKE || result == Strike.DOWN_STRIKE)
            {
                Field.AddFigure(s);
                Field.CheckAndBreakFullString(s);
                DrawerProvider.Drawer.ShowScore();
                s = generator.GetNewFigure();
                return true;
            }
            else
                if (result == Strike.GAME_OVER)
            {
                DrawerProvider.Drawer.GameOver();
                aTimer.Elapsed -= OnTimedEvent;
                return true;
            }
            else
                return false;
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(TIMER_INTERVAL);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            Strike result = s.TryMove(Direction.DOWN);
            ProcessResult(result, ref s);
            Monitor.Exit(_lockObject);
        }

        private static Strike HandleKey(Figure s, ConsoleKeyInfo key)
        {
            switch (key.Key)
            { 
                case ConsoleKey.Spacebar:
                    return s.TryRotate();
                case ConsoleKey.LeftArrow:
                    return s.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return s.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return s.TryMove(Direction.DOWN);
                case ConsoleKey.A:
                    return s.TryMove(Direction.LEFT);
                case ConsoleKey.D:
                    return s.TryMove(Direction.RIGHT);
                case ConsoleKey.S:
                    return s.TryMove(Direction.DOWN);
                case ConsoleKey.NumPad2:
                    return s.TryMove(Direction.DOWN);
                case ConsoleKey.NumPad4:
                    return s.TryMove(Direction.LEFT);
                case ConsoleKey.NumPad6:
                    return s.TryMove(Direction.RIGHT);
            }
            return Strike.NOTHING;
        }
    }
    
}