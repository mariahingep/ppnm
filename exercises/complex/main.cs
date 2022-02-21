using static cmath;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		complex z = new complex(-1);
		complex w = sqrt(z);
		w.print("sqrt(-1)= ");
		z = new complex(0,1);
		sqrt(z).print("sqrt(i) = ");
		exp(I).print("exp(i) = ");
		exp(I*PI).print("exp(I*PI) = ");
		log(I).print("log(i) = ");
		sin(I*PI).print("sin(I*PI) = ");
		sinh(I).print("sinh(i) = ");
		cosh(I).print("cosh(i) = ");
}

}
