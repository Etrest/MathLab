using System;

class Program
{
	static void Main()
	{
		int KolP = 4;

		double[][] a = new double[][] {
		   new double[] { 4, -1,  1,  1,  2, 1, 0, 0 },
		   new double[] { 3,  2,  0,  1, -3, 0, 1, 0 },
		   new double[] { 6,  3,  0, -1,  6, 0, 0, 1 },
		   new double[] { 0, -8,  1,  3, -1, 0, 0, 0 }
		};

		double[][] ab = new double[][] {
		   new double[] { 4, -1,  1,  1,  2, 1, 0, 0 },
		   new double[] { 3,  2,  0,  1, -3, 0, 1, 0 },
		   new double[] { 6,  3,  0, -1,  6, 0, 0, 1 },
		   new double[] { 0, -8,  1,  3, -1, 0, 0, 0 }
		};

		double[] b = { 5, 6, 7 };
		do
		{
			int CurrentX = FindMinIndex(a[a.Length - 1], KolP);
			int CurrentSE = FindRowIndex(a, CurrentX);
			b[CurrentSE] = CurrentX;
			double buf = 0;
			for (int i = 0; i < a.Length; i++)
			{
				for (int j = 0; j < a[i].Length; j++)
				{
					buf = (a[i][j]) - ((a[i][CurrentX] * a[CurrentSE][j]) / a[CurrentSE][CurrentX]);
					ab[i][j] = buf;
				}
			}

			for (int i = 0; i < a[CurrentSE].Length; i++)
			{
				buf = a[CurrentSE][i] / a[CurrentSE][CurrentX];
				ab[CurrentSE][i] = buf;
			}

			for (int i = 0; i < ab.Length; i++)
			{
				for (int j = 0; j < ab[i].Length; j++)
				{
					a[i][j] = ab[i][j];
				}
			}

			PrintJaggedArray(a);

		} while (FindMinIndex(a[a.Length - 1], KolP) != -1);

		Console.WriteLine();
		Console.WriteLine("Значения X");
		Console.WriteLine("-------------");
		double xi;
		for (int i = 1; i <= KolP; i++)
		{
			xi = Array.Find(b, X => X == i);
			if (xi != 0)
				Console.WriteLine($"X{i} = {a[Array.IndexOf(b, xi)][0]}");
			else
				Console.WriteLine($"X{i} = 0");
		}
		Console.WriteLine("-------------");
		Console.WriteLine();
		Console.WriteLine($"F(x) = {a[a.Length - 1][0]}");


	}


	static void PrintJaggedArray(double[][] jaggedArray)
	{
		Console.WriteLine("Элементы ступенчатого массива:");

		for (int i = 0; i < jaggedArray.Length; i++)
		{
			Console.Write($"Строка {i}: ");
			PrintArray(jaggedArray[i]);
		}
	}

	static void PrintArray(double[] array)
	{
		for (int j = 0; j < array.Length; j++)
		{
			Console.Write("| " + array[j] + " |");
		}

		Console.WriteLine();
	}


	static int FindMinIndex(double[] array, int KolP)
	{
		int indexOfMinNegative = -1;
		double minNegative = double.MaxValue;

		for (int i = 0; i <= KolP; i++)
		{
			if (array[i] < 0 && array[i] < minNegative)
			{
				minNegative = array[i];
				indexOfMinNegative = i;
			}
		}

		return indexOfMinNegative;
	}

	static int FindRowIndex(double[][] array, int Xcolum)
	{
		double[] arr = new double[array.Length - 1];

		for (int i = 0; i < array.Length - 1; i++)
		{
			if (array[i][Xcolum] == 0)
			{
				arr[i] = 9999;
			}
			else
				arr[i] = array[i][0] / array[i][Xcolum];

		}

		int minPositiveIndex = -1;

		for (int i = 0; i < arr.Length; i++)
		{
			if (arr[i] > 0 && (minPositiveIndex == -1 || arr[i] < arr[minPositiveIndex]))
			{
				minPositiveIndex = i;
			}
		}


		return minPositiveIndex;
	}
}
