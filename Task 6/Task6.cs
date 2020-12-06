using System;

namespace sharpz
{
  public class Task6
  {
    public static void run() 
    {
      Task6 task6 = new Task6(5, 12);
      task6.PrintValueAtIndex(2, 2);
      task6.SumHighestAndLowestValuesInRow();
    }

    private int[,] array;

    private static string ARRAY_DIMENSIONS_ERROR = "Specified array dimensions are incorrect";
    private static string ARRAY_INDEX_OUTOFRANGE_ERROR = "Specified array indexes are out of range";

    public Task6(int arrWidth, int arrDepth)
    {
      GenerateNewArray(arrWidth, arrDepth);
    }

    public void GenerateNewArray(int arrWidth, int arrDepth)
    {
      if (arrWidth < 1 || arrDepth < 1)
      {
        Console.WriteLine(ARRAY_DIMENSIONS_ERROR);
        return;
      }

      array = new int[arrDepth, arrWidth];

      FillRandomNumbers();

      PrintWholeArray();
    }

    public void PrintValueAtIndex(int x, int y)
    {
      try
      {
        Console.WriteLine(array.GetValue(x, y));
      }
      catch (IndexOutOfRangeException)
      {
        Console.WriteLine(ARRAY_INDEX_OUTOFRANGE_ERROR);
      }
    }

    public void SumHighestAndLowestValuesInRow()
    {
      for (int j = 0; j < array.GetLength(0); j++)
      {
        int highest = 0;
        int lowest = 41;

        for (int i = 0; i < array.GetLength(1); i++)
        {
          int value = array[j, i];

          if (value > highest)
            highest = value;
          if (value < lowest)
            lowest = value;
        }

        Console.WriteLine($"Highest: {highest}, Lowest: {lowest}, Sum: {highest + lowest}");
      }
    }

    private void FillRandomNumbers()
    {
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          array[i, j] = new Random().Next(1, 40);
        }
      }
    }

    private void PrintWholeArray()
    {
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          Console.Write(array[i, j] + " ");
        }

        Console.WriteLine();
      }
    }
  }
}
