namespace Tetris
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Point p1 = new(2, 3);
            Point p2 = new(4, 5);
            Point p3 = new(6, 7);

            Figure tripod = new Tripod(p1);
            tripod.Draw();

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