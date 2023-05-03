using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{

	

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
