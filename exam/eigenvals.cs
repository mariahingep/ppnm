using System;
using static System.Console;
using static System.Math;
public class eigenvals{
	public static matrix mat(matrix D, vector u, int p){
		int n = D.size1;
		matrix A = new matrix(n,n);
		
		for(int i = 0; i < n; i++){
			A[i,i] = D[i,i];
		}
		for(int i = 0; i < n; i++){
			for(int j = 0; j < n; j++){
				if(j == p){
					A[i,j] = A[i,j]+u[i];
				}
				if(i == p){
					A[i,j] = A[i,j]+u[j];
				}
			}
		}
		return A;

	}

	public static vector det(matrix A, int p){
		int n = A.size1;
		int iter = 50;
		vector e = new vector(n);
		double x = 0;
		double dx = 0;
		double e0;
		for(int i = 0; i < n; i++){
			e[i] = A[i,i]+0.1;
		}

		for(int i = 0; i < n; i++){
			for(int j = 0; j < iter; j++){
				x = 0;
				dx = 0;
				/* Finding x */
				for(int k = 0; k < n; k++){
					if(k == p) x = x-(A[p,p]-e[i]);
					else x = x+A[k,p]*A[k,p]/(A[k,p]-e[i]);
				}
				/* Finding dx */
				for(int k = 0; k < n; k++){
					if(k == p) dx = dx+1;
					else dx = dx+A[k,p]*A[k,p]/((A[k,k]-e[i])*(A[k,k]-e[i]));
				}

				e0 = e[i];
				/* Newton-Raphson method */
				e[i] = (e[i]-x/dx);
			}
		}
		return e;
	}

}
