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
            Figure s = null;

            while (true)
            {
                FigureFall(s, generator);
            }

            static void FigureFall(Figure fig, RandFig generator)
            {
                fig = generator.GetNewFigure();
                fig.Draw();

                for (int i = 0; i < Console.BufferHeight; i++)
                {
                    if (fig.PointArray[0].y == Console.BufferHeight - 1 ||
                        fig.PointArray[1].y == Console.BufferHeight - 1 ||
                        fig.PointArray[2].y == Console.BufferHeight - 1 ||
                        fig.PointArray[3].y == Console.BufferHeight - 1)
                        break;
                    fig.Hide();
                    fig.Move(Direction.down);
                    fig.Draw();
                    Thread.Sleep(200);
                }
            }

            Console.ReadLine();
        }
    }
    
}