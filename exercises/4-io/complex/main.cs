using System;
using static System.Math;
using static System.Console;
static public class main{
	public static void Main(){
		WriteLine("Expression | Calculated manually | Calculated from .dll");
		complex one = new complex(1,0);
		complex i = new complex(0,1);
		complex sq = cmath.sqrt(-one);
		complex ln = cmath.log(i);
		complex sqi = cmath.sqrt(i);
		complex ii = cmath.pow(i, i);
        	WriteLine($" sqrt(-1) | i | {sq} ? {sq.approx(+-i)}");
        	WriteLine($" sqrt(i) | 1/sqrt(2) + i/sqrt(2) | {sqi.approx(1/cmath.sqrt(2)+i/cmath.sqrt(2))}");
        	WriteLine($" Exp(i) | e^i | {cmath.exp(i)}");
        	WriteLine($" exp(i*pi) | -1 | {cmath.exp(i*PI)}");
        	WriteLine($" i^i | 0.208 | {ii.approx(0.2078795763507619)} (more decimals added in the approx otherwise it will be false)");
        	WriteLine($" log(i) | (i*π)/2 | {ln} ? {ln.approx((i*PI)/2)}");
        	WriteLine($" sin(i*pi) | i*sinh(pi) | {cmath.sin(i*PI)}");
        	WriteLine($" sinh(i) | i*sin(1) ish 0.84i| {cmath.sinh(i)}");
        	WriteLine($" cosh(i) | cos(1) ish 0.54| {cmath.cosh(i)}");
        	WriteLine($" sin(i) | i*sinh(1) ish 1.17i| {cmath.sin(i)}");
        	WriteLine($" cos(i) | cosh(1) ish 1.54 | {cmath.cos(i)}");
	}
}
