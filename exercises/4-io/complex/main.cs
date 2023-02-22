using System;
using static System.Math;
using static System.Console;
static public class main{
	public static void Main(){
		WriteLine("Expression | Calculated manually | Calculated from .dll");
		complex one = new complex(1,0);
		complex i = new complex(0,1);
        	WriteLine($" sqrt(-1) | i | {cmath.sqrt(-one)}");
        	WriteLine($" sqrt(i) | (-1)^(1/4) | {cmath.sqrt(i)}");
        	WriteLine($" Exp(i) | e^i | {cmath.exp(i)}");
        	WriteLine($" exp(i*pi) | -1 | {cmath.exp(i*PI)}");
        	WriteLine($" i^i | 0.21 | {cmath.pow(i, i)}");
        	WriteLine($" log(i) | (i*π)/2 | {cmath.log(i)}");
        	WriteLine($" sin(i*pi) | i*sinh(pi) | {cmath.sin(i*PI)}");
        	WriteLine($" sinh(i) | i*sin(1) ish 0.84i| {cmath.sinh(i)}");
        	WriteLine($" cosh(i) | cos(1) ish 0.54| {cmath.cosh(i)}");
        	WriteLine($" sin(i) | i*sinh(1) ish 1.17i| {cmath.sin(i)}");
        	WriteLine($" cos(i) | cosh(1) ish 1.54 | {cmath.cos(i)}");
	}
}
