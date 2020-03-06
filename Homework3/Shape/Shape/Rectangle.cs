using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Rectangle : Shape
    {
        public Rectangle(){ }
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public double length { get; set; }
        public double width { get; set; }
        public bool IfLegal() => length > 0 && width > 0;
        public double CalculateArea()
        {
            if (IfLegal()) return length * width;
            else
            {
                Console.WriteLine("data error");
                return -1;
            }
        }
    }
}
