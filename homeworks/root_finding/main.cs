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

	static vector newton(Func<vector,vector>f, vector x, double ε=1e-2){
		return x;
	}

	static double test_func(vector x){ return 2*x[0]*Pow(Sin(x[1]), 2);}

	static double rosenbrock(vector x){ return Pow(1-x[0], 2) + 100*Pow(x[1] - Pow(x[0], 2), 2);}

	public static void Main(string[] args){
		
		foreach(var arg in args){
			if(arg == "Out.txt"){			
				WriteLine($"hello world");
				
			}
			else if(arg == "estimated_error.data"){
			}
			else if(arg == "test_point.data"){
	
			}
			else if(arg == "app_error.data"){
		
			}
		}
	
	}
}
