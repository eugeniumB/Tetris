namespace Tetris
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);

            Point p = new(20, 4);

            RandFig generator = new RandFig(p);
            Figure s = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    HandleKey(s, key);
                }
            }


            Console.ReadLine();
        }

        private static void HandleKey(Figure s, ConsoleKeyInfo key)
        {
            switch (key.Key)
            { 
                case ConsoleKey.Spacebar:
                    s.TryRotate();
                    break;
                case ConsoleKey.LeftArrow:
                    s.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    s.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    s.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.A:
                    s.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.D:
                    s.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.S:
                    s.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.NumPad2:
                    s.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.NumPad4:
                    s.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.NumPad6:
                    s.TryMove(Direction.RIGHT);
                    break;
            }

        }
    }
    
}