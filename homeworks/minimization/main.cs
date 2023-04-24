using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{

	static vector qnewton(Func<vector, matrix>fm, Func<vector, vector>fv, vector x, double eps=1e-2){
	/* The function lets say f(x,y) must be seperated (manualy) into ((d^2f/dx^2, df/dydx), (df/dxdy, d^2f/dy^2)) */
		int n = x.size;
		matrix R = new matrix(n, n);
		vector fx = fv(x);
		matrix B = new matrix(n, n);
		double lambda = 1.0;
		bool update_lambda = false;

		for(int i=0; i<n; i++) B[i,i] = 1;
		
		double loop = 0.0;
		while(fx.norm() > eps){
			loop = loop+1;
			if(loop > 1e7) break;
			update_lambda = true;
			vector dx = -B*fx;
			vector new_x = x + lambda*dx;
				
			vector fx_new = fv(new_x);
		
			if(fx_new.norm() < eps){
			       	WriteLine($"Solved (eps satisfied) x = [{new_x[0]}, {new_x[1]}] at loop {loop}");
				return fx_new;
			}

			if(fx_new.norm() < fx.norm())
			{
				x = new_x;
				fx = fx_new;
				matrix Q = fm(dx);
				QRGS.decomp(Q, R);
				B = B + QRGS.inverse(Q, R);
				update_lambda = false;
			}
			if(update_lambda) lambda = lambda/2;
			
			if(lambda < 1.0/1024.0){
				x = new_x;
				fx = fx_new;
				lambda = 1.0;
				for(int k=0; k<n; k++){
					for(int j=0; j<n; j++) B[k,j] = 1;
					B[k,k]=0;
				}

			}
		}
		WriteLine("loop did not work nothing satisfied");

		return fx;
	}

	static matrix rosenbrock(vector x){ /*split into df/dx and df/dy */ 
		matrix A = new matrix(2, 2);
		A[0, 0] = 2 - 400*x[1] + 1200*x[0]*x[0];
		A[0, 1] = -400*x[0];
		A[1, 0] = A[0,1];
		A[1, 1] = 200;
		return A;
	}

	static matrix himmelblau(vector x){ /*split into df/dx and df/dy */ 
		matrix A = new matrix(2, 2);
		A[0, 0] = 12*x[0]*x[0] + 4*x[1] - 42;
		A[0, 1] = 4*(x[0] + x[1]);
		A[1, 0] = A[0,1];
		A[1, 1] = 4*x[0] + 12*x[1]*x[1] - 26;
		return A;}

	static vector v_himmelblau(vector x){
		return new vector(2*(2*x[0]*(x[0]*x[0]+x[1]-11)+x[0]+x[1]*x[1]-7), 2*(x[0]*x[0]+2*x[1]*(x[0]+x[1]*x[1]-7)+x[1]-11));}

	static vector v_rosenbrock(vector x){
		return new vector(-2*(1-x[0]*x[0])-400*(x[1]-x[0]*x[0])*x[0], 200*(x[1]-x[0]*x[0]));}	

	public static void Main(string[] args){

	foreach(var arg in args){
		if(arg == "Out.txt")
		{
			WriteLine();
			//var rnd = new System.Random();	
			vector guess = new vector(-2, 3);
			WriteLine($"Solving Rosenbrock's valley function, guess x = [{guess[0]}, {guess[1]}]");
			vector result = qnewton(rosenbrock, v_rosenbrock, guess, 1e-8);
			result.print("Rosenbrock last value for fx = ");
			WriteLine();
			vector guesst = new vector(-3, 3);
			WriteLine($"Solving Himmelblau's function, guess x = [{guesst[0]}, {guesst[1]}]");
			vector result_him = qnewton(himmelblau, v_himmelblau, guesst, 1e-8);
			result_him.print("Rosenbrock last value for fx = ");
		}
	}
	
}
}
