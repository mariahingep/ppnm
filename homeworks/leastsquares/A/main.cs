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
		vector coefs = lsfit.lsfitting(fs,x,logy,dlogy);
		for(int i = 0; i < y.Length; i++){
			WriteLine($"{x[i]} {y[i]} {dy[i]}");
		}
		WriteLine();
		WriteLine();
		for(double i = 1; i < 16; i += 1.0/4){
			WriteLine($"{i} {Exp(coefs[0]) * Exp(coefs[1]*i)}");
		}
		WriteLine();
		WriteLine();
		WriteLine($"The half-life from the fit: {-1/coefs[1]} days");
		WriteLine("The half-life of 224-Ra is 3.6 days");
	}

}
