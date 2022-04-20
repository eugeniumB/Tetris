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

                for (int i = 0; i < 15; i++)
                {
                    fig.Hide();
                    fig.Move(Direction.down);
                    fig.Draw();
                    Thread.Sleep(200);
                }
            }

            //Figure[] figures = new Figure[2];
            //figures[0] = new Square(p1);
            //figures[1] = new Stick(p3);

            //figures[1].Draw();
            //Thread.Sleep(1000);
            //figures[1].Hide();
            //figures[1].Rotate();
            //figures[1].Draw();

            Console.ReadLine();
        }
    }
    
}