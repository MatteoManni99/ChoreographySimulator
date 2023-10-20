using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace ChoreographySimulator
{
    public class Move
    {
        private Point start;
        private Point end;
        private int time;
        private List<Point> path = new List<Point> { };
        private int directionX;
        private int directionY;

        public Move(Point start, Point end, int time)
        {
            this.start = start;
            this.end = end;
            this.time = time;
            path.Add(end);
            path.Add(start);
            directionX = Math.Sign(end.GetX() - start.GetX());
            directionY = Math.Sign(end.GetX() - start.GetX());
            EvaluateAndSetPath();
        }
        
        //TODO improve efficiency
        private Point[] NextCandidatePoints(Point p)
        {
            Point[] pointList = new Point[3];

            if (directionX>0 && directionY>0)
            {
                pointList[0] = new Point(p.GetX() + 1, p.GetY());
                pointList[1] = new Point(p.GetX() + 1, p.GetY() + 1);
                pointList[2] = new Point(p.GetX(), p.GetY() + 1);
            }

            return pointList;
        }

        public void EvaluateAndSetPath()
        {
            
            int count = 0;
            while(!LastPointInPath().IsEqualTo(end))
            {
                Point[] pointsToEvaluate = NextCandidatePoints(LastPointInPath());

                double bestDistance = 1000;
                Point bestPoint = null;

                foreach (Point point in pointsToEvaluate)
                {
                    double newDistance = point.DistanceFromLine(start, end);
                    Debug.WriteLine("point: " + point);
                    Debug.WriteLine("->");
                    Debug.WriteLine("newDistance: " + newDistance);
                    if (newDistance < bestDistance)
                    {
                        bestDistance = newDistance;
                        bestPoint = point;
                    }
                }
                path.Add(bestPoint);

                count++;
                if (count == 1000) break;
            }
        }

        //getter
        public Point LastPointInPath() { return path[path.Count - 1]; }
        public Point GetStartPoint() { return start; }
        public Point GetEndPoint() { return end; }
        public int GetTime() { return time; }
        public List<Point> GetPath() { return path; }

    }
}
