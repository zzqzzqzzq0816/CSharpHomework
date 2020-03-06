using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{

    class Triangle:Shape
    {
        public Triangle(){ }
        public Triangle(double a1,double a2,double a3)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
        }
        public double a1 { get; set; }
        public double a2 { get; set; }
        public double a3 { get; set; }
        public double CalculateArea()
        {
            if (IfLegal())
            {
               double p = (a1 + a2 + a3) / 2;
               return Math.Sqrt(p * (p - a1) * (p - a2) * (p - a3));
            }
            else
            {
                Console.WriteLine("data error");
                return -1;
            }
        }
        public bool IfLegal() => (a1 < a2 + a3) && (a2 < a1 + a3) && (a3 < a1 + a2) && (a1 > 0) && (a2 > 0) && (a3 > 0);
    }
}
