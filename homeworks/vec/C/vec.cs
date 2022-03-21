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

	// Dot product methods
	public double dot(vec other){
		return this.x*other.x + this.y+other.y + this.z+other.z;
	}

	public static double dot(vec v, vec u){
		return v.x*u.x + v.y*u.y + v.z*u.z;
	}

	// Vector product methods
	public vec vecprod(vec other){
		return new vec(this.y*other.z-this.z*other.y, this.z*other.x-this.x*other.z, this.x*other.y-this.y*other.x);
	}

	public static vec vecprod(vec v, vec u){
		return new vec(v.y*u.z-v.z*u.y, v.z*u.x-v.x*u.z, v.x*u.y-v.y*u.x);
	}

	// Norm
	public double norm(){
		return Sqrt(Pow(this.x,2)+Pow(this.y,2)+Pow(this.z,2));
	}

	// Override the toString method
	public override string ToString(){
		return $"{x} {y} {z}";
	}

	static bool approx(double a, double b, double tau=1e-9, double eps=1e-9){
	if(Abs(a-b)<tau)return true;
	if(Abs(a-b)/(Abs(a)+Abs(b))<eps)return true;
	return false;
	}
	public bool approx(vec other){
		if(!approx(this.x,other.x)) {return false;}
		if(!approx(this.y,other.y)) {return false;}
		if(!approx(this.z,other.z)) {return false;}
	return true;
	}
	public static bool approx(vec u, vec v){return u.approx(v);}
}
