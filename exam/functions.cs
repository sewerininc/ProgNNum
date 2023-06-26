using System;
using static System.Console;
using static System.Math;
public static class functions{

	public static matrix get_D(int n){
                matrix D = new matrix(n, n);
                int max_uTu_value = 25*n*2; 
		vemil_godt_ppar rnd = new System.Random();
                for(int i=0; i<n; i++){
                        D[i,i] = rnd.Next(1+max_uTu_value*i, 5+max_uTu_value*i);
                }
                return D;
        }

	public static matrix get_u(int n){
		matrix u = new matrix(n, 1);
		var rnd = new System.Random();
		for(int i=0; i<n; i++){
			u[i, 0] = rnd.Next(1, 6);
		}
		return u;
	}
	
	public static double secular_eq(double x, matrix D, matrix u){/* simga = 1 */
		double function = 1.0;
		for(int i=0; i<D.size1; i++){
			function += u[i, 0]*u[i, 0]/(D[i,i]-x);
		}
		return function;
	}
	
	public static double diff_secular_eq(double x, matrix D, matrix u){/* simga = 1 */
		double function = 1.0;
		for(int i=0; i<D.size1; i++){
			function += u[i, 0]*u[i, 0]/Pow(D[i,i]-x, 2);
		}
		return function;
	}
	
	public static double get_one_root(Func<double, double>sec, Func<double, double>diff_sec, double guess, double unc=1e-3
	, bool print = true){
		
		double test_value = 0.0;
		
		for(int i=0; i<1e5; i++){
			
			test_value = sec(guess);
			
			if(Abs(test_value) < unc){
				if(print) WriteLine($"Found eigenvalue λ = {guess} where f(λ) = {test_value} at {i} itterations");	
				return guess;
			}
			
			guess = guess - sec(guess)/diff_sec(guess);
		}
		if(print) WriteLine("No solution found");
		return 0.0;
		
	}
	
	public static double get_itterations(Func<double, double>sec, Func<double, double>diff_sec, double guess, double unc=1e-3
	, bool print = true){
		
		double test_value = 0.0;
		
		for(int i=0; i<1e5; i++){
			
			test_value = sec(guess);
			
			if(Abs(test_value) < unc){
				if(print) WriteLine($"Found eigenvalue λ = {guess} where f(λ) = {test_value} at {i} itterations");	
				return i;
			}
			
			guess = guess - sec(guess)/diff_sec(guess);
		}
		WriteLine("No solution found !! guess = {guess}");
		return -1000000.0;
		
	}
	
	
	public static bool test_difference(vector result, double unc=1e-3, double eps=1e-3){
		int size_vector = result.size;
		for(int i=0; i<size_vector; i++){
			for(int n=i+1; n<size_vector; n++){
				if(vector.approx(result[i], result[n], unc, eps)) return false;
			}
		}
	     	return true;	
	}
	public static int get_size_eigen(vector results){
		int size = 0;
		for(int i=0; i<results.size; i++) if(results[i] > 0.001) size +=1;
		return size;
	}
	
	public static bool test_eigen_eq(vector results, matrix D, double uTu){
		for(int i=0; i<results.size; i++) {
			if(results[i] < D[i,i]) return false;
			if(results[i] > D[i,i] + uTu) return false;
		}
		return true;
	}
	

}
