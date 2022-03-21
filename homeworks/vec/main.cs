using static System.Console;
using static vec;
class main{
	static void Main(){
		vec u = new vec(100, 200, 300);
		u.print("u=");
		vec v = new ved(1, 2, 3);
		v.print("v=");
		(u+v).print($"u+v=");
		var w = 3.u - v;
		w.print("w=");
		WriteLine($"u.dot(v) = {u.dot(v)}");
		WriteLine($"dot(u,v) = {dot(u,v)}");
		WriteLine($"v.norm() = {v.norm()}");
		vec s = new vec(3, 2, 1);
		s.print(2s=");
		WriteLine($"v.vecprod(s) = {v.vecprod(s)}");
		WriteLine($"vecprod(v,s) = {vecprod(v,s)}");
	}

}
