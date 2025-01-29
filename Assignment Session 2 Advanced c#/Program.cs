using System;

namespace Assignment_Session_2_Advanced_c_
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region 1. Given an array  consists of  numbers with size N and number of queries, in each query you will be given an integer X, and you should print how many numbers in array that is greater than  X.
            //Ex:
            //Input
            //3 3      //Size of array , number of queries
            //11 5 3    //Array 
            //1         //Query1
            //5        //Query2
            //13      //Query 3
            //Output
            //3     //11,5,3
            //1  //11
            //0


            int ArraySize = 3; // Size of array
            int NumberOfQueries = 3; // Number of queries
            List<int> list = new List<int> { 11, 5, 3 }; // List elements
            List<int> queries = new List<int> { 1, 5, 13 }; // Queries

            list.Sort();

            for (int i = 0; i < NumberOfQueries; i++)
            {
                int X = queries[i];

                // Use binary search to find the count of numbers greater than X
                int index = list.BinarySearch(X);

                // If X is not found, BinarySearch returns a negative number
                if (index < 0)
                {
                    index = ~index; // Bitwise complement to get the insertion point
                }
                else
                {
                    // If X is found, move to the last occurrence of X
                    while (index < ArraySize && list[index] == X)
                    {
                        index++;
                    }
                }

                // Count of numbers greater than X
                int count = ArraySize - index;
                Console.WriteLine(count);
            }


            #endregion


            #region 2. Given a number N and an array of N numbers. Determine if it's palindrome or not.
            //Ex:
            //Input:
            //5
            //1 3 2 3 1
            //Output:
            //YES

            Console.WriteLine("Is your array a palindrome or not?");

            // Define the list
            List<int> numbers = new List<int> { 1, 3, 2, 3, 1 };

            // Check if it's a palindrome
            if (Helper<int>.IsPalindrome(numbers))
            {
                Console.WriteLine("Yes , it's a palindrome");
            }
            else
            {
                Console.WriteLine("No , it's not a palindrome");
            }

            #endregion

            #region 3. Given a Queue, implement a function to reverse the elements of a queue using a stack.

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Console.WriteLine($"Original Queue:");
            foreach (int item in queue)
                Console.Write($"{item} ");

            queue = Helper<int>.ReverseQueue(queue);

            Console.WriteLine();
            Console.WriteLine("Reversed Queue: ");
            foreach (int item in queue)
                Console.Write($"{item} ");


            #endregion

            #region 4. Given a Stack, implement a function to check if a string of parentheses is balanced using a stack.
            //Ex:
            //Input:
            //    [()] { }
            //Output:
            //    Balanced


            if (Helper<string>.IsBalanced("[()] {}"))
            {
                Console.WriteLine("Balanced");
            }
            else
            {
                Console.WriteLine("Not Balanced");
            }

            #endregion

            #region 5. Given an array, implement a function to remove duplicate elements from an array.

            int[] numbers = { 1, 2, 2, 3, 4, 4, 5 };
            int[] uniqueNumbers = Helper<int>.RemoveDuplicates(numbers);
            foreach (int item in uniqueNumbers)
                Console.Write($"{item} "); // Output: 1, 2, 3, 4, 5
            #endregion

            #region 6. Given an array list , implement a function to remove all odd numbers from it.

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] evennumbers = Helper<int>.RemoveOddNumbers(numbers);
            Console.WriteLine("List after removing odd numbers:");
            foreach (int item in evennumbers)
                Console.Write($"{item} "); //2 4 6 8 10
            #endregion

            #region 7. Implement a queue that can hold different data types. 
            ///And insert the following data:
            ///queue.Enqueue(1)
            ///queue.Enqueue(“Apple”)
            ///queue.Enqueue(5.28)

            Queue<object> queue = new Queue<object>();

            queue.Enqueue(1);           // Integer
            queue.Enqueue("Apple");     // String
            queue.Enqueue(5.28);        // Double

            Console.WriteLine("Queue contents:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            #endregion


            #region 8. Create a function that pushes a series of integers onto a stack. Then, search for a target integer in the stack. If the target is found, print a message indicating that the target was found how many elements were checked before finding the target (“Target was found successfully and the count = 5”). If the target is not found, print a message indicating that the target was not found(“Target was not found”).
            //Note: take the target as input from the user

            Stack<int> stack = new Stack<int>();
            Helper<int>.PushIntegersOntoStack(stack);

            // Take target as input from the user
            int target;
            bool isParsed;

            do
            {
                Console.Write("Enter the target integer to search for: ");

                isParsed = int.TryParse(Console.ReadLine(), out target);

                Console.WriteLine("Invalid input. Please enter a valid integer");

            } while (!isParsed);

            int[] checkedElements = Helper<int>.SearchTargetInStack(stack, target);

            // Print the checked elements
            Console.WriteLine("Checked elements:");
            foreach (int element in checkedElements)
            {
                Console.Write($"{element} "); //Target was found successfully and the count = 5
                                              //Checked elements: 50 40 30 20 10
            }

            #endregion


            #region 9. Given two arrays, find their intersection. Each element in the result should appear as many times as it shows in both arrays.
            //Ex : 
            //Input :
            //5 , 3
            //[1,2,3,4,4] , [10,4,4]
            //Output : 
            //[4,4]

            List<int> list1 = new List<int> { 1, 2, 3, 4, 4 };
            List<int> list2 = new List<int> { 10, 4, 4 };

            List<int> intersection = Helper<int>.FindIntersection(list1, list2);

            Console.WriteLine("Intersection of lists:");
            foreach (int num in intersection)
            {
                Console.Write($"{num} ");  //Intersection of lists:
                                           //4 4
            }


            #endregion

            #region  10. Given an ArrayList of integers and a target sum, find if there is a contiguous sub list that sums up to the target.
            //Ex:
            //Input:
            //[1, 2, 3, 7, 5]
            //12
            //Output:
            //[2, 3, 7]


            List<int> list = new List<int> { 1, 2, 3, 7, 5 };
            int targetSum = 12;

            // Find the contiguous sublist with the target sum
            int[] result = Helper<int>.FindSublistWithTargetSum(list, targetSum);

            // Print the result
            if (result.Length > 0)
            {
                Console.WriteLine($"Contiguous sublist that sums to {targetSum} : ");
                foreach (int item in result)
                {
                    Console.Write($"{item} ");
                    //Contiguous sublist that sums to 12 :
                    //2 3 7
                }
            }
            else
            {
                Console.WriteLine("No contiguous sublist found.");
            }
            #endregion

            #region 11. Given a queue reverse first K elements of a queue, keeping the remaining elements in the same order 
            //Ex:
            //Input:
            //[1, 2, 3, 4, 5]
            //K = 3
            //Output:
            //[3, 2, 1, 4, 5]

            Queue<int> queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });
            int K = 3;

            Helper<int>.ReverseFirstKElements(queue, K);

            Console.WriteLine($"Contiguous sublist that sums to {K} elements: ");
            foreach (int item in queue)
            {
                Console.Write($"{item} "); //Contiguous sublist that sums to 3 elements: 
                                           //3 2 1 4 5
            }

            #endregion
        }
    }
}
