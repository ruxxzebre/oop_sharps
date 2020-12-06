using System;

namespace sharpz
{
  public class Task9
  {
    public static void run() 
    {
      Task9 task9 = new Task9(3, 9);
      Task9.MyCalculation(task9.Array, task9.ConditionCheck);
      Task9.MyCalculation(task9.Array, (x) => x <= 27);
    }

    public int[,] Array { get; private set; }

    public delegate bool IsEqual(int x);

    private static string Array_DIMENSIONS_ERROR = "Specified Array dimensions are incorrect";
    private static string Array_INDEX_OUTOFRANGE_ERROR = "Specified Array indexes are out of range";
    private static string MY_CALCULATION = "My calculation resul: ";

    public Task9(int arrWidth, int arrDepth)
    {
      GenerateNewArray(arrWidth, arrDepth);
    }

    public void GenerateNewArray(int arrWidth, int arrDepth)
    {
      if (arrWidth < 1 || arrDepth < 1)
      {
        Console.WriteLine(Array_DIMENSIONS_ERROR);
        return;
      }

      Array = new int[arrDepth, arrWidth];

      FillRandomNumbers();

      PrintWholeArray();
    }

    public void PrintValueAtIndex(int x, int y)
    {
      try
      {
        Console.WriteLine(Array.GetValue(x, y));
      }
      catch (IndexOutOfRangeException)
      {
        Console.WriteLine(Array_INDEX_OUTOFRANGE_ERROR);
      }
    }

    public void SumHighestAndLowestValuesInRow()
    {
      for (int j = 0; j < Array.GetLength(0); j++)
      {
        int highest = 0;
        int lowest = 41;

        for (int i = 0; i < Array.GetLength(1); i++)
        {
          int value = Array[j, i];

          if (value > highest)
            highest = value;
          if (value < lowest)
            lowest = value;
        }

        Console.WriteLine($"{highest} + {lowest} = {highest + lowest}");
      }
    }

    public bool ConditionCheck(int x)
    {
      return x % 7 == 0;
    }

    public static void MyCalculation(int[,] a, IsEqual method)
    {
      foreach (var element in a)
      {
        Console.WriteLine(MY_CALCULATION + element + " " + method(element).ToString());
      }
    }

    private void FillRandomNumbers()
    {
      for (int i = 0; i < Array.GetLength(0); i++)
      {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
          Array[i, j] = new Random().Next(1, 40);
        }
      }
    }

    private void PrintWholeArray()
    {
      for (int i = 0; i < Array.GetLength(0); i++)
      {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
          Console.Write(Array[i, j] + " ");
        }

        Console.WriteLine();
      }
    }
  }
}
