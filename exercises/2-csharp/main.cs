using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{
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
		foreach (var i in numbers) {
			WriteLine($"lngamme({i}) = {math_funcs.lngamma(i)}");
			WriteLine($"gamme({i}) = {math_funcs.gamma(i)}");
		}
	}
}
