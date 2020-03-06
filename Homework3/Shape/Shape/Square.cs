using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Square : Shape
    {
        public Square(){}
        public Square(double length) { this.length = length; }
        public double length { get; set; }
        public double CalculateArea()
        {
            if (IfLegal()) return length * length;
            else
            {
                Console.WriteLine("data error");
                return -1;
            }
        }
        public bool IfLegal() => length > 0;
    }
}
