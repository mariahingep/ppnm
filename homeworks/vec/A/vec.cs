using static System.Console;
using static System.Math;
public class vec{
	public double x=0, y=0, z=0;

	// Constructors
	public vec(double a, double b, double c){
		x=a; y=b; z=c;
	}
	public vec(){x=y=z=0;}

	//Print method
	public void print(string s){
		Write(s); WriteLine($"{x} {y} {z}");
	}

	public void print() {this.print("");}

	public static vec operator*(vec u, double c){
		return new vec(c*u.x, c*u.y, c*u.z);
	}
	
	public static vec operator*(double c, vec u){
		return u*c;
	}

	public static vec operator+(vec u, vec v){
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
	}

	public static vec operator+(vec u){return u;}
	public static vec operator-(vec u){return -1*u;}
	public static vec operator-(vec u, vec v){return u+(-1)*v;}

}
