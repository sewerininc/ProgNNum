using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{

	public static matrix get_hessian(Func<vector, vector>f, vector x){
		int n = x.size;
		matrix hessian = new matrix(n, n); 
		vector f0 = f(x);
		
		vector xi = x.copy();

		double dx = 1e-8;

		for(int k = 0; k<n; k++){
			xi[k] = x[k] + dx;
			vector fi = f(xi);
			for(int i = 0 ; i<n; i++){
				hessian[i, k] = (fi[i] - f0[i])/dx;
			}
			xi[k] = x[k];
		}
		return hessian;
	}
	
	static vector qnewton(Func<vector, matrix>f, vector x, double eps=1e-2){
	/* The function lets say f(x,y) must be seperated (manualy) into ((d^2f/dx^2, df/dydx), (df/dxdy, d^2f/dy^2)) */
			


		return x;
	}

	static matrix rosenbrock(vector x){ /*split into df/dx and df/dy */ 
		matrix A = new matrix(2, 2);
		A[0, 0] = 2 - 400*x[1] + 1200*x[0]*x[0];
		A[0, 1] = -400*x[0];
		A[1, 0] = A[0,1];
		A[1, 1] = 200;
		return A;
	}		

	public static void Main(string[] args){

	foreach(var arg in args){
		if(arg == "Out.txt"){
			var rnd = new System.Random();	
			vector guess = new vector(rnd.Next(-100, 100), rnd.Next(-100,100));
			vector result = qnewton(rosenbrock, guess);
		}
	}
	
}
}
