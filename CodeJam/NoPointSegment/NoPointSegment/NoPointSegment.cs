using System;

namespace NoPointSegmentProblem
{
    class NoPointSegment
    {
        class Point
        {
            public int xCoordinate, yCoordinate;
            public Point(int x, int y)
            {
                xCoordinate = x;
                yCoordinate = y;
            }
            static bool AreSamePoint(Point A, Point B)
            {
                return (A.xCoordinate == B.xCoordinate && A.yCoordinate == B.yCoordinate) ? true : false;
            }
        }
        class Segment
        {
            public Point pointA, pointB;
            public Segment(int x1, int y1, int x2, int y2)
            {
                pointA = new Point(x1, y1);
                pointB = new Point(x2, y2);
            }
            private int Slope()
            {
                return pointB.xCoordinate - pointA.xCoordinate == 0 ? -1 : 0;
            }
            private int XDistance()
            {
                return Math.Abs(pointA.xCoordinate - pointB.xCoordinate);
            }
            private int YDistance()
            {
                return Math.Abs(pointA.yCoordinate - pointB.yCoordinate);
            }
        }
        public string Intersection(int[] seg1, int[] seg2)
        {
            Segment segment1 = new Segment(seg1[0], seg1[1], seg1[2], seg1[3]);
            Segment segment2 = new Segment(seg2[0], seg2[1], seg2[2], seg2[3]);

            string result = "-";
            return result;
        }

        #region Testing code Do not change
        public static void Main()
        {
            NoPointSegment solver = new NoPointSegment();
            // test case 1 -> NO
            Console.WriteLine(solver.Intersection(new int[] { 0, 0, 0, 1 }, new int[] { 1, 0, 1, 1 }));
            // test case 2 -> POINT
            Console.WriteLine(solver.Intersection(new int[] { 0, 0, 0, 1 }, new int[] { 0, 1, 0, 2 }));
            // test case 3 -> POINT
            Console.WriteLine(solver.Intersection(new int[] { 0, -1, 0, 1 }, new int[] { -1, 0, 1, 0 }));
            // test case 4 -> SEGMENT
            Console.WriteLine(solver.Intersection(new int[] { 0, 0, 2, 0 }, new int[] { 1, 0, 10, 0 }));
            // test case 5 -> NO
            Console.WriteLine(solver.Intersection(new int[] { 5, 5, 5, 5 }, new int[] { 6, 6, 6, 6 }));
            // test case 6 -> SEGMENT
            Console.WriteLine(solver.Intersection(new int[] { 10, 0, -10, 0 }, new int[] { 5, 0, -5, 0 }));
            // test case 7 -> SEGMENT
            Console.WriteLine(solver.Intersection(new int[] { 0, 0, 10, 0 }, new int[] { 10, 0, 0, 0 }));
            // test case 8 -> SEGMENT
            Console.WriteLine(solver.Intersection(new int[] { -778, -799, -600, -799 }, new int[] { -778, -799, -600, -799 }));

            Console.ReadLine();
        }
        #endregion
    }
}
