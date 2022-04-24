using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main() {
		WriteLine("Test of integrator");
		double a = 0.0, b = 1.0;

		Func<double, double> f1 = x => Sqrt(x);
		Func<double, double> f2 = x => 1/Sqrt(x);
		Func<double, double> f3 = x => 4*Sqrt(1-x*x);
		Func<double, double> f4 = x => Log(x)/Sqrt(x);

		double sol1 = integrator.integrate(f1, a, b);
		double sol2 = integrator.integrate(f2, a, b);
		double sol3 = integrator.integrate(f3, a, b);
		double sol4 = integrator.integrate(f4, a, b);

		WriteLine($"The integral of Sqrt(x) from {a} to {b} = {sol1}, \nexpected to be = {2.0/3}");
		WriteLine($"The integral of 1/Sqrt(x) from {a} to {b} = {sol2}, \nexpected to be = {2}");
		WriteLine($"The integral of 4/Sqrt(1-x^2) from {a} to {b} = {sol3}, \nexpected to be = {PI}");
		WriteLine($"The integral of Log(x)/Sqrt(x) from {a} to {b} = {sol4}, \nexpected to be = {-4}");

		using(var outfile = new System.IO.StreamWriter("erf.txt")) {
			for(double x = -2; x <= 2; x += 1.0/8) {
				outfile.WriteLine($"{x} {integrator.erf(x)}");
			}
		}
	}

}
