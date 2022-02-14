/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

//using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        /*
         Learning: Different types of time complexities in programming.
        Recommendations: Debugging knowledge to find our the bug in the code even if the code is written accourding to O(log n).
         */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int min = 0; // making min value is 0
                int max = nums.Length - 1; // max value to length -1
                int mid = 0; // initializing mid value as 0
                while (min < max) // starting a while to verify min and max values.
                {
                    mid = (min + max) / 2; // finding the mid index
                    if (target == nums[mid]) // all the conditional loops below are checking the target is equal to index, less than or greater than to perform the actions.
                    {
                        //++mid;
                        break;
                    }

                    else if (target < nums[mid])
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }

                    if (min == max)
                    {
                        mid = nums.Length;
                        return mid;
                    }
                }
                return mid; // returing the value index.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        /*
        Learning: Building logic using flowchart.
       Recommendations: Debugging knowledge to find our the bug in the code. Concepts of Arrays and its inbuilt functions. Concepts of strings is a msut.
        */
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                paragraph = paragraph.ToLower(); // this statement changes the string to lower case

                paragraph = paragraph.Replace('!', ' '); // below parts of code is to remove the special characters from the string.
                paragraph = paragraph.Replace('?', ' ');
                paragraph = paragraph.Replace('\'', ' ');
                paragraph = paragraph.Replace(',', ' ');
                paragraph = paragraph.Replace(';', ' ');
                paragraph = paragraph.Replace('.', ' ');


                string[] new_paragraph = paragraph.Split(' '); // splitting the paragraph string to string array.



                int[] count = new int[new_paragraph.Length]; // this variable is count the repetitive strings.

                for (int i = 0; i < count.Length; i++) // initialising the count array to zero
                {
                    count[i] = 0;
                }

                for (int i = 0; i < new_paragraph.Length; i++) // the below loop counts the string values and stores in the count array with the same index number
                {
                    for (int j = 0; j < new_paragraph.Length; j++)
                    {
                        if (new_paragraph[i] == new_paragraph[j])
                        {
                            count[i]++;
                        }
                    }
                }


                int maxvalue = 0; // this variable is to store the max value
                int maxindex = 0; // this variable is to get the index of the maxvalue
                int[] countsorted = new int[count.Length]; // to sort the count array

                Array.Copy(count, countsorted, count.Length);

                Array.Sort(countsorted);

                countsorted = countsorted.Distinct().ToArray(); // to remove the duplicates in the cosrted count array.

                for (int i = countsorted.Length; i > 0; i--) // this loop is to check the most repeated word in the paragraph and verify if it is present in the banned words. If it is not present, it returns the word
                {
                    maxvalue = countsorted[i - 1];
                    maxindex = Array.IndexOf(count, maxvalue);

                    if (!banned.Contains(new_paragraph[maxindex]))
                    {
                        return new_paragraph[maxindex];
                    }

                }

                return "";

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        /*
       Learning: time complexity of O(n).
      Recommendations: Arrays and loops concepts.
       */
        public static int FindLucky(int[] arr)
        {
            try
            {
                int[] m = new int[501]; // declaring a new array to store element of arr in index of m

                for (int i = 0; i < arr.Length; i++) // this loop is for sending the element of arr to index of m
                {
                    ++m[arr[i]];
                }

                for (int n = arr.Length; n > 0; --n) // this loop is for comparing the index number and value in that index. Returing the value if the condition is satisified.
                {
                    if (n == m[n])
                        return n;
                }
                return -1;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */
        /*
       Learning: To clearly understand what is the problem statement so as to build the logic accordingly.
      Recommendations: Arrays and loops concepts.
       */
        public static string GetHint(string secret, string guess)
        {
            try
            {
                int countbull = 0; // variable to count the bulls
                int countcow = 0; // variable to count the cows
                int[] arr1 = new int[10]; // 2 arrays to store the secret and guess as an array's
                int[] arr2 = new int[10];

                for (int i = 0; i < secret.Length; i++) // loop to verify the each and every char of secret and guess, if yes increment the bull count
                {
                    char c1 = secret[i];
                    char c2 = guess[i];

                    if (c1 == c2)
                        countbull++;
                    else
                    {
                        arr1[c1 - '0']++;
                        arr2[c2 - '0']++;
                    }
                }

                for (int i = 0; i < 10; i++) // loop to count the cows.
                {
                    countcow += Math.Min(arr1[i], arr2[i]);
                }

                return countbull + "A" + countcow + "B"; // returning the end value
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        /*
      Learning: concepts of lists and difference between lists and arrays.
     Recommendations: Arrays, loops and lists concepts..
      */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int[] final = new int[26]; // variable to store the width.

                for (int i = 0; i < s.Length; i++) // this loop is to store the occurance of letters count.
                {
                    final[s[i] - 'a'] = i;
                }

                int j = 0, anchor = 0; // anchor and J are the start and end of the current partition.
                List<int> ans = new List<int>();

                for (int i = 0; i < s.Length; i++) // this loop is to divide the string and store it in ans as integers
                {
                    j = Math.Max(j, final[s[i] - 'a']);
                    if (i == j)
                    {
                        ans.Add(i - anchor + 1);
                        anchor = i + 1;
                    }
                }

                return ans; // returning the ans
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        /*
     Learning: concepts of lists and difference between lists and arrays.
    Recommendations: Arrays, loops and lists concepts..
     */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int width = 0; // declared 2 variables for width and lines
                int lines = 1;

                foreach (char c in s.ToCharArray()) // looping on every character of S to get the values of lines and width
                {
                    int wid = widths[c - 'a'];
                    width += wid;
                    if (width > 100) // checking the condition on width and increasing the lines and sending wid to width.
                    {
                        lines++;
                        width = wid;
                    }
                }

                return new List<int>() { lines, width }; // returning the list that contains lines and width.
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        /*
        Learning: concepts of stack.
        Recommendations: concept of stacks should be known..
        */
        public static bool IsValid(string bulls_string10)
        {
            try
            {
                Stack<char> leftsymbols = new Stack<char>(); // creating a stack to store left symbols

                foreach (char c in bulls_string10.ToCharArray()) // looping for each characer in string
                {
                    if (c == '(' || c == '{' || c == '[') // checking if left symbol is encountered
                    {
                        leftsymbols.Push(c);
                    }

                    else if (c == ')' && !string.IsNullOrEmpty(Convert.ToString(leftsymbols)) && leftsymbols.Peek() == '(') // below conditions are to check if right symbol is encountered.
                    {
                        leftsymbols.Pop();
                    }

                    else if (c == '}' && !string.IsNullOrEmpty(Convert.ToString(leftsymbols)) && leftsymbols.Peek() == '{')
                    {
                        leftsymbols.Pop();
                    }

                    else if (c == ']' && !string.IsNullOrEmpty(Convert.ToString(leftsymbols)) && leftsymbols.Peek() == '[')
                    {
                        leftsymbols.Pop();
                    }

                    else // If no symbol is enocuntered
                        return false;
                }

                return true;
                //return string.IsNullOrEmpty(Convert.ToString(leftsymbols));
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        /*
        Learning: MORSE representaion.
        Recommendations: Concepts of Hashset and Hashtag should be known.
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                string[] morse = new string[]{".-","-...","-.-.","-..",".","..-.","--.",
                         "....","..",".---","-.-",".-..","--","-.",
                         "---",".--.","--.-",".-.","...","-","..-",
                         "...-",".--","-..-","-.--","--.."};  // declaring a string consisting of all the symbols.

                HashSet<string> seen = new HashSet<string>(); // declaring a hasset

                foreach (string word in words) // looping for all the words and building a string using string builder.
                {
                    StringBuilder code = new StringBuilder();
                    foreach (char c in word.ToCharArray())
                    {
                        code.Append(morse[c - 'a']);
                    }
                    seen.Add(code.ToString());
                }

                return seen.Count; // returing the count of different transformations.
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        /*
        Learning: 
        Recommendations: 
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //int n = grid.Length;
                //bool[,] visited = new bool[n,n];

                //PriorityQueue<int> pq = new PriorityQueue<>();


                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */
        /*
        Learning: Nested methods.
        Recommendations: Concepts of nested methods and understading the problem statememnt clearly to build the correct logic..
        */
        public static int MinDistance(string word1, string word2)
        {

            static int min(int a, int b, int c) // writing a method which gives the minimum value of 3 integers which can be used in the lgic.
            {
                if (a <= b && a <= c)
                    return a;
                else if (b <= a && b <= c)
                    return b;
                else
                    return c;
            }
            try
            {
                int m = word1.Length, n = word2.Length;

                int[] dp = new int[n + 1];

                for (int j = 0; j <= n; j++)
                {
                    dp[j] = j;
                }

                for (int i = 1; i <= m; i++)
                {
                    int[] newdp = new int[n + 1];
                    newdp[0] = i;
                    for (int j = 1; j <= n; j++)
                    {
                        if (word1[i - 1] == word2[j - 1])
                            newdp[j] = dp[j - 1];
                        else
                            newdp[j] = min(dp[j - 1] + 1, dp[j] + 1, newdp[j - 1] + 1);
                    }

                    dp = newdp;
                }

                return dp[n];

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}