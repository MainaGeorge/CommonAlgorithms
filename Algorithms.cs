using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonAlgorithms
{
    public static class Algorithms
    {
        public static int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;
            var index = 0;
            var count = 0;
            var length = s.Length;
            while (index < length)
            {
                if (char.IsWhiteSpace(s[index]))
                {
                    while (index < length && char.IsWhiteSpace(s[index]))
                    {
                        index++;
                    }

                    if (index == length)
                        return count;

                    count = 0;
                }
                else
                {
                    count++;
                    index++;
                }
            }

            return count;
        }

        public static int LengthOfLastWordUsingFunctions(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            var count = 0;
            var index = s.Length - 1;
            while (char.IsWhiteSpace(s[index]))
            {
                index--;
            }

            while (index >= 0)
            {
                if (char.IsWhiteSpace(s[index]))
                    break;
                count++;
                index--;
            }

            return count;
        }

        public static int[] SpiralOrderMatrix(int[][] source)
        {
            if (source == null || !source.Any())
                return Enumerable.Empty<int>().ToArray();
            var rowStart = 0;
            var columnStart = 0;
            var elements = source.Length * source[0].Length;
            var rowHeight = source.Length - 1;
            var columnLength = source[0].Length - 1;
            var results = new int[source.Length * source[0].Length];
            var count = 0;
            Console.WriteLine("elements = " + elements);

            while (rowStart <= rowHeight && columnStart <= columnLength)
            {
                for (var topRow = columnStart; topRow <= columnLength; topRow++)
                {
                    Console.WriteLine($"{rowStart} {topRow} --> {source[rowStart][topRow]} {count}");
                    if (count < elements)
                        results[count++] = source[rowStart][topRow];
                }

                rowStart++;

                for (var rightColumnIndex = rowStart; rightColumnIndex <= rowHeight; rightColumnIndex++)
                {
                    Console.WriteLine($"{rightColumnIndex} {columnLength} --> {source[rightColumnIndex][columnLength]} {count}");
                    if (count < elements)
                        results[count++] = source[rightColumnIndex][columnLength];

                }
                columnLength--;



                for (var bottomIndex = columnLength; bottomIndex >= columnStart; bottomIndex--)
                {
                    Console.WriteLine($"{rowHeight} {bottomIndex} --> {source[rowHeight][bottomIndex]} {count}");
                    if (count < elements)
                        results[count++] = source[rowHeight][bottomIndex];

                }
                rowHeight--;



                for (var rightInIndex = rowHeight; rightInIndex >= rowStart; rightInIndex--)
                {
                    Console.WriteLine($"{rightInIndex} {columnStart} --> {source[rightInIndex][columnStart]} {count}");
                    if (count < elements)
                        results[count++] = source[rightInIndex][columnStart];


                }
                columnStart++;



            }

            return results;
        }

        public static bool SearchSortedMatrixForATarget(int[][] source, int target)
        {
            /* given a matrix of size m*n, sorted, every first number of next row is bigger than the last
             of the previous row, return true if matrix contains target else false */
            if (!source.Any())
                return false;

            var maxRowIndex = source.Length - 1;
            var rowIndex = 0;
            var columnIndex = source[0].Length - 1;

            if (target < source[0][0] || target > source[maxRowIndex][columnIndex])
                return false;

            while (rowIndex <= maxRowIndex && columnIndex >= 0)
            {

                if (source[rowIndex][columnIndex] < target)
                    rowIndex++;
                else if (source[rowIndex][columnIndex] > target)
                    columnIndex--;
                else
                    return true;

            }

            return false;

        }

        public static string ZigZagConversion(string toBeConvertedToZigZag, int numberOfRows)
        {
            if (numberOfRows <= 1)
                return toBeConvertedToZigZag;

            var zigzagElements = new StringBuilder[numberOfRows];
            var zigzagIndexCounter = 0;
            var step = 1;
            foreach (var character in toBeConvertedToZigZag)
            {

                zigzagElements[zigzagIndexCounter] ??= new StringBuilder();

                zigzagElements[zigzagIndexCounter].Append(character);

                if (zigzagIndexCounter <= 0)
                    step = 1;
                if (zigzagIndexCounter >= numberOfRows - 1)
                    step = -1;
                zigzagIndexCounter += step;
            }

            var results = new StringBuilder();
            foreach (var element in zigzagElements)
                results.Append(element);

            return results.ToString();
        }

        public static IEnumerable<int> TwoSum(int[] source, int target)
        {
            /* given an array find the indices of 2 numbers in it such that they sum up to the target */
            var elementWithIndex = new Dictionary<int, int>();
            var arr = new int[2];

            for (var index = 0; index < source.Length; index++)
            {
                var missingNumber = target - source[index];
                if (elementWithIndex.ContainsKey(missingNumber))
                {
                    arr[0] = index;
                    arr[1] = elementWithIndex[missingNumber];
                    break;
                }

                else
                    elementWithIndex[source[index]] = index;


            }

            return arr;
        }

        public static IEnumerable<int> TwoSumSortedArray(int[] source, int target)
        {
            /* given an array find the indices of 2 numbers in it such that they sum up to the target
             the array is sorted and it is not a zero based*/
            if (!source.Any())
                return Enumerable.Empty<int>();
            var startingIndex = 0;
            var endingIndex = source.Length - 1;
            var arr = new int[2];

            while (startingIndex < endingIndex)
            {
                if (source[startingIndex] + source[endingIndex] > target)
                    endingIndex--;
                else if (source[startingIndex] + source[endingIndex] < target)
                    startingIndex++;
                else
                {
                    arr[0] = startingIndex + 1;
                    arr[1] = endingIndex + 1;
                    break;
                }
            }

            return arr;
        }
    }
}
