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
        }
        static int Slope(Point A, Point B)
        {
            if ((B.xCoordinate - A.xCoordinate) == 0)
            {
                // parallel to y axis
                return -1;
            }
            else
            {
                // parallel to x axis
                return 0;
            }
        }
        static int XDistance(Point A, Point B)
        {
            return Math.Abs(A.xCoordinate - B.xCoordinate);
        }
        static int YDistance(Point A, Point B)
        {
            return Math.Abs(A.yCoordinate - B.yCoordinate);
        }
        static bool AreSamePoint(Point A, Point B)
        {
            return (A.xCoordinate == B.xCoordinate && A.yCoordinate == B.yCoordinate) ? true : false;
        }
        public string Intersection(int[] seg1, int[] seg2)
        {
            // init segment 1 as (P1,Q1)
            Point P1 = new Point(seg1[0], seg1[1]);
            Point Q1 = new Point(seg1[2], seg1[3]);

            // init segment 2 as (P2,Q2)
            Point P2 = new Point(seg2[0], seg2[1]);
            Point Q2 = new Point(seg2[2], seg2[3]);

            string result = "-";

            if (Slope(P1, Q1) == 0 && Slope(P2, Q2) == 0)
            {
                // seg1 || to x-axis and seg2 || to x-axis
                if (YDistance(P1, P2) != 0)
                {
                    result = "NO";
                }
                else if (
                    (AreSamePoint(P1, P2) && AreSamePoint(Q1, Q2)) &&
                    (XDistance(P1, Q1) > 0 || XDistance(P2, Q2) > 0 || YDistance(P1, Q1) > 0 || XDistance(Q1, Q2) > 0)
                    )
                {
                    result = "SEGMENT";
                }
                else if (AreSamePoint(P1, P2) && AreSamePoint(Q1, Q2))
                {
                    result = "POINT";
                }
                else if (
                    (XDistance(P1, P2) + XDistance(Q1, P2) == XDistance(P1, Q1)) ||
                    (XDistance(P2, P1) + XDistance(Q2, P1) == XDistance(P2, Q2))
                )
                {
                    if (AreSamePoint(P1, P2) || AreSamePoint(Q1, P2))
                    {
                        result = "POINT";
                    }
                    else
                    {
                        result = "SEGMENT";
                    }
                }
                else if (
                    (XDistance(P1, Q2) + XDistance(Q1, Q2) == XDistance(P1, Q1)) ||
                    (XDistance(P2, Q1) + XDistance(Q2, Q1) == XDistance(P2, Q2))
                    )
                {
                    if (AreSamePoint(P1, Q2) || AreSamePoint(Q1, Q2))
                    {
                        result = "POINT";
                    }
                    else
                    {
                        result = "SEGMENT";
                    }
                }
                else
                {
                    result = "NO";
                }
            }
            else if (Slope(P1, Q1) == -1 && Slope(P2, Q2) == -1)
            {
                // seg1 || to y-axis and seg2 || to y-axis
                if (XDistance(P1, P2) != 0)
                {
                    result = "NO";
                }
                else if (
                   (AreSamePoint(P1, P2) && AreSamePoint(Q1, Q2)) &&
                   (XDistance(P1, Q1) > 0 || XDistance(P2, Q2) > 0 || YDistance(P1, Q1) > 0 || XDistance(Q1, Q2) > 0)
                   )
                {
                    result = "SEGMENT";
                }
                else if (AreSamePoint(P1, P2) && AreSamePoint(Q1, Q2))
                {
                    result = "POINT";
                }
                else if (
                    (YDistance(P1, P2) + YDistance(Q1, P2) == YDistance(P1, Q1)) ||
                    (YDistance(P2, P1) + YDistance(Q2, P1) == YDistance(P2, Q2))
                )
                {
                    if (AreSamePoint(P1, P2) || AreSamePoint(Q1, P2))
                    {
                        result = "POINT";
                    }
                    else
                    {
                        result = "SEGMENT";
                    }
                }
                else if (
                    (YDistance(P1, Q2) + YDistance(Q1, Q2) == YDistance(P1, Q1)) ||
                    (YDistance(P2, Q1) + YDistance(Q2, Q1) == YDistance(P2, Q2))
                )
                {
                    if (AreSamePoint(P1, Q2) || AreSamePoint(Q1, Q2))
                    {
                        result = "POINT";
                    }
                    else
                    {
                        result = "SEGMENT";
                    }
                }
                else
                {
                    result = "NO";
                }
            }
            else if (Slope(P1, Q1) == -1 && Slope(P2, Q2) == 0)
            {
                // seg1 || to y-axis and seg2 || to x-axis
                bool S1XBetweenS2X = (
                    (P1.xCoordinate >= P2.xCoordinate && P1.xCoordinate <= Q2.xCoordinate) ||
                    (P1.xCoordinate >= Q2.xCoordinate && P1.xCoordinate <= P2.xCoordinate)
                );
                bool S2YBetweenS1Y = (
                        (P2.yCoordinate >= P1.yCoordinate && P2.yCoordinate <= Q1.yCoordinate) ||
                        (P2.yCoordinate >= Q1.yCoordinate && P2.yCoordinate <= P1.yCoordinate)
                );
                if (S1XBetweenS2X && S2YBetweenS1Y)
                {
                    result = "POINT";
                }
                else
                {
                    result = "NO";
                }
            }
            else
            {
                // seg1 || to x-axis and seg2 || to y-axis
                bool S1YBetweenS2Y = (
                    (P1.yCoordinate >= P2.yCoordinate && P1.yCoordinate <= Q2.yCoordinate) ||
                    (P1.yCoordinate >= Q2.yCoordinate && P1.yCoordinate <= P2.yCoordinate)
                );
                bool S2XBetweenS1X = (
                    (P2.xCoordinate >= P1.xCoordinate && P2.xCoordinate <= Q1.xCoordinate) ||
                    (P2.xCoordinate >= Q1.xCoordinate && P2.xCoordinate <= P1.yCoordinate)
                );
                if (S1YBetweenS2Y && S2XBetweenS1X)
                {
                    result = "POINT";
                }
                else
                {
                    result = "NO";
                }
            }

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
