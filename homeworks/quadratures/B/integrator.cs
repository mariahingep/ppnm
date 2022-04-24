using System;
using static System.Console;
using static System.Math;
using static System.Double;
public class integrator{
	public static double integrate(
		Func<double, double> f,
		double a,
		double b,
		double del = 0.001,
		double eps = 0.001,
		double f2 = NaN,
		double f3 = NaN
		) {
		double h = b - a;
		if(IsNaN(f2)) {
			f2 = f(a+2*h/6);
			f3 = f(a+4*h/6);
		}
		double f1 = f(a+h/6), f4 = f(a+5*h/6);
		double Q = (2*f1+f2+f3+2*f4)/6*(b-a);
		double q = (f1+f2+f3+f4)/4*(b-a);
		double err = Abs(Q-q);
		if(err <= del + eps * Abs(Q)) {
			return Q;
		}
		else {
			return integrate(f, a, (a+b)/2, del/Sqrt(2), eps, f1, f2) + integrate(f, (a+b)/2, b, del/Sqrt(2), eps, f3, f4);
		}
	}

	public static double erf(double z) {
		Func<double, double> f = x => 2/Sqrt(PI)*Exp(-x*x);
		return integrate(f, 0, z);
	}

	public static double ccintegrate(Func<double, double> f, double a, double b) {
		Func<double, double> f1;
		if(a == -1 && b == 1) {
			f1 = x => f(Cos(x))*Sin(x);
		}
		else {
			f1 = x => f((a+b)/2+(b-a)/2*Cos(x))*Sin(x)*(b-a)/2;
		}
		return integrate(f1, 0, PI);
	}
}
