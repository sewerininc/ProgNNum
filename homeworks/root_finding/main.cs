using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{

	public static bool approx(double x, double y, double acc=0.001, double eps=0.001){
		if(Abs(x-y)<acc)return true;
		if(Abs(x-y)/Max(Abs(x),Abs(y))<eps)return true;
		return false;
	}
	
	public static matrix get_jacobian(Func<vector, vector>f, vector x){
		int n = x.size;
		matrix jacobian = new matrix(n, n); 
		vector f0 = f(x);
		
		vector xi = x.copy();

		double dx = 1e-8;

		for(int k = 0; k<n; k++){
			xi[k] = x[k] + dx;
			vector fi = f(xi);
			for(int i = 0 ; i<n; i++){
				jacobian[i, k] = (fi[i] - f0[i])/dx;
			}
			xi[k] = x[k];
		}
		return jacobian;
	}
	
	static vector newton(Func<vector, vector>f, vector x, double eps=1e-2){
		/* The function must be seperated (manualy) into (df/dx, df/dy) if we have 50 dims this is too much work? */
		int n = x.size;
		matrix J = get_jacobian(f, x);
		vector fx = f(x);

		for(int i=0; i<1000; i++){
			matrix Q = J.copy();
			matrix R = new matrix(n,n);
			QRGS.decomp(Q, R);
			vector dx = QRGS.solve(Q, R, fx);
			
			vector new_x = new vector(n);
			for(int g=0; g<n; g++) {
				new_x[g] = x[g] - dx[g]; 
			}
			
			vector fx_test = f(new_x);
			
			if(fx_test.norm() < eps){
			       	WriteLine($"Solved (eps satisfied) x = [{new_x[0]}, {new_x[1]}] at loop {i}");
				return fx;
			}
			x = new_x;
			fx = fx_test;
			J = get_jacobian(f,x);
		}
		WriteLine("loop did not work nothing satisfied");

		
		return fx;
	}

	static vector test_func(vector x){ return new vector(2*x[0], 2*x[1]);}

	static vector rosenbrock(vector x){ /*split into df/dx and df/dy */ 
		return new vector(-2*(1-x[0]*x[0])-400*(x[1]-x[0]*x[0])*x[0], 200*(x[1]-x[0]*x[0]));}

	public static void Main(string[] args){

		foreach(var arg in args){
			if(arg == "Out.txt"){
				var rnd = new System.Random();	
				vector vector_a = new vector(rnd.Next(-100000, 100000), rnd.Next(-100000, 100000));
				WriteLine($"Solving the function f(x,y) = 2xy, random guess x = [{vector_a[0]}, {vector_a[1]}]");
				vector test = newton(test_func, vector_a, 1e-8);
				test.print("test funcs Last value for fx = ");
				WriteLine();

				vector vector_b = new vector(rnd.Next(-350, 350), rnd.Next(-350,350));
				WriteLine($"Solving Rosenbrock's valley function, random guess x = [{vector_b[0]}, {vector_b[1]}]");
				vector rosen = newton(rosenbrock, vector_b, 1e-8);
				rosen.print("Rosenbrock last value for fx = ");
				
			}
		}
	
	}
}
