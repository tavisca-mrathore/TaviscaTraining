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
            public static int XDistance(Point pointA, Point pointB)
            {
                return Math.Abs(pointA.xCoordinate - pointB.xCoordinate);
            }
            public static int YDistance(Point pointA, Point pointB)
            {
                return Math.Abs(pointA.yCoordinate - pointB.yCoordinate);
            }
        }
        class Segment
        {
            public Point pointA, pointB;
            public Segment(int x1, int y1, int x2, int y2)
            {
                if (x1 == x2)// || to x-axis
                {
                    if (y1 < y2)// y1 below y2
                    {
                        pointA = new Point(x1, y1);
                        pointB = new Point(x2, y2);
                    }
                    else// y2 below y1
                    {
                        pointA = new Point(x2, y2);
                        pointB = new Point(x1, y1);
                    }
                }
                else if (y1 == y2)// || to y-axis
                {
                    if (x1 < x2)// x1 before x2
                    {
                        pointA = new Point(x1, y1);
                        pointB = new Point(x2, y2);
                    }
                    else// x2 before x1
                    {
                        pointA = new Point(x2, y2);
                        pointB = new Point(x1, y1);
                    }
                }
            }
            private int[] GetPrevNextPoint()
            {
                int[] arr = new int[2];
                return arr;
            }
            public int Slope()
            {
                return pointB.xCoordinate - pointA.xCoordinate == 0 ? -1 : 0;
            }
            public bool HasLength()
            {
                return (int)Math.Sqrt(
                    Math.Pow(pointA.xCoordinate - pointB.xCoordinate, 2) +
                    Math.Pow(pointA.yCoordinate - pointB.yCoordinate, 2)
                    ) > 0;
            }
            public bool HasPointOnX(Point point)
            {
                return (
                    point.xCoordinate >= this.pointA.xCoordinate &&
                    point.xCoordinate <= this.pointB.xCoordinate
                );
            }
            public bool HasPointOnY(Point point)
            {
                return (
                    point.yCoordinate >= this.pointA.yCoordinate &&
                    point.yCoordinate <= this.pointB.yCoordinate
                );
            }
            public bool HasPointBetweenXEndpoints(Point point)
            {
                return (
                    point.xCoordinate >= this.pointA.xCoordinate &&
                    point.xCoordinate <= this.pointB.xCoordinate
                );
            }
            public bool HasPointBetweenYEndpoints(Point point)
            {
                return (
                    point.yCoordinate >= this.pointA.yCoordinate &&
                    point.yCoordinate <= this.pointB.yCoordinate
                );
            }
        }
        public string Intersection(int[] seg1, int[] seg2)
        {
            Segment segment1 = new Segment(seg1[0], seg1[1], seg1[2], seg1[3]);
            Segment segment2 = new Segment(seg2[0], seg2[1], seg2[2], seg2[3]);

            if (segment1.Slope() == segment2.Slope())// || to x-axis or y-axis
            {
                if (segment1.Slope() == 0)// || to x-axis
                {
                    if (Point.YDistance(segment1.pointA, segment2.pointA) == 0)// both on same line
                    {
                        if (!segment1.HasLength() && !segment2.HasLength())// point - point case
                        {
                            return Point.XDistance(segment1.pointA, segment2.pointA) == 0 ? "POINT" : "NO";
                        }
                        else if (segment1.HasLength() && !segment2.HasLength())// segment - point case
                        {
                            return segment1.HasPointOnX(segment2.pointA) ? "POINT" : "NO";
                        }
                        else if (!segment1.HasLength() && segment2.HasLength())// point - segment case
                        {
                            return segment2.HasPointOnX(segment1.pointA) ? "POINT" : "NO";
                        }
                        else// segment - segment case
                        {
                            if (segment1.pointA.xCoordinate < segment2.pointA.xCoordinate)// segment 1 is before segemnt 2
                            {
                                if (segment1.pointB.xCoordinate < segment2.pointA.xCoordinate)// no common segments
                                {
                                    return "NO";
                                }
                                else
                                {
                                    return segment1.pointB.xCoordinate == segment2.pointA.xCoordinate ? "POINT" : "SEGMENT";
                                }
                            }
                            else// segment 2 is before segemnt 2
                            {
                                if (segment2.pointB.xCoordinate < segment1.pointA.xCoordinate)// no common segments
                                {
                                    return "NO";
                                }
                                else
                                {
                                    return segment2.pointB.xCoordinate == segment1.pointA.xCoordinate ? "POINT" : "SEGMENT";
                                }
                            }
                        }
                    }
                    else// parallel lines
                    {
                        return "NO";
                    }
                }
                else// || to y-axis
                {
                    if (Point.XDistance(segment1.pointA, segment2.pointA) == 0)// both on same line
                    {
                        if (!segment1.HasLength() && !segment2.HasLength())// point - point case
                        {
                            return Point.YDistance(segment1.pointA, segment2.pointA) == 0 ? "POINT" : "NO";
                        }
                        else if (segment1.HasLength() && !segment2.HasLength())// segment - point case
                        {
                            return segment1.HasPointOnY(segment2.pointA) ? "POINT" : "NO";
                        }
                        else if (!segment1.HasLength() && segment2.HasLength())// point - segment case
                        {
                            return segment2.HasPointOnY(segment1.pointA) ? "POINT" : "NO";
                        }
                        else// segment - segment case
                        {
                            if (segment1.pointA.yCoordinate < segment2.pointA.yCoordinate)// segment 1 is before segemnt 2
                            {
                                if (segment1.pointB.yCoordinate < segment2.pointA.yCoordinate)// no common segments
                                {
                                    return "NO";
                                }
                                else
                                {
                                    return segment1.pointB.yCoordinate == segment2.pointA.yCoordinate ? "POINT" : "SEGMENT";
                                }
                            }
                            else// segment 2 is before segemnt 2
                            {
                                if (segment2.pointB.yCoordinate < segment1.pointA.yCoordinate)// no common segments
                                {
                                    return "NO";
                                }
                                else
                                {
                                    return segment2.pointB.yCoordinate == segment1.pointA.yCoordinate ? "POINT" : "SEGMENT";
                                }
                            }
                        }
                    }
                    else// parallel lines
                    {
                        return "NO";
                    }
                }
            }
            else// intersection possible
            {
                if (segment1.Slope() == -1)// segment1 || to y-axis and segment2 || to x-axis
                {
                    return (
                        segment1.HasPointBetweenYEndpoints(segment2.pointA) &&
                        segment2.HasPointBetweenXEndpoints(segment1.pointA)
                        ? "POINT" : "NO"
                    );
                }
                else// segment1 || to x-axis and segment2 || to y-axis
                {
                    return (
                        segment2.HasPointBetweenYEndpoints(segment1.pointA) &&
                        segment1.HasPointBetweenXEndpoints(segment2.pointA)
                        ? "POINT" : "NO"
                    );
                }
            }
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
