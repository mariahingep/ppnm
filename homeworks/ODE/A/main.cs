using static System.Console;
using static System.Math;
using System;
public class main{
	public static void Main(){
		WriteLine("Test of scipy.integrate.odeint example");
		WriteLine("Results are plotted ion scipyodeint.png");

		double b = 0.25, c = 5.0;
		Func<double, vector, vector> pend = delegate(double t, vector y){
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, - b*omega - c*Sin(theta));
		};
		/* initial conditions */
		double[] initcond = new double[] {Math.PI - 0.1, 0.0};
		vector y0 = new vector(initcond);
		Func<double, vector, vector> osc = delegate(double t, vector y){
			return new vector(y[1], -y[0]);
		};
		/* solving scipy odeint */
		double step = 1.0/16;
		using(var outfile = new System.IO.StreamWriter("scipyode.txt")){
			for(double ti = step; ti <= 10.0; ti += step){
				vector sol = ode.driver(pend, ti-step,y0,ti);
				outfile.WriteLine($"{ti} {sol[0]} {sol[1]}");
				y0 = sol;
			}
		}
		WriteLine("Test of example");
		WriteLine("Diff.eq. u''=-u solved for initial conditions y0=(0,1). \nResults plotted in oscillator.png");
		/* solving u''=-u for y0=(0,1) */
		double[] initcos = new double[] {0.0, 1.0};
		vector y0cos = new vector(initcos);
		using(var outfile = new System.IO.StreamWriter("oscillator.txt")){
			for(double ti = step; ti <= 10.0; ti += step){
				vector sol = ode.driver(osc, ti-step, y0cos, ti);
				outfile.WriteLine($"{ti} {sol[0]} {sol[1]}");
				y0cos = sol;
			}
		}

	}

}
