using System;

namespace TestContest
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 9, 14, 27, 27, 14, 27, 14, 14, 27, 37, 14, 9, 37, 14, 21, 27, 4, 37, 14, 14, 4 };
            int[] pos = { 0 };

            int[] result = BuildArray(arr, pos, arr.Length);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }

            Console.WriteLine();
        }

        static int CompareArray(int[] aarr, int[] barr)
        {
            for (int i = 0; i < aarr.Length; i++)
            {
                if (aarr[i] != barr[i])
                {
                    return aarr[i] - barr[i] > 0 ? 1 : -1;
                }
            }

            return 0;
        }

        static bool InArray(int[] arr, int d)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (d == arr[i])
                {
                    return true;
                }
            }
            return false;
        }

        static int[] BuildArray(int[] arr, int[] pos, int total)
        {
            int[] resultArray = new int[total];
            int[] actualArray;
            int resultTotal = 0;

            for (int i = 0; i < pos.Length; i++)
            {
                resultArray[resultTotal++] = arr[pos[i]];
            }

            for (int i = pos[pos.Length - 1] + 1; i < arr.Length && resultTotal < total; i++)
            {
                if (!InArray(resultArray, arr[i]))
                {
                    resultArray[resultTotal++] = arr[i];
                }
            }

            actualArray = new int[resultTotal];

            for (int i = 0; i < resultTotal; i++)
            {
                actualArray[i] = resultArray[i];
            }

            return actualArray;
        }

        static bool FindFirstMin(int[] arr, int si, int cmin, ref int index)
        {
            for (int i = si; i < arr.Length; i++)
            {
                if (arr[i] < cmin)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }
    }
}
