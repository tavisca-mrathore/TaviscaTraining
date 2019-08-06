using System;

namespace TriFibonacciProblem
{
    class TriFibonacci
    {
        private bool ValidateFibonacciSequence(int[] test)
        {
            for (int index = 3; index < test.Length; ++index)
            {
                if (test[index - 1] + test[index - 2] + test[index - 3] != test[index])
                {
                    return false;
                }
            }
            return true;
        }
        private int Complete(int[] test)
        {
            int posIndex = Array.IndexOf(test, -1), result = -1;
            if (posIndex > 2)
            {
                result = test[posIndex - 1] + test[posIndex - 2] + test[posIndex - 3];
                test[posIndex] = result;
                return result > 0 && ValidateFibonacciSequence(test) ? result : -1;
            }
            else if (posIndex == 0)
            {
                result = test[3] - test[1] - test[2];
                test[0] = result;
                return result > 0 && ValidateFibonacciSequence(test) ? result : -1;
            }
            else if (posIndex == 1)
            {
                result = test[3] - test[0] - test[2];
                test[1] = result;
                return result > 0 && ValidateFibonacciSequence(test) ? result : -1;
            }
            else if (posIndex == 2)
            {
                result = test[3] - test[0] - test[1];
                test[2] = result;
                return result > 0 && ValidateFibonacciSequence(test) ? result : -1;
            }
            return -1;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            TriFibonacci triFibonacci = new TriFibonacci();
            // test case 1 -> 6
            Console.WriteLine(triFibonacci.Complete(new int[] { 1, 2, 3, -1 }));
            // test case 2 -> 110
            Console.WriteLine(triFibonacci.Complete(new int[] { 10, 20, 30, 60, -1, 200 }));
            // test case 3 -> -1
            Console.WriteLine(triFibonacci.Complete(new int[] { 1, 2, 3, 5, -1 }));
            // test case 4 -> -1
            Console.WriteLine(triFibonacci.Complete(new int[] { 1, 1, -1, 2, 3 }));
            // test case 5 -> 999985
            Console.WriteLine(triFibonacci.Complete(new int[] { -1, 7, 8, 1000000 }));
            // test case 6 -> -1
            Console.WriteLine(triFibonacci.Complete(new int[]
                { 7, 9, 2, 18, 29, 49, 96, 174, 319, 589, 1082, 1990, 3661, 6733, 12384, -1, 41895, 77057, 141729 }
            ));

            Console.ReadLine();
        }
        #endregion
    }
}
