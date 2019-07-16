using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Question_3
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Test 1:");
      using (System.IO.StreamReader sr = new StreamReader("numbers1.csv"))
      {
        string[] nums = sr.ReadToEnd().Split(',');
        int[] numbers = Array.ConvertAll(nums, num => int.Parse(num));
        int[] answers = { 4, 2, 1, 3, 5 };

        numbers = findDuplicates(numbers);
        Console.WriteLine(compareArrays(numbers, answers));
      }

      Console.WriteLine("Test 2:");
      using (System.IO.StreamReader sr = new StreamReader("numbers2.csv"))
      {
        string[] nums = sr.ReadToEnd().Split(',');
        int[] numbers = Array.ConvertAll(nums, num => int.Parse(num));
        int[] answers = { 9, 2, 3, 4, 5, 6, 7, 8, 12, 13, 1 };

        numbers = findDuplicates(numbers);
        Console.WriteLine(compareArrays(numbers, answers));
      }

      Console.WriteLine("Test 3:");
      using (System.IO.StreamReader sr = new StreamReader("numbers3.csv"))
      {
        string[] nums = sr.ReadToEnd().Split(',');
        int[] numbers = Array.ConvertAll(nums, num => int.Parse(num));
        int[] answers = {};

        numbers = findDuplicates(numbers);
        Console.WriteLine(compareArrays(numbers, answers));
      }

    }

    static int[] findDuplicates(int[] numbers)
    {
      Dictionary<int, int> cache = new Dictionary<int, int>();
      Dictionary<int, int> duplicatesDictionary = new Dictionary<int, int>();
      foreach (int num in numbers)
      {
        if (cache.ContainsKey(num))
        {
          if (!duplicatesDictionary.ContainsKey(num))
          {
            duplicatesDictionary.Add(num, num);
          }
        }
        else
        {
          cache.Add(num, num);
        }
      }
      int[] duplicates = {};
      if (duplicatesDictionary.Count != 0) {
          duplicates = duplicatesDictionary.Values.ToArray();
      }
      return duplicates;
    }

    static string compareArrays(int[] array1, int[] array2)
    {
      for (int i = 0; i < array1.Length; i++)
      {
        if (array1[i] != array2[i])
        {
          return "Failed";
        }
      }
      return "Passed!";
    }


  }

}
