using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public static class ann{
	public static int n; /* number of hidden neurons */
	
	static Func<double,double> f = x => x*Exp(-x*x); /* activation function */
	
	public static vector p; /* network parameters */
	
	public static void ann_(int n){/* constructor */}
	
	public static double response(double x){/* return the response of the network to the input signal x */
		return 1.0;
	}

	public static void train(vector x,vector y){/* train the network to interpolate the given table {x,y} */}
}

public static class main{

	static double gauss_wave(double x){ return x*Exp(-Pow(x, 2));}	

	public static void Main(string[] args){

	foreach(var arg in args){
		if(arg == "Out.txt")
		{
			WriteLine("Hello");
			ann.n = 10;
			ann.p = new vector(1,2,3);
		}
	}
	
}
}
