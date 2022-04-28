namespace Tetris
{
    public class Program
    {
        static RandFig generator;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);

            Point p = new(8, 4);

            generator = new RandFig(p);
            Figure s = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Strike result = HandleKey(s, key);
                    ProcessResult(result, ref s);
                }
            }
        }


        private static bool ProcessResult(Strike result, ref Figure s)
        {
            if (result == Strike.HEAP_STRIKE || result == Strike.DOWN_STRIKE)
            {
                Field.AddFigure(s);
                s = generator.GetNewFigure();
                Field.CheckFullString();
                return true;
            }
            else
                return false;
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