using System;
using static System.Math;
public static class ode{
	public static(vector, vector) rkstep45(
		Func<double, vector, vector> f,
		double x,
		vector y,
		double h){
			/* ODE notes table on page 5 */
			vector k1 = f(x,y);
			vector k2 = f(x+h/4.0, y+h*(k1/4.0));
			vector k3 = f(x+h*3.0/8, y+h*(k1*3.0/32+k2*9.0/32));
			vector k4 = f(x+h*12.0/13, y+h*(k1*1932.0/2197+k2*(-7200.0/2197)+k3*7295.0/2197));
			vector k5 = f(x+h, y+h*(k1*439.0/216+k2*(-8.0)+k3*3680.0/513+k4*(-845.0/4104)));
			vector k6 = f(x+h/2.0, y+h*(k1*(-8.0/27)+k2*2.0+k3*(-3544.0/2565)+k4*1859.0/4104+k5*(-11.0/40)));
			/* Equation 22 and 23 on page 5 */
			vector yh = y+h*(k1*16.0/135+k2*0.0+k3*6656.0/12825+k4*28561.0/56430+k5*(-9.0/50)+k6*2.0/55);
			vector err = h*(k1*(16.0/135-25.0/216)+k2*0.0+k3*(6656.0/12825-1408.0/2565)+k4*(28561.0/56430-2197.0/4104)+k5*(-9.0/50+1.0/5)+k6*2.0/55);
			return(yh, err);
		}

	public static vector driver(
		Func<double, vector, vector> f,
		double a,
		vector y0,
		double b,
		genlist<double> xlist = null,
		genlist<vector> ylist = null,
		double h = 0.01,
		double acc = 1e-3,
		double eps = 1e-3
		){
		if(a>b) throw new Exception("driver: a>b");
		double x = a;
		vector y = y0;
		if(xlist != null && ylist != null){
			xlist.push(x);
			ylist.push(y0);
		}
		do{
			if(x>=b) return y;
			if(x+h>b) h = b-x;
			var(yh, erv) = rkstep45(f,x,y,h);
			vector tol = new vector(erv.size);
			bool ok = true;
			
			for(int i = 0 ; i < tol.size; i++){
				tol[i] = Max(acc, Abs(yh[i])*eps)*Sqrt(h/(b-a));
				ok = ok && erv[i] < tol[i];
			}
			if(ok){
				x += h;
				y = yh;
				if(xlist != null && ylist != null){
					xlist.push(x);
					ylist.push(y);
				}
			}
			double factor = tol[0]/Abs(erv[0]);
			for(int i = 1; i < tol.size; i++) factor = Min(factor, tol[i]/Abs(erv[i]));
			h *= Min(Pow(factor,0.25)*0.95,2);
		} while(true);

	}
}
