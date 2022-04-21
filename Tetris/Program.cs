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
                //FigureFall(out s, generator);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    HandleKey(s, key);
                }
                for (int i = 0; i < Console.BufferHeight; i++)
                {
                    if (s.PointArray[0].y == Console.BufferHeight - 1 ||
                        s.PointArray[1].y == Console.BufferHeight - 1 ||
                        s.PointArray[2].y == Console.BufferHeight - 1 ||
                        s.PointArray[3].y == Console.BufferHeight - 1)
                        break;
                    //s.Hide();
                    //s.Move(Direction.down);
                    //s.Draw();
                    //Thread.Sleep(200);
                }

            }

            //static void FigureFall(out Figure fig, RandFig generator)
            //{
            //    fig = generator.GetNewFigure();
            //    fig.Draw();

            //    for (int i = 0; i < Console.BufferHeight; i++)
            //    {
            //        if (fig.PointArray[0].y == Console.BufferHeight - 1 ||
            //            fig.PointArray[1].y == Console.BufferHeight - 1 ||
            //            fig.PointArray[2].y == Console.BufferHeight - 1 ||
            //            fig.PointArray[3].y == Console.BufferHeight - 1)
            //            break;
            //        fig.Hide();
            //        fig.Move(Direction.down);
            //        fig.Draw();
            //        Thread.Sleep(200);
            //    }
            //}

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
                    s.Move(Direction.left);
                    break;
                case ConsoleKey.RightArrow:
                    s.Move(Direction.right);
                    break;
                case ConsoleKey.DownArrow:
                    s.Move(Direction.down);
                    break;
                case ConsoleKey.A:
                    s.Move(Direction.left);
                    break;
                case ConsoleKey.D:
                    s.Move(Direction.right);
                    break;
                case ConsoleKey.S:
                    s.Move(Direction.down);
                    break;
                case ConsoleKey.NumPad2:
                    s.Move(Direction.down);
                    break;
                case ConsoleKey.NumPad4:
                    s.Move(Direction.left);
                    break;
                case ConsoleKey.NumPad6:
                    s.Move(Direction.right);
                    break;
            }

        }
    }
    
}