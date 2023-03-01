using System;
using static System.Math;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;

static public class main{
	
	public static void Main(string[] args){
		foreach(var arg in args){
			if(arg == "gamma"){
				for(double x=-5+1.0/128;x<=5;x+=1.0/64){
		       			WriteLine($"{x} {math_funcs.gamma(x)}");
				}	       
			}
			else if(arg == "lngamma"){
				for(double x=-5+1.0/128;x<=5;x+=1.0/64){
		       			WriteLine($"{x} {math_funcs.lngamma(x)}");
				}
			}
			else if(arg == "error"){
				for(double x=-5+1.0/128;x<=5;x+=1.0/64){
		       			WriteLine($"{x} {math_funcs.error(x)}");       
				}
			}
			else{
				WriteLine("Wrong input - the 3 options are (gamma, error, lngamma)");
			}
		}
	}

}
