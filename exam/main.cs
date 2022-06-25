using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		/* random symmetric diagonal matrix */
		int p = 3;
		int n = 5;
		var D = new matrix(n,n);
		var u = new vector(n);
		var rand = new Random();
		for(int i = 0; i < n; i++){
			for(int j = 0; j <= i; j++){
				D[i,i] = rand.Next(100)+1;
				if(i == p) u[i] = 0;
				else u[i] = (rand.Next(10)+1);
			}
		}
	
		D.print("Random symmetric diagonal matrix D:");
		WriteLine($"");
		u.print("Random vector where u_p = 0:\n");
		matrix A = eigenvals.mat(D,u,p);
		WriteLine($"");
		A.print("A matrix determined:");
		WriteLine($"");
		WriteLine("Corresponding eigenvalues:");
		vector e = eigenvals.det(A,p);
		e.print();
		WriteLine($"");
		vector eig = eigenvals.test(A,e,p);
		WriteLine($"Checking if eigenvalues returns 0-vector: {eig.approx(new vector(n))}");
		WriteLine($"");
		eig.print();

	}
}
