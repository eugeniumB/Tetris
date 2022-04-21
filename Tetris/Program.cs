namespace Tetris
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

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
                    s.Rotate();
                    break;
                case ConsoleKey.LeftArrow:
                    s.TryMove(Direction.left);
                    break;
                case ConsoleKey.RightArrow:
                    s.TryMove(Direction.right);
                    break;
                case ConsoleKey.DownArrow:
                    s.TryMove(Direction.down);
                    break;
                case ConsoleKey.A:
                    s.TryMove(Direction.left);
                    break;
                case ConsoleKey.D:
                    s.TryMove(Direction.right);
                    break;
                case ConsoleKey.S:
                    s.TryMove(Direction.down);
                    break;
                case ConsoleKey.NumPad2:
                    s.TryMove(Direction.down);
                    break;
                case ConsoleKey.NumPad4:
                    s.TryMove(Direction.left);
                    break;
                case ConsoleKey.NumPad6:
                    s.TryMove(Direction.right);
                    break;
            }

        }
    }
    
}