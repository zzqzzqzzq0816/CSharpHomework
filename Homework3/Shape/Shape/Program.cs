using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle t = new Triangle(1, 2, 3);
            Console.WriteLine(t.CalculateArea());
            double sumArea = 0;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for(int i = 0; i < 10; i++)
            {
                int tmp = random.Next(1, 4);
                switch (tmp)
                {
                    case 1:
                        Random random1 = new Random(Guid.NewGuid().GetHashCode());
                        Rectangle rectangle = new Rectangle(random1.Next(1, 100), random1.Next(1, 100));
                        Console.WriteLine("生成了一个矩形，面积为："+rectangle.CalculateArea());
                        sumArea += rectangle.CalculateArea();
                        break;
                    case 2:
                        Random random2 = new Random(Guid.NewGuid().GetHashCode());
                        Square square = new Square(random2.Next(1, 100));
                        Console.WriteLine("生成了一个正方形，面积为："+square.CalculateArea());
                        sumArea += square.CalculateArea();
                        break;
                    case 3:
                        Random random3 = new Random(Guid.NewGuid().GetHashCode());
                        Triangle triangle = null;
                        while (true)
                        {
                            triangle = new Triangle(random3.Next(1, 100), random3.Next(1, 100), random3.Next(1, 100));
                            if (triangle.IfLegal()) break;
                        }
                        Console.WriteLine("生成了一个三角形，面积为："+triangle.CalculateArea());
                        sumArea += triangle.CalculateArea();
                        break;
                }
            }
            Console.WriteLine("总面积为：" + sumArea);
        }
    }
}
