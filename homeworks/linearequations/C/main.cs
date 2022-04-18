using System;
using static System.Console;
using static System.Random;
using System.Diagnostics;
public class main{
	public static void Main(){
		/* Generating random matrix */
		var rand = new Random();
		int N = 300;
		for(int n = 10; n <= N; n += 10){
			matrix Q = new matrix(n,n);
			matrix R = new matrix(n,n);
			for(int i = 0; i < n; i++){
				for(int j = 0; j < n; j++){
					Q[i,j] = rand.NextDouble();
				}
			}
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			QRGS.qrgs(Q,R);
			stopwatch.Stop();
			double time = stopwatch.ElapsedMilliseconds;
			WriteLine($"{n} {time}");
		}
	}

}
