using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		double[] tabvalue = new double[] {-0.5, -0,125};
		rMaxConv(tabvalue);
		WriteLine("");
		WriteLine("");
		nConv(tabvalue);
	}

	public static void rMaxConv(double[] tabvalue){
		double maxR = 15, dr = 0.1;
		for(int i = 0; i < tabvalue.Length; i++){
			WriteLine("");
			WriteLine("");
			for(double r = 1; r <= maxR; r += 0.5){
				int npoints = (int)(r/dr);
				matrix H = makeHamiltonian(npoints,r);
				(vector e, matrix V) = jacobi.cyclic(H);
				WriteLine($"{r} {e[i]} {tabvalue[i]}");
			}
		}
	}

	public static void nConv(double[] tabvalue){
		int maxN = 100;
		double rMax = 15.0;
		for(int i = 0; i < tabvalue.Length; i++){
			WriteLine("");
			WriteLine("");
			for(int n = 10; n <= maxN; n++){
				matrix H = makeHamiltonian(n,rMax);
				(vector e, matrix V) = jacobi.cyclic(H);
				WriteLine($"{rMax/n} {e[i]} {tabvalue[i]}");
			}
		}
	}

	public static matrix makeHamiltonian(int npoints, double rmax){
		double dr = rmax/npoints;
		vector r = new vector(npoints);
		for(int i = 0; i < npoints; i++){
			r[i] = dr*(i+1);
		}
		matrix H1 = new matrix(npoints,npoints);
		for(int i = 0; i < npoints-1; i++){
			matrix.set(H1,i,i,-2);
			matrix.set(H1,i,i+1,1);
			matrix.set(H1,i+1,i,1);
		}
		matrix.set(H1,npoints-1,npoints-1,-2);
		H1 *= -0.5/dr/dr;
		for(int i = 0; i < npoints; i++){
			H1[i,i] += -1/r[i];
		}
		return H1;
	}
}
