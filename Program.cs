using System;
using System.Linq;
using System.Collections.Generic;

namespace unique
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    throw new FormatException();
                }

                int[] numbers = Array.ConvertAll(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries), s => int.Parse(s.Trim()));
    
                var func = new Function();
    
                // Console.WriteLine(func.StupidDuplicateSearch(numbers));
    
                // Console.WriteLine(func.LinearDuplicateSearch(numbers));
    
                Console.WriteLine(func.HashSetDuplicateSearch(numbers));
    
                // Console.WriteLine(func.DictionaryDuplicateSearch(numbers));
    
                // Console.WriteLine(func.LinqDuplicateSearch(numbers));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}