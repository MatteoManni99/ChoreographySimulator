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
            path.Add(start);
            directionX = Math.Sign(end.GetX() - start.GetX());
            directionY = Math.Sign(end.GetY() - start.GetY());
            EvaluateAndSetPath();
        }
        
        //TODO improve efficiency
        private List<Point> NextCandidatePoints(Point p)
        {
            List<Point> pointList = new List<Point>(); 

            if (directionX == 0 || directionY == 0)
            {
                pointList.Add(new Point(p.GetX() + 1 * directionX, p.GetY() + 1 * directionY));
            }
            else
            {
                pointList.Add(new Point(p.GetX() + 1 * directionX, p.GetY()));
                pointList.Add(new Point(p.GetX() + 1 * directionX, p.GetY() + 1 * directionY));
                pointList.Add(new Point(p.GetX(), p.GetY() + 1 * directionY));
            }

            return pointList;
        }

        public void EvaluateAndSetPath()
        {
            //DEBUG
            int count = 0;

            //Debug.WriteLine("start: " + start);
            //Debug.WriteLine("end: " + end);
            //Debug.WriteLine(LastPointInPath());

            while (!LastPointInPath().IsEqualTo(end))
            {
                List<Point> pointsToEvaluate = NextCandidatePoints(LastPointInPath());

                
                foreach (Point point in pointsToEvaluate)
                {
                    //Debug.WriteLine(point.ToString());
                }

                double bestDistance = 10000; //initilizing the bestDistance to an high threshold
                Point bestPoint = null;

                if (pointsToEvaluate.Count == 1)
                {
                    path.Add(pointsToEvaluate[0]);
                }
                else
                {
                    foreach (Point point in pointsToEvaluate)
                    {
                        double newDistance = point.DistanceFromLine(start, end);
                        
                        //DEBUG
                        //Debug.WriteLine("point: " + point + " -> " + newDistance);

                        if (newDistance < bestDistance)
                        {
                            bestDistance = newDistance;
                            bestPoint = point;
                        }
                    }
                    path.Add(bestPoint);
                }
                

                //DEBUG
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
