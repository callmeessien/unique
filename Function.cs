using System;
using System.Linq;
using System.Collections.Generic;

namespace unique
{
    public class Function
    {
        public string StupidDuplicateSearch(int[] numbers)
        {
            int n = numbers.Length;
            bool[] visited = new bool[n];
            List<int> list = new List<int>();
            Random rng = new Random();

            int i = 0;
            while (i < n)
            {
                int idx = rng.Next(n);

                if (visited[idx])
                {
                    continue;
                }
                visited[idx] = true;

                i++;

                int num = numbers[idx];

                bool exists = false;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] == num)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    list.Add(num);
                }
            }

            int[] arr = list.ToArray();

            ISort(arr);

            return IPrint(arr);
        }

        public string LinearDuplicateSearch(int[] numbers)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0 || numbers[i] != numbers[i - 1])
                {
                    list.Add(numbers[i]);
                }
            }

            int[] arr = list.ToArray();

            ISort(arr);

            return IPrint(arr);
        }

        public string HashSetDuplicateSearch(int[] numbers)
        {
            HashSet<int> set = new HashSet<int>(numbers);

            int[] arr = set.ToArray();

            ISort(arr);

            return IPrint(arr);
        }

        public string DictionaryDuplicateSearch(int[] numbers)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int n in numbers)
            {
                if (dict.ContainsKey(n))
                {
                    dict[n]++;
                }
                else
                {
                    dict[n] = 1;
                }
            }

            int[] arr = dict.Select(kv => kv.Key).ToArray();

            ISort(arr);

            return IPrint(arr);
        }

        public string LinqDuplicateSearch(int[] numbers)
        {
            int[] arr = numbers.Distinct().ToArray();

            ISort(arr);

            return IPrint(arr);
        }

        // You can do instead = Array.Sort
        static int[] ISort(int[] array)
        {
            int temp = 0;

            for (int i = 0; i <= array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        // You can do instead = string.Join(' ', arr)
        public string IPrint(int[] array)
        {
            string res = "";

            foreach (int n in array)
            {
                res += $"{n} ";
            }

            return res.TrimEnd();
        }
    }
}