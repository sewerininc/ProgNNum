using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
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

	public static double linterpInteg(double[] x, double[] y, double z){/*
		calculates integral of the linear spline function
		x needs to be sorted such lowest value in x[0]
		*/
		double yz = linterp(x, y, z);
		double int_val = 0;
		for(int i=0;i<x.Length-1;i++){
			if(x[i+1] >= z){
				double b = (yz-y[i])/(z-x[i]);
				double a = y[i]-b*x[i];	
				int_val += -1/2.0*(x[i]-z)*(2*a+b*(x[i]+z));
				break;
			}
			else{	
				double b = (y[i+1]-y[i])/(x[i+1]-x[i]);
				double a = y[i]-b*x[i];	
				int_val += -1/2.0*(x[i]-x[i+1])*(2*a+b*(x[i]+x[i+1]));
			}
		}
		return int_val;
	}	
	typedef struct { int n ; double ∗x , ∗y , ∗b , ∗ c ; } q s p l i n e ;
s−>b = (double ∗) m all oc ( ( n−1)∗ s i z e o f (double ) ) ; // b i
s−>c = (double ∗) m all oc ( ( n−1)∗ s i z e o f (double ) ) ; // c i
s−>x = (double ∗) m all oc ( n∗ s i z e o f (double ) ) ; // x i
s−>y = (double ∗) m all oc ( n∗ s i z e o f (double ) ) ; // y i
s−>n = n ; fo r ( int i =0; i<n ; i ++){s−>x [ i ]=x [ i ] ; s−>y [ i ]=y [ i ] ; }
int i ; double p [ n−1] , h [ n −1]; //VLA from C99
fo r ( i =0; i<n−1; i ++){h [ i ]=x [ i +1]−x [ i ] ; p [ i ]=( y [ i +1]−y [ i ] ) / h [ i ] ; }
s−>c [ 0 ] = 0 ; // r e c u r s i o n up :
fo r ( i =0; i<n−2; i++)s−>c [ i +1]=(p [ i +1]−p [ i ]−s−>c [ i ] ∗ h [ i ] ) / h [ i + 1];
s−>c [ n−2]/=2; // r e c u r s i o n down :
fo r ( i=n−3; i >=0;i −−)s−>c [ i ]=( p [ i +1]−p [ i ]−s−>c [ i +1]∗h [ i +1])/ h [ i ] ;
fo r ( i =0; i<n−1; i++)s−>b [ i ]=p [ i ]−s−>c [ i ] ∗ h [ i ] ;
return s ; }
double q s p l i n e e v a l ( q s p l i n e ∗s , double z ){ // e v a l u a t e s s ( z )
a s s e r t ( z>=s−>x [ 0 ] && z<=s−>x [ s−>n − 1] );
int i =0, j=s−>n−1; // b i n a r y se a rc h :
while ( j−i >1){ int m=( i+j ) / 2 ; i f ( z>s−>x [m] ) i=m; e l s e j=m; }
double h=z−s−>x [ i ] ;
return s−>y [ i ]+h∗( s−>b [ i ]+h∗s−>c [ i ] ) ; }


	public static double[] polynomion(double[] xs, double a, double b, double c){
		double[] ys = new double[xs.Length];
		for(int i=0;i<xs.Length;i++) ys[i] = a + xs[i]*b + Pow(xs[i],2)*c;
		return ys;
	}

	public static void Main(string[] args){
		double[] xs = new double[] {0, 3, 5, 7, 9};
		double[] ys = new double[] {1, 1, 1, 1, 1};
		int n = 21;
		double[] rndxs = new double[n];
		for(int i=0; i<n;i++) rndxs[i]=i-10.0;
		double[] rndys = new double[n];
		var rnd = new System.Random();
		for(int i=0; i<n;i++) rndys[i]=rnd.Next(21)-10;
		foreach(var arg in args){
			if(arg == "cterpdata"){
				for(double i=xs.Min();i<=xs.Max();i+=1.0/20) WriteLine($"{i} {linterp(xs, ys, i)}");		
			}
			if(arg == "rndterpdata"){
				var rnd_data = File.ReadAllText("rnddata.data").Split("\n");
				for(int i =0; i<rnd_data.Length-1; i++){
					var xys = rnd_data[i].Split(' ');
				       	rndxs[i] = Double.Parse(xys[0]);
					rndys[i] = Double.Parse(xys[1]);
				}
				for(double i=rndxs.Min();i<=rndxs.Max();i+=1.0/20) WriteLine($"{i} {linterp(rndxs, rndys, i)}");
			}	
			if(arg == "rnddata"){
				for(int i=0; i<rndxs.Length;i++) WriteLine($"{rndxs[i]} {rndys[i]}");
			}
			if(arg == "cdata"){
				for(int i=0; i<xs.Length;i++) WriteLine($"{xs[i]} {ys[i]}");
			}
			if(arg == "test"){
				var rnd_data = File.ReadAllText("rnddata.data").Split("\n");
				for(int i =0; i<rnd_data.Length-1; i++){
					var xys = rnd_data[i].Split(' ');
				       	rndxs[i] = Double.Parse(xys[0]);
					rndys[i] = Double.Parse(xys[1]);
				}	
				WriteLine($"Integral of constant (const_plot.svg) function y=1 from 0 to 2.1 = {linterpInteg(xs, ys, 2.1)}");
				WriteLine($"Integral of random points (rand_plot.svg) from -10 to 5.3 = {linterpInteg(rndxs, rndys, 5.3)}");
			}
		}
		


			
	}
}
