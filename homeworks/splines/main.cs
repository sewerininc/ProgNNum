using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
public static class main{

	public static int binsearch(double[] x, double z){/* locates the interval for z by bisection */ 
		if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public static double linterp(double[] x, double[] y, double z){
		int i=binsearch(x,z);
		double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
		double dy=y[i+1]-y[i];
		return y[i]+dy/dx*(z-x[i]);
	}

	public static double linterpInteg(double[] x, double[] y, double z){/*calculates integral of the linear spline function*/
		return 1.0;
	}	

	public static double[] polynomion(double[] xs, double a, double b, double c){
		double[] ys = new double[xs.Length];
		for(int i=0;i<xs.Length;i++) ys[i] = a + xs[i]*b + Pow(xs[i],2)*c;
		return ys;
	}

	public static void Main(string[] args){
		double[] xs = new double[] {-5, -3, -1, 1, 3, 5};
		double[] ys = polynomion(xs, 3.0, -0.5, 0.5);
		foreach(var arg in args){
			if(arg == "terpdata"){
				for(double i=xs.Min();i<xs.Max();i+=1.0/5) WriteLine($"{i} {linterp(xs, ys, i)}");
					
			}
			if(arg == "data"){
				for(int i=0; i<xs.Length;i++) WriteLine($"{xs[i]} {ys[i]}");
			}
		}
		


			
	}
}
