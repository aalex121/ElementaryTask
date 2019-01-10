using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_TriangleSort
{
    class Triangle : IComparable<Triangle>
    {
        const string BUILD_ERROR_MESSAGE = "Unable to build triangle with current parameters!";
 
        public Triangle(string inputName, double inputSide1, double inputSide2, double inputSide3)
        {
            Name = inputName;
            Side1 = inputSide1;
            Side2 = inputSide2;
            Side3 = inputSide3;

            Area = GetArea(Side1, Side2, Side3);
        }
        
        public string Name { get; private set; }

        public double Side1 { get; private set; }

        public double Side2 { get; private set; }

        public double Side3 { get; private set; }

        public double Area { get; private set; }

        public int CompareTo(Triangle other)
        {
            int result = 0;

            if (Area > other.Area)
            {
                result = 1;
            }

            if (Area < other.Area)
            {
                result = -1;
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("[Triangle {0}]: {1} cm", Name, Area);
        }

        public static double GetArea(double side1, double side2, double side3)
        {
            double semiPerimeter = (side1 + side2 + side3) / 2;

            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - side1) *
                (semiPerimeter - side2) * (semiPerimeter - side3));

            if (double.IsNaN(area) || area <= 0)
            {
                throw new UnableToBuildTriangleException(BUILD_ERROR_MESSAGE);
            }

            return area;
        }
    }
}
