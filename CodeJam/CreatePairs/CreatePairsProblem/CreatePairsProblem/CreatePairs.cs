using System;

namespace CreatePairsProblem
{
    class CreatePairs
    {
        int MaximalSum(int[] data)
        {
            int sum = 0;
            //Your code goes here
            if (data.Length == 0)
            {
                Console.WriteLine("Enter More than one Value");
            }
            return sum;
        }

        #region Testing code Do not change
        public static void Main()
        {
            CreatePairs createPairs = new CreatePairs();

            // test case 1 -> 27
            Console.WriteLine(createPairs.MaximalSum(new int[] { 0, 1, 2, 4, 3, 5 }));
            // test case 2 -> 6
            Console.WriteLine(createPairs.MaximalSum(new int[] { -1, 1, 2, 3 }));
            // test case 3 -> -1
            Console.WriteLine(createPairs.MaximalSum(new int[] { -1 }));
            // test case 4 -> 1
            Console.WriteLine(createPairs.MaximalSum(new int[] { -1, 0, 1 }));
            // test case 5 -> 2
            Console.WriteLine(createPairs.MaximalSum(new int[] { 1, 1 }));

            Console.ReadLine();
        }
        #endregion
    }
}
