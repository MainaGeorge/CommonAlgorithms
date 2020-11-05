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
            /*given a string that could have spaces at the beginning, middle or end, find the length of the last
                      word. if the string is just " " return 0;*/


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
                        index++;


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
                index--;

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
            /* given a mxn matrix, traverse it in a spiral way i.e toprow, rightcolumn, bottomrow leftcolumn and repeat
             until all the numbers have been covered.*/
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
                    Console.WriteLine(
                        $"{rightColumnIndex} {columnLength} --> {source[rightColumnIndex][columnLength]} {count}");
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
            /* given an array find the indices of 2 numbers in it such that they sum up to the target.
             the array is sorted and it is not a zero based array */
            var arr = new int[2];

            if (!source.Any())
                return arr;

            var startingIndex = 0;
            var endingIndex = source.Length - 1;

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

        public static ListNode ReverseLinkedList(ListNode headNode)
        {
            /*  Reverse a singly linked list.
                Example: Input: 1->2->3->4->5->NULL Output: 5->4->3->2->1->NULL
            */
            ListNode previous = null;
            while (headNode != null)
            {
                var next = headNode.Next;
                headNode.Next = previous;

                previous = headNode;
                headNode = next;
            }

            return previous;
        }

        public static ListNode AddTwoNumbersAsLists(ListNode first, ListNode second)
        {

            /*
             * You are given two non-empty linked lists representing two non-negative integers.
             * The digits are stored in reverse order, and each of their nodes contains a single digit.
             * Add the two numbers and return the sum as a linked list.
            */
            switch (first)
            {
                case null when second == null:
                    return null;
                case null:
                    return second;
            }

            if (second == null)
                return first;
            var carry = 0;
            var head = new ListNode(0);
            var tail = head;
            while (first != null && second != null)
            {
                var sum = first.Value + second.Value + carry;
                carry = sum / 10;
                tail.Next = new ListNode(sum % 10);
                tail = tail.Next;
                first = first.Next;
                second = second.Next;
            }

            while (first != null)
            {
                var sum = first.Value + carry;
                carry = sum / 10;
                tail.Next = new ListNode(sum % 10);
                tail = tail.Next;
                first = first.Next;
            }

            while (second != null)
            {
                var sum = second.Value + carry;
                carry = sum / 10;
                tail.Next = new ListNode(sum % 10);
                tail = tail.Next;
                second = second.Next;
            }

            if (carry != 0)
            {
                tail.Next = new ListNode(carry);
            }

            return ReverseLinkedList(head.Next);
        }

        public static ListNode AddTwoNumbersAsListsBetter(ListNode first, ListNode second)
        {
            return first switch
            {
                null when second == null => null,
                null => second,
                _ => second == null ? first : ReverseLinkedList(CombineTwoNodes(first, second))
            };
        }

        private static ListNode CombineTwoNodes(ListNode first, ListNode second)
        {
            ListNode head = null;
            var carry = 0;
            while (first != null && second != null)
            {
                var sum = first.Value + second.Value + carry;
                carry = sum / 10;
                var newNode = new ListNode(sum % 10, head);
                head = newNode;
                first = first.Next;
                second = second.Next;
            }

            if (first == null && second == null && carry != 0)
            {
                var newNode = new ListNode(carry, head);
                head = newNode;
            }
            else if (first != null)
                head = AddRemainingElements(head, first, carry);
            else if (second != null)
                head = AddRemainingElements(head, second, carry);

            return head;
        }

        private static ListNode AddRemainingElements(ListNode currentHead, ListNode source, int carry)
        {
            while (source != null)
            {
                var sum = source.Value + carry;
                carry = sum / 10;
                var newNode = new ListNode(sum % 10, currentHead);
                currentHead = newNode;
                source = source.Next;
            }

            if (carry == 0) return currentHead;

            {
                var newNode = new ListNode(carry, currentHead);
                currentHead = newNode;
            }

            return currentHead;
        }

        public static ListNode Partition(ListNode node, int partitioningValue)
        {
            /*
                Given a linked list and a value x, partition it such that all nodes less than x come before
                nodes greater than or equal to x.
                You should preserve the original relative order of the nodes in each of the two partitions.
                Example:
                Input: head = 1->4->3->2->5->2, x = 3
                Output: 1->2->2->4->3->5
        */
            ListNode leftHead = null, leftTail = null, rightHead = null, rightTail = null;
            while (node != null)
            {
                var nextNode = node.Next;
                node.Next = null;
                if (node.Value < partitioningValue)
                {
                    if (leftHead == null)
                    {
                        leftHead = node;
                        leftTail = node;
                    }
                    else
                    {
                        leftTail.Next = node;
                        leftTail = leftTail.Next;
                    }
                }
                else
                {
                    if (rightHead == null)
                    {
                        rightHead = node;
                        rightTail = node;
                    }
                    else
                    {
                        rightTail.Next = node;
                        rightTail = rightTail.Next;
                    }
                }

                node = nextNode;
            }

            if (leftHead != null && rightHead != null)
            {
                leftTail.Next = rightHead;
                return leftHead;
            }
            else if (leftHead == null && rightHead == null)
            {
                return null;
            }
            else if (rightHead == null)
            {
                return leftHead;
            }

            return rightHead;
        }

        public static bool DoesTheNodeContainCycle(ListNode node)
        {
            if (node == null)
                return false;
            var rabbit = node;
            var tortoise = node;
            while (rabbit?.Next != null)
            {
                rabbit = rabbit.Next.Next;
                tortoise = tortoise.Next;

                if (rabbit == tortoise)
                    return true;
            }

            return false;
        }

        public static ListNode GetTheNodeWhereCycleBegins(ListNode node)
        {
            if (node == null)
                return null;
            var rabbit = node;
            var meetingPoint = GetNodeWherePointersMeet(node);
            if (meetingPoint == null)
                return null;
            while (rabbit != meetingPoint)
            {
                rabbit = rabbit.Next;
                meetingPoint = meetingPoint.Next;
            }

            return meetingPoint;
        }

        private static ListNode GetNodeWherePointersMeet(ListNode node)
        {
            var rabbit = node;
            var tortoise = node;
            while (rabbit?.Next != null)
            {
                rabbit = rabbit.Next.Next;
                tortoise = tortoise.Next;
                if (tortoise == rabbit)
                    return rabbit;
            }

            return null;
        }

        public static bool BalancedParenthesis(string containingBrackets)
        {
            var matchingBrackets = new Dictionary<char, char>()
            {
                ['}'] = '{',
                [')'] = '(',
                [']'] = '['

            };
            var characterStack = new Stack<char>();

            foreach (var character in containingBrackets)
            {
                if (IsAnOpeningParenthesis(character))
                    characterStack.Push(character);
                else if (IsAClosingParenthesis(character))
                {
                    if (StackIsEmpty(characterStack))
                        return false;
                    if (matchingBrackets[character] != characterStack.Pop())
                        return false;
                }

            }

            return StackIsEmpty(characterStack);
        }

        private static bool IsAnOpeningParenthesis(char ch)
        {
            return ch == '(' || ch == '{' || ch == '[';
        }

        private static bool IsAClosingParenthesis(char ch)
        {
            return ch == ')' || ch == '}' || ch == ']';

        }

        private static bool StackIsEmpty(IEnumerable<char> stack)
        {
            return !stack.Any();
        }

        public static int EvalRPN(string[] tokens)
        {
            /*
                Evaluate the value of an arithmetic expression in Reverse Polish Notation.
                Valid operators are +, -, *, /. Each operand may be an integer or another expression.
                    Note:
                        Division between two integers should truncate toward zero.
                        The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.

                            Input: ["2", "1", "+", "3", "*"]
                            Output: 9
                            Explanation: ((2 + 1) * 3) = 9

                            Input: ["4", "13", "5", "/", "+"]
                            Output: 6
                            Explanation: (4 + (13 / 5)) = 6
            */
            var numberStack = new Stack<int>();
            foreach (var token in tokens)
            {
                if (!IsOperator(token))
                    numberStack.Push(int.Parse(token));
                else
                {
                    var firstOperand = numberStack.Pop();
                    var secondOperand = numberStack.Pop();

                    numberStack.Push(PerformCalculation(firstOperand, secondOperand, token));
                }

            }

            return numberStack.Peek();
        }

        private static int PerformCalculation(int firstOperand, int secondOperand, string sign)
        {
            return sign switch
            {
                "+" => firstOperand + secondOperand,
                "-" => secondOperand - firstOperand,
                "*" => firstOperand * secondOperand,
                "/" => secondOperand / firstOperand,
                _ => throw new InvalidOperationException()
            };
        }

        private static bool IsOperator(string ch)
        {
            return ch == "*" || ch == "/" || ch == "+" || ch == "-";
        }

        public static bool IsPalindrome(string toTest)
        {
            var startPointer = 0;
            var endPointer = toTest.Length - 1;

            while (startPointer <= endPointer)
            {
                while (startPointer < endPointer && !char.IsLetterOrDigit(toTest[startPointer]))
                    startPointer++;

                while (startPointer < endPointer && !char.IsLetterOrDigit(toTest[endPointer]))
                    endPointer--;

                if (char.ToLower(toTest[startPointer]) != char.ToLower(toTest[endPointer]))
                    return false;

                startPointer++;
                endPointer--;
            }

            return true;
        }

        public static bool IsValidPalindrome(string toTest)
        {
            /*
             Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.

                    Example 1:
                    Input: "aba"
                    Output: True
                    Example 2:
                    Input: "abca"
                    Output: True
                    Explanation: You could delete the character 'c'.
             */
            var startPointer = 0;
            var endPointer = toTest.Length - 1;

            while (startPointer <= endPointer)
            {
                if (toTest[startPointer] != toTest[endPointer])
                    return (CheckPalindromeSubstring(toTest, startPointer, endPointer - 1))
                           || CheckPalindromeSubstring(toTest, startPointer + 1, endPointer);

                startPointer++;
                endPointer--;
            }

            return true;
        }

        private static bool CheckPalindromeSubstring(string toTest, int startPointer, int endPointer)
        {

            while (startPointer <= endPointer)
            {
                if (toTest[startPointer] != toTest[endPointer])
                    return false;
                startPointer++;
                endPointer--;
            }

            return true;
        }

        public static int FindEvenIndex(int[] arr)
        {
            var sumToTheRight = arr.Sum();

            var sumToTheLeft = 0;
            for (var index = 0; index < arr.Length; index++)
            {
                sumToTheRight -= arr[index];

                if (sumToTheRight == sumToTheLeft)
                    return index;

                sumToTheLeft += arr[index];
            }

            return -1;
        }

        public static int FindEvenIndexUsingLinq(int[] arr)
        {
            for (var index = 0; index < arr.Length; index++)
                if (arr.Take(index).Sum() == arr.Skip(index + 1).Sum())
                    return index;
            return -1;
        }

        public static string RemoveDuplicates(string S)
        {
            /*
             * Given a string S of lowercase letters, a duplicate removal consists of choosing two adjacent and equal letters,
             * and removing them.We repeatedly make duplicate removals on S until we no longer can.
                Return the final string after all such duplicate removals have been made.  It is guaranteed the answer is unique.
            Input: "abbaca"
            Output: "ca"
            Explanation: 
            For example, in "abbaca" we could remove "bb" since the letters are adjacent and equal, and this is the only possible move.
            The result of this move is that the string is "aaca", of which only "aa" is possible, so the final string is "ca".
            */
            var stack = new Stack<char>();
            var result = new StringBuilder();
            foreach (var character in S)
            {
                if (StackIsEmpty(stack) || character != stack.Peek())
                    stack.Push(character);
                else if (character == stack.Peek())
                    stack.Pop();
            }

            while (!StackIsEmpty(stack))
                result.Append(stack.Pop());

            return new string((result.ToString()).Reverse().ToArray());
        }

        public static string RemoveDuplicatesUsingPointer(string S)
        {
            var topLetterPointer = -1;
            var result = new StringBuilder();

            foreach (var character in S)
            {
                if (topLetterPointer == -1 || result[topLetterPointer] != character)
                {
                    result.Append(character);
                    topLetterPointer++;
                }
                else
                {
                    result.Remove(topLetterPointer, 1);
                    topLetterPointer--;
                }
            }

            return result.ToString();
        }

    }
}



