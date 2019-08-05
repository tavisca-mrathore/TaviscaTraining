using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class NoPointSegment
    {
        class Point
        {
            short xCoordinate, yCoordinate;
            Point(int x, int y)
            {
                xCoordinate = x;
                yCoordinate = y;
            }
        }
        static short Slope(Point A, Point B)
        {
            short slope;
            if ((B.xCordinate - A.xCordinate) == 0)
            {
                // indicates infinite slope
                return 10;
            }
            else
            {
                return ((B.yCoordinate - A.yCoordinate) / (B.xCoordinate - A.xCoordinate));
            }
        }
        static private string IsParallel()
        {
            return "PARALLEL";
        }
        public string Intersection(int[] seg1, int[] seg2)
        {
            // init segment1 as (P1,Q1)
            Point P1 = new Point(seg1[0], seg1[1]);
            Point Q1 = new Point(seg1[2], seg1[3]);

            // init segment 2 as (P2,Q2)
            Point P2 = new Point(seg2[0], seg2[1]);
            Point Q2 = new Point(seg2[2], seg2[3]);

            string result = "";
            result = IsParallel();
            return result;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            NoPointSegment solver = new NoPointSegment();
            // test case 1
            Console.WriteLine(solver.Intersection(new { 0, 0, 0, 1 }, new { 1, 0, 1, 1 }));
            // test case 2
            Console.WriteLine(solver.Intersection(new { 0, 0, 0, 1 }, new { 0, 1, 0, 2 }));
            // test case 3
            Console.WriteLine(solver.Intersection(new { 0, -1, 0, 1 }, new { -1, 0, 1, 0 }));
            // test case 4
            Console.WriteLine(solver.Intersection(new { 0, 0, 2, 0 }, new { 1, 0, 10, 0 }));
            // test case 5
            Console.WriteLine(solver.Intersection(new { 5, 5, 5, 5 }, new { 6, 6, 6, 6 }));
            // test case 6
            Console.WriteLine(solver.Intersection(new { 10, 0, -10, 0 }, new { 5, 0, -5, 0 }));
        }
        #endregion
    }
}