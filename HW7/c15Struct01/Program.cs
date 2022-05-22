using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c15Struct01
{
    /*
     * Structure types (C# reference)
     * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct
     * 
     * Value types (C# reference)
     * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types
     */

    struct Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point(Point point)
        {
            this.x = point.x;
            this.y = point.y;
        }

        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => this.y;
            set => this.y = value;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
        
        public override string ToString()
        {
            return string.Format("[{0}; {1}]", X, Y);
        }

        public Point AddPoint(Point point)
        {
            Point pointNew = new Point(point);
            pointNew.X += this.X;
            pointNew.Y += this.Y;
            return pointNew;
        }

        public void Distance()
        { // TODO: HW
            throw new System.NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(10, 20);
            Console.WriteLine("point1 = {0}", point1);
            Point point2 = new Point();
            Console.WriteLine("point2 = {0}", point2);
            Point point3 = new Point(100, 200);
            Point point4 = point1.AddPoint(point3);
            Console.WriteLine("point3 = {0}", point3);
            Console.WriteLine("point4 = {0}", point4);
        }
    }
}
