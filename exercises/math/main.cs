using static System.Math;
using static System.Console;

class main{

static void Main(){
	double sqrt2 = Sqrt(2.0);
	Write($"sqrt(2) = {sqrt2}\n");
	Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal to 2)\n");

	double exppi = Exp(PI);
	Write($"exp(pi) = {exppi}\n");
	Write($"ln(exp(pi)) = {Log(exppi)} (should be equal to pi)\n");

	double pie = Pow(PI, E);
	Write($"pi^e = {pie}\n");
	Write($"pow(pi^e, 1/e) = {Pow(pie, 1/E)} (should be equal to pi)\n");
}

}
