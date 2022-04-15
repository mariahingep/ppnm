using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		double[] xs = new double[] {0, 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0, 6.5, 7.0};
		double[] ys = new double[15];
		for(int i = 0; i < ys.Length; i++){ys[i] = Sin(xs[i]);}

		for(int i = 0; i < xs.Length; i++){
			WriteLine($"{xs[i]} {ys[i]}");
		}
		WriteLine();
		WriteLine();
		for(double z = 0; z <= 7.0; z += 1.0/70){
			WriteLine($"{z} {matlib.linterp(xs,ys,z)} {matlib.linterpInteg(xs,ys,z)}");
		}

	}

}
