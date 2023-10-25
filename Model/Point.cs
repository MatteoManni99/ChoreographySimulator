using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoreographySimulator
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x_, int y_)
        {
            x = x_;
            y = y_;
        }
        public int GetX() { return x; }
        public int GetY() { return y; }
        public bool IsEqualTo(Point anOtherPoint)
        {
            return anOtherPoint.GetX() == this.x && anOtherPoint.GetY() == this.y;
        }
        public double DistanceFromLine(Point linePoint1, Point linePoint2)
        {
            // y = m * (x − x1) + y1
            double m = (double)(linePoint2.GetY() - linePoint1.GetY()) / (linePoint2.GetX() - linePoint1.GetX());
            double q = linePoint1.GetY() - (m * linePoint1.GetX());

            double numerator = Math.Abs(y - m * x - q);
            double denominator = Math.Sqrt(1 + m * m);
            
            return numerator / denominator;
        }

        override public String ToString()
        {
            return x.ToString() + " " + y.ToString();
        }
    }
}
