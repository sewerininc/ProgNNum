using System;
using static System.Math;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;

static public class main{
	
	public static void Main(){
		for(double x=-5+1.0/128;x<=5;x+=1.0/5){
		       WriteLine($"{x} {math_funcs.gamma(x)}");
		}	       

	}

}
