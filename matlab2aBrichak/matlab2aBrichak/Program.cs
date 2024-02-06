using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiskorSpusk
{
	class Program
	{



		static void Main(string[] args)
		{
			// колличество прогонов
			int kolIT = 250;
			Point P = new Point();

			// начальные точки
			P.x1 = 2;
			P.x2 = 2;
			for (int i = 0; i < kolIT; i++)
			{


				Point BufP = new Point();
				BufP.x1 = F1(P);
				BufP.x2 = F2(P);

				//Console.WriteLine(BufP);

				PointALF ALF1 = new PointALF();
				PointALF ALF2 = new PointALF();

				ALF1.x1 = P.x1;
				ALF1.ALF = BufP.x1;

				ALF2.x1 = P.x2;
				ALF2.ALF = BufP.x2;

				
				PointALF ALF1B = new PointALF();
				PointALF ALF2B = new PointALF();
				// return (6 * P.x1 - 2 * P.x2 +7);

				ALF1B.x1 = 6 * ALF1.x1 - 2 * ALF2.x1 + 7;

				ALF1B.ALF = 6 * ALF1.ALF - 2 * ALF2.ALF;

				//return (2 * P.x2 - 2 * P.x1 +6);

				ALF2B.x1 = 2 * ALF2.x1 - 2 * ALF1.x1 + 6;
				ALF2B.ALF = 2 * ALF2.ALF - 2 * ALF1.ALF;


				ALF1B.x1 = ALF1B.x1 * BufP.x1;
				ALF1B.ALF = ALF1B.ALF * BufP.x1;

				ALF2B.x1 = ALF2B.x1 * BufP.x2;
				ALF2B.ALF = ALF2B.ALF * BufP.x2;



				double alfa = ALF(ALF1B, ALF2B);
				P.x1 = ALF1.x1 + ALF1.ALF * alfa;
				P.x2 = ALF2.x1 + ALF2.ALF * alfa;

				Console.WriteLine(P + $" на итерации = {i + 1}");
			}

		}

		static double ALF(PointALF ALF1, PointALF ALF2)
		{
			double x = (ALF1.x1 + ALF2.x1) * -1;

			double alf = ALF1.ALF + ALF2.ALF;
			if (alf < 0)
			{
				alf = alf * -1;
				x = x * -1;
			}

			return x / alf;
		}

		//левая функция
		static double F1(Point P)
		{
			return (6 * P.x1 - 2 * P.x2 + 7);
		}

		// прав функция
		static double F2(Point P)
		{
			return (2 * P.x2 - 2 * P.x1 + 6);
		}




	}

	struct Point
	{
		public double x1;
		public double x2;

		public override string ToString()
		{
			return $"X1 = {x1}; X2 = {x2}";
		}
	}

	struct PointALF
	{
		public double x1;
		public double ALF;

		public override string ToString()
		{
			return $"X1 = {x1}; ALF = {ALF}";
		}
	}


}
