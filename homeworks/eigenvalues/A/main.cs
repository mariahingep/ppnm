using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		/* random symmetric matrix */
		int n = 5, m = n;
		var D = new matrix(n,m);
		var I = new matrix(n,n);
		I.set_identity();
		var rand = new Random();
		for(int i = 0; i < n; i++){
			for(int j = 0; j <= i; j++){
				D[i,j] = rand.NextDouble();
				D[j,i] = D[i,j];
			}	
		}

		/* eigenvalue decomp */
		var A = D.copy();
		vector e; matrix V;
		(e,V) = jacobi.cyclic(D);

		A.print("random matrix A:");
		WriteLine($"");
		V.print("The orthogonal matrix of the eigenvectors V:");
		WriteLine($"");
		D.print("The diagonal matrix and corresponding eigenvalues D:");
		WriteLine($"");
		WriteLine("Checking the following:");
		WriteLine($"A=VD(V^T): {A.approx(V*D*V.transpose())}");
		WriteLine($"(V^T)AV=D: {D.approx(V.transpose()*A*V)}");
		WriteLine($"(V^T)V=I: {I.approx(V.transpose()*V)}");
		WriteLine($"V(V^T)=I: {I.approx(V*V.transpose())}");
	}

}
