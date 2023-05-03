using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{

	public static bool approx(double a, double b, double acc=1e-6, double eps=1e-6){
		if(Abs(a-b)<acc)return true;
		if(Abs(a-b)/Max(Abs(a),Abs(b)) < eps)return true;
		return false;
	}


	public static void Main(){
		math_funcs.print();	
		Write("hello in main\n");
		math_funcs.to_print="hello from main from math\n";
		math_funcs.print();
		WriteLine($"sqrt2 = {Sqrt(2)}");
		WriteLine($"2^(1/5) = {Pow(2, 1/5)}");
		WriteLine($"e^pi = {Pow(E, PI)}");
		WriteLine($"pi^e = {Pow(PI, E)}");
		WriteLine($"testing \n sqrt2^2 = {Sqrt(2)*Sqrt(2)}");
		WriteLine($"(e^pi)/(e^pi) = {Pow(E, PI)/Pow(E, PI)}");
		List<int> numbers = new List<int>() {1, 2, 3, 10};
		List<double> val_gamma = new List<double>() {1, 1, 2, 362880};
		for(var k=0; k<4; k++) {
			double i = numbers[k];
			double gamma_a = math_funcs.gamma(i);
			WriteLine($"lngamme({i}) = {math_funcs.lngamma(i)}");
			WriteLine($"gamme({i}) = {gamma_a} is within 1e-6 acc? {approx(gamma_a, val_gamma[k])}");
		}
	}
}

