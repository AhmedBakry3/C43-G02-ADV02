using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Session_2_Advanced_c_
{
    internal static class Helper<T> where T : IComparable<T>, IConvertible
    {
        //IsPalindrome Method For Question 2
        public static bool IsPalindrome(List<int> list)
        {
            int left = 0;
            int right = list.Count - 1;

            while (left < right)
            {
                if (list[left] != list[right])
                {
                    return false; // Not a palindrome
                }
                left++;
                right--;
            }
            return true; // It's a palindrome
        }


        //ReverseQueue Method For Question 3
        public static Queue<T> ReverseQueue(Queue<T> queue)
        {
            Stack<T> stack = new Stack<T>();

            while (queue.Count > 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue;
        }

        // IsBalanced Method For Question 4

        public static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                // If it's an opening parenthesis, push to the stack
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                // If it's a closing parenthesis, check if it matches the top of the stack
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (stack.Count == 0 ||
                     (ch == ')' && stack.Peek() != '(') ||
                     (ch == '}' && stack.Peek() != '{') ||
                     (ch == ']' && stack.Peek() != '['))
                    {
                        return false;
                    }
                    stack.Pop();  // Pop the opening parenthesis
                }
            }
            // If the stack is empty, all parentheses are matched
            return stack.Count == 0;
        }

        //  RemoveDuplicates Method For Question 5
          public static T[] RemoveDuplicates(T[] array)
        {
            List<T> result = new List<T>();

            for (int i = 0; i < array.Length; i++)
            {
                bool isDuplicate = false;

                // Check if the current element already exists in the result list
                for (int j = 0; j < result.Count; j++)
                {
                    if (EqualityComparer<T>.Default.Equals(array[i], result[j]))
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                // If it's not a duplicate, add it to the result list
                if (!isDuplicate)
                {
                    result.Add(array[i]);
                }
            }

            return result.ToArray();
        }

        //RemoveOddNumbers Method For Question 6
        public static T[] RemoveOddNumbers(List<T> list)
        {
            List<T> evenNumbersList = new List<T>();

            foreach (T item in list)
            {
                if (Convert.ToInt64(item) % 2 == 0) // Check for even numbers
                {
                    evenNumbersList.Add(item);
                }
            }
            return evenNumbersList.ToArray(); // Return as array
        }

        // PushIntegersOntoStack Method to push a series of integers onto the stack (For Question 8)
        public static void PushIntegersOntoStack(Stack<int> stack)
        {
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Push(40);
            stack.Push(50);

            Console.WriteLine("Integers have been pushed onto the stack.");
        }

        // SearchTargetInStack Method For Question 8
        public static T[] SearchTargetInStack(Stack<T> stack, T target)
        {
            List<T> checkedElements = new List<T>();
            int count = 0;

            Stack<T> tempStack = new Stack<T>();

            while (stack.Count > 0)
            {
                T current = stack.Pop();
                checkedElements.Add(current);
                count++;

                if (current.Equals(target))
                {
                    Console.WriteLine($"Target was found successfully and the count = {count}");

                    while (tempStack.Count > 0)
                    {
                        stack.Push(tempStack.Pop());
                    }
                    return checkedElements.ToArray();
                }
                tempStack.Push(current);
            }
            Console.WriteLine("Target was not found");

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return checkedElements.ToArray();
        }

        //FindIntersection Function For Question 9
        public static List<int> FindIntersection(List<int> list1, List<int> list2)
        {
            List<int> intersectionList = new List<int>();

            foreach (int num in list1)
            {
                if (list2.Contains(num)) 
                {
                    intersectionList.Add(num); 
                    list2.Remove(num);  
                }
            }

            return intersectionList;
        }

        //FindSublistWithTargetSum Method For Question 10
        public static T[] FindSublistWithTargetSum(List<T> list, T targetSum)
        {
            int start = 0;
            double currentSum = 0;

            for (int end = 0; end < list.Count; end++)
            {
                currentSum += Convert.ToDouble(list[end]);

                while (currentSum > Convert.ToDouble(targetSum) && start <= end)
                {
                    currentSum -= Convert.ToDouble(list[start]);
                    start++;
                }

                if (currentSum == Convert.ToDouble(targetSum))
                {
                    T[] result = new T[end - start + 1];
                    for (int i = start; i <= end; i++)
                    {
                        result[i - start] = list[i];
                    }
                    return result;
                }
            }

            return new T[0];
        }


        //ReverseFirstKElements Method For Question 11
        public static void ReverseFirstKElements(Queue<int> queue, int K)
        {
            if (K > queue.Count)
            {
                Console.WriteLine("K cannot be greater than the size of the queue ");
                return;
            }

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < K; i++)
            {
                stack.Push(queue.Dequeue());
            }

            int remainingElements = queue.Count; 

            List<int> remainingList = new List<int>();

            for (int i = 0; i < remainingElements; i++)
            {
                remainingList.Add(queue.Dequeue());
            }

            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }

            foreach (int item in remainingList)
            {
                queue.Enqueue(item);
            }
        }
    }
}
