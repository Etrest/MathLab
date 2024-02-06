
//Стартовая функция F(x) = 3(x1^2) - 2x1x2 +x2^2 +7x1 + 6x2
//Ограничение 1: x1 + x3 >= 2
//Ограничение 2: x1+2x2 <= 4
// x1>=0, x2>=0
//x0 = [2;2]

// DelF(x) = [dF/dx1;dF/dx2] = [(6x1-2x2+7);(2x2-2x1+6)]
double[] x0 = { 2, 2 };//стартовая точка

double[] delFx0 = { PointX1(x0[0], x0[1]), PointX2(x0[0], x0[1]) };
Console.WriteLine($"delF0x = [{delFx0[0]};{delFx0[1]}]");

//H(x)= [d^2F/dx1^2	;d^2F/dx1dx2]=  [ 6;-2]
//		[d^2F/dx2dx1;d^2F/dx2^2	]	[-2; 2]

double[,] Hx = { { 6, -2 }, { -2, 2 } };


//H-1(x) - обратная по отношение к H(x)
double[,] revH = findRevH(Hx);


//По формуле x(k+1) = xk - H-1(xk) DelF(xk)

double[] x1 = { (x0[0] - ((revH[0, 0] * delFx0[0])  + (revH[0, 1]* delFx0[1]))), (x0[1] - ((revH[1,0] * delFx0[0]) + (revH[1,1] * delFx0[1]))) };

Console.WriteLine($"x1 = [{x1[0]}; {x1[1]}]");

double[] delF1x = { PointX1(x1[0], x1[1]), PointX2(x1[0], x1[1]) };//находим DelF(x1)

double Fx1 = 3 * Math.Pow(x1[0], 2) - 2 * x1[0] * x1[1] + Math.Pow(x1[1], 2) + 7 * x1[0] + 6 * x1[1];

Console.WriteLine($"delF1x = [{delF1x[0]};{delF1x[1]}]");
Console.WriteLine($"F1x = [{Fx1}]");




Console.ReadLine();

 double PointX1(double x1, double x2)//поиск x1
{
	double resx = ((6 * x1) - (2 * x2) + 7);


	return resx;
}
double PointX2(double x1, double x2)//поиск x2
{
	double resx = ((2 * x2) - (2 * x1) + 6);

	return resx;
}

double[,] findRevH(double[,] matrix)//поиск H-1(x)
{
	double[,] aH = adjHElem(matrix);

	double[,] RevH = { {detH(matrix) * aH[0,0], detH(matrix) * aH[0, 1] }, { detH(matrix) * aH[1, 0], detH(matrix) * aH[1, 1] } };
	


	return RevH;
}


double[,] adjHElem(double[,] matrix)//Поиск присоединённой (союзной) матрицы
{
	double[,] jM = { { 0, 0 }, { 0, 0 } };

	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < 2; j++)
		{
			double elem = (Math.Pow(-1, (i + 1 + j + 1))) * matrix[Math.Abs(i - 1), Math.Abs(j - 1)];
			jM[i, j] = elem;
		}
	}

	return jM;
}

double detH(double[,] matrix)//поиск определителя матрицы
{
	double dH = 1 / ((matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]));

	return dH;
}