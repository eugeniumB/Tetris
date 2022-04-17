namespace Tetris
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Point p1 = new Point(2, 3);
            Point p2 = new Point(4, 5);
            Point p3 = new Point(6, 7);

            Square square = new Square(p1);
            square.DrawSquare();
            Stick stick = new Stick(p3);
            stick.DrawStick();


            Console.ReadLine();
        }

    }

}