using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		double[] x = new double[]{1,2,3,4,6,9,10,13,15};
		double[] y = new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1};
		double[] dy = new double[]{5,5,5,5,5,5,1,1,1,1};
		var fs = new Func<double,double>[] {z => 1.0, z => z};
		double[] logy = new double[y.Length];
		double[] dlogy = new double[y.Length];
		for(int i = 0; i < y.Length; i++){
			logy[i] = Log(y[i]);
			dlogy[i] = dy[i]/y[i];
		}
		var fit = lsfit.lsfitting(fs,x,logy,dlogy);
		vector coefs = fit.Item1;
		matrix covs = fit.Item2;
		vector ers = fit.Item3;
		double halflifeer = Log(2)*ers[1]/Pow(coefs[1],2);

		for(int i = 0; i < y.Length; i++){
			WriteLine($"{x[i]} {y[i]} {dy[i]}");
		}
		WriteLine();
		WriteLine();
		for(double i = 1; i < 16; i += 1.0/4){
			WriteLine($"{i} {Exp(coefs[0] + ers[0]) * Exp((coefs[1] + ers[1])*i)}");
		}
		WriteLine();
		WriteLine();
		for(double i = 1; i < 16; i += 1.0/4){
			WriteLine($"{i} {Exp(coefs[0] - ers[0]) * Exp((coefs[1] - ers[1])*i)}");
		}
		WriteLine($"The half-life from the fit: {-1/coefs[1]} days");
		WriteLine("The half-life of 224-Ra is 3.6 days");
		WriteLine($"The uncertainties of the fitting coefficients, fit to f(x)=c1+c2*x:");
		WriteLine($"∆c1 = {ers[0]}");
		WriteLine($"∆c2 = {ers[1]}\n");
		WriteLine($"The half-life with uncertainty:");
		WriteLine($"lambda = {-Log(2)/coefs[1]} +- {halflifeer} day \nwhich doesn't agree with the value within the uncertainty");
		WriteLine($"The covariance matrix:");
		covs.print();
	}

}
