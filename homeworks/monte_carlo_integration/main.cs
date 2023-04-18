using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{
	
	static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
		int dim=a.size;
		double V=1;
		for(int i=0; i<dim; i++) V*=b[i]-a[i];
		double sum=0, sum2=0;
		var x = new vector(dim);
		var rnd = new Random();
		for(int i=0;i<N;i++){
			for(int k=0;k<dim;k++) x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);
			double fx=f(x);
			sum+=fx;
			sum2+=fx*fx;
		}
		double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
		var result=(mean*V,sigma*V/Sqrt(N));
		return result;
	}

	public static bool approx(double x, double y, double acc=0.001, double eps=0.001){
		if(Abs(x-y)<acc)return true;
		if(Abs(x-y)/Max(Abs(x),Abs(y))<eps)return true;
		return false;
	}

	static double test_func(vector x){ return 2*x[0]*Pow(Sin(x[1]), 2);}

	static double diff_func(vector x){ return Pow(1.0-Cos(x[0])*Cos(x[1])*Cos(x[2]), -1)/Pow(PI, 3);}

	public static void Main(string[] args){
		
		foreach(var arg in args){
			if(arg == "Out.txt"){			
				vector vector_a = new vector(0, 0);
				vector vector_b = new vector(1, 2*PI);
				double res_value = 0;
				double res_error = 0;
				(res_value, res_error) = plainmc(test_func, vector_a, vector_b, 10000);
				WriteLine($"The Integral calculated is 2*r*sin(theta)^2, where r goes from 0 to 1 and theta goes from 0 to 2*PI");
				WriteLine("The output should then be PI");
				WriteLine($"res_value = {res_value} +- {res_error}");

				WriteLine("Next is calculation ∫0 to π  dx/π ∫0 to π  dy/π ∫0 to π  dz/π [1-cos(x)cos(y)cos(z)]^(-1)");
				WriteLine("The value should be Γ(1/4)4/(4π3) ≈ 1.3932039296856768591842462603255");
				vector vector_c = new vector(0, 0, 0);
				vector vector_d = new vector(PI, PI, PI);
				(res_value, res_error) = plainmc(diff_func, vector_c, vector_d, 1000000);
				WriteLine($"res_value = {res_value} +- {res_error}");
				
			}
			else if(arg == "estimated_error.data"){
				vector vector_a = new vector(0, 0);
				vector vector_b = new vector(1, 2*PI);
				var actual_error = new StreamWriter("actual_error.data");
				double res_values = 0;
				double res_errors = 0;
				for(int i=10; i<5000; i+=10) {
					(res_values, res_errors) = plainmc(test_func, vector_a, vector_b, i);
					WriteLine($"{i} {res_errors}");
					actual_error.WriteLine($"{i} {Abs(res_values-PI)}");

				}
			}
			else if(arg == "test_point.data"){
	
			}
			else if(arg == "app_error.data"){
		
			}
		}
	
	}
}
