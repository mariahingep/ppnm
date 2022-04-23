using System;
using static System.Console;
using static System.Math;
public class main{
	public static void Main(){
		WriteLine("B: test using genlists");
		WriteLine("Used example from scipy.odeint and result plotted in scipyodint.png.");

		double d = 0.25, c = 5.0;
		Func<double, vector, vector> pend = delegate(double t, vector y){
			double theta = y[0];
			double omega = y[1];
			return new vector(omega, -d*omega-c*Sin(theta));
		};
		/* initial conditions */
		double[] initcond = new double[] {Math.PI - 0.1, 0.0};
		vector y0 = new vector(initcond);

		/* solving scipy.odeint with genlists */
		var xlist = new genlist<double>();
		var ylist = new genlist<vector>();
		double a = 0.0;
		double b = 10.0;
		double h = 0.01;
		double acc = 1e-6;
		double eps = 1e-6;
		vector sol = ode.driver(pend,a,y0,b,xlist,ylist,h,acc,eps);
		using(var outfile = new System.IO.StreamWriter("scipyode.txt")){
			for(int i = 0; i < xlist.size; i++){
				outfile.WriteLine($"{xlist.data[i]} {ylist.data[i][0]} {ylist.data[i][1]}");
			}
		}
	}

}
