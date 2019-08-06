using System;

namespace StandInLineProblem
{
    class StandInLine
    {
        static private void PrintArr(int[] arr)
        {
            foreach (var x in arr)
            {
                Console.Write(x + ",");
            }
            Console.WriteLine();
        }
        private void InitArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = -1;
            }
        }
        private int PrevBlankSpaceCount(int[] arr, int highPos)
        {
            int blankCount = 0;
            for (int i = 0; i < highPos; ++i)
            {
                if (arr[i] == -1)
                {
                    ++blankCount;
                }
            }
            return blankCount;
        }
        private int[] Reconstruct(int[] left)
        {
            int len = left.Length, soldierBlankSpaceIndex;
            int[] final = new int[len];
            InitArray(ref final);

            for (int soldierIndex = 0; soldierIndex < len; ++soldierIndex)
            {
                soldierBlankSpaceIndex = left[soldierIndex];
                if (final[soldierBlankSpaceIndex] == -1 && PrevBlankSpaceCount(final, soldierBlankSpaceIndex) >= soldierBlankSpaceIndex)
                {
                    final[soldierBlankSpaceIndex] = soldierIndex + 1;
                }
                else
                {
                    for (int indexNew = soldierBlankSpaceIndex; indexNew < len; ++indexNew)
                    {
                        if (final[indexNew] == -1 && PrevBlankSpaceCount(final, indexNew) >= soldierBlankSpaceIndex)
                        {
                            final[indexNew] = soldierIndex + 1;
                            break;
                        }
                    }
                }
            }
            return final;
        }

        #region Testing code Do not change
        public static void Main()
        {
            StandInLine standInLine = new StandInLine();

            // test case 1 -> 4, 2, 1, 3
            PrintArr(standInLine.Reconstruct(new int[] { 2, 1, 1, 0 }));
            // test case 2 -> 1, 2, 3, 4, 5
            PrintArr(standInLine.Reconstruct(new int[] { 0, 0, 0, 0, 0 }));
            // test case 3 -> 6, 5, 4, 3, 2, 1
            PrintArr(standInLine.Reconstruct(new int[] { 5, 4, 3, 2, 1, 0 }));
            // test case 4 -> 6, 2, 3, 4, 7, 5, 1
            PrintArr(standInLine.Reconstruct(new int[] { 6, 1, 1, 1, 2, 0, 0 }));
            // test case 5 -> 2, 4, 3, 1
            PrintArr(standInLine.Reconstruct(new int[] { 3, 0, 1, 0 }));

            Console.ReadLine();
        }
        #endregion
    }
}
