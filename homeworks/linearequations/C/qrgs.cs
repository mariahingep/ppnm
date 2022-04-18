using System;
using System.Diagnostics;
public class QRGS{
	public static void qrgs(matrix Q,matrix R){
		int m = Q.size2;
		for(int i = 0; i < m; i++){
			R[i,i] = Q[i].norm();
			Q[i] =Q[i]/ R[i,i];
			for(int j = i + 1; j < m; j++){
				R[i,j] = Q[i].dot(Q[j]);
				Q[j] -= Q[i]*R[i,j];
			}
		}
	}

	public static vector qrgssol(matrix Q, matrix R, vector b){
		matrix QT = Q.transpose();
		vector x = QT*b;
		backsub(R,x);
		return x;
	}

	public static void backsub(matrix U, vector c){
		for(int i = c.size-1; i >= 0; i--){
			double sum = 0;
			for(int k = i + 1; k < c.size; k++){
				sum += U[i,k]*c[k];
			}
		c[i] = (c[i]-sum)/U[i,i];
		}
	}
}
