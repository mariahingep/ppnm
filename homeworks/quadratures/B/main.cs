using System;
using static System.Console;
using static System.Math;
using static System.Double;
class main{
	public static void Main() {
		int i = 0, j = 0, k = 0, l = 0;
		double a = 0.0, b = 1.0;

		Func<double, double> f1 = x => {
			i++;
			return 1/Sqrt(x);
		};

		Func<double, double> f2 = x=> {
			j++;
			return 1/Sqrt(x);
		};

		Func<double, double> f3 = x => {
			k++;
			return Log(x)/Sqrt(x);
		};

		Func<double, double> f4 = x => {
			l++;
			return Log(x)/Sqrt(x);
		};

		double sol1 = integrator.integrate(f1, a, b);
		double sol2 = integrator.integrate(f2, a, b);
		double sol3 = integrator.integrate(f3, a, b);
		double sol4 = integrator.integrate(f4, a, b);

		WriteLine($"Comparison of the number of integrand evaluations");
		WriteLine();
		WriteLine($"The integral from {a} to {b} of 1/Sqrt(x), \nclassical method = {sol1}, the number of evaluations was {i}");
		WriteLine($"Clenshaw-Curtis method = {sol2}, the number of evaluations was {j}");
		WriteLine($"The integral from {a} to {b} of Log(x)/Sqrt(x), \nclassical method = {sol3}, the number of evaluations was {k}");
		WriteLine($"Clenshaw-Curtis method = {sol4}, the number of evaluations was {l}");
	}

}
