using System;
using static System.Console;
using static System.Math;
public class main{
	public static void Main(){
		WriteLine("Test of Monte Carlo implementation on a few integrals\n");
		WriteLine("(Examples from Wikipedia) The integral of x^2 + 4y with xlims = [11,14] and ylims = [7,10]:");

		Func<vector, double> f1 = xy => xy[0]*xy[0]+4*xy[1];
		vector a1 = new double[] {11,7};
		vector b1 = new double[] {14,10};
		var res1 = mc.plainmc(f1, a1, b1, 100000);
		var res12 = mc.quasimc(f1, a1, b1, 100000);
		
		WriteLine($"Plain Monte Carlo is {res1.Item1} with the error {res1.Item2}");
		WriteLine($"Quasi Monte Carlo is {res12.Item1} with the error {res12.Item2}");
		WriteLine("The result should be 1719\n");

		WriteLine("The integral of x^2/(1+y^2) with xlims = [0,1] and ylims = [0,1]:");
		Func<vector, double> f2 = xy => xy[0]*xy[0]/(1+xy[1]*xy[1]);
		vector a2 = new double[] {0,0};
		vector b2 = new double[] {1,1};
		var res2 = mc.plainmc(f2, a2, b2, 100000);
		var res22 = mc.quasimc(f2, a2, b2, 100000);

		WriteLine($"Plain Monte Carlo is {res2.Item1} with the error {res2.Item2}");
		WriteLine($"Quasi Monte Carlo is {res22.Item1} with the error {res22.Item2}");
		WriteLine("The result should be pi/12 = {PI/12}\n");

		WriteLine("The integral of 1/(pi^3*{1-cos(x)*cos(y)*cos(z)}) with xlims = ylims = zlims = [0,pi]:");
		Func<vector, double> f3 = xyz => 1.0/(Pow(PI,3)*(1.0-Cos(xyz[0])*Cos(xyz[1])*Cos(xyz[2])));
		vector a3 = new double[] {0,0,0};
		vector b3 = new double[] {PI,PI,PI};
		var res3 = mc.plainmc(f3, a3, b3, 100000);
		var res32 = mc.quasimc(f3, a3, b3, 100000);
		
		WriteLine($"Plain Monte Carlo is {res3.Item1} with the error {res3.Item2}");
		WriteLine($"Quasi Monte Carlo is {res32.Item1} with the error {res32.Item2}");
		WriteLine("The result should be 1.393203929668...\n");
		WriteLine("Errors from quasi Monte Carlo seems to be smaller than for Plain Monte Carlo.");
	}

}
