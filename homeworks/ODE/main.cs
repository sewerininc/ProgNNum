using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.IO;
public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public T this[int i] => data[i]; 
	public genlist(){ data = new T[0]; }
	public void add(T item){
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}
}

public static class main{
	
	
	public static (vector,vector) rkstep12(
	Func<double,vector,vector> f, /* the f from dy/dx=f(x,y) */
	double x,                    /* the current value of the variable */
	vector y,                    /* the current value y(x) of the sought function */
	double h                     /* the step to be taken */
	)
{
	vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
	vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
	vector yh = y+k1*h;              /* y(x+h) estimate */
	vector er = (k1-k0)*h;           /* error estimate */
	return (yh,er);
}	

	
	public static (genlist<double>,genlist<vector>) driver(
	Func<double,vector,vector> F, /* the f from dy/dx=f(x,y) */
	double a,                    /* the start-point a */
	vector ya,                   /* y(a) */
	double b,                    /* the end-point of the integration */
	double h=0.01,               /* initial step-size */
	double acc=0.01,             /* absolute accuracy goal */
	double eps=0.01              /* relative accuracy goal */
){
if(a>b) throw new ArgumentException("driver: a>b");
double x=a; vector y=ya.copy();
var xlist=new genlist<double>(); xlist.add(x);
var ylist=new genlist<vector>(); ylist.add(y);
do{ if(x>=b) return (xlist,ylist);/* job done */
	if(x+h>b) h=b-x;/* last step should end at b */
	var (yh,erv) = rkstep12(F,x,y,h);
	double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
	double err = erv.norm();
	if(err<=tol){ // accept step
		x+=h; y=yh;
		xlist.add(x);
		ylist.add(y);
		}
	h *= Min( Pow(tol/err,0.25)*0.95 , 2); // reajust stepsize
}while(true);
}//driver

	static vector harm(double x, vector y){/* The test of u'' = -u */
		return new vector(y[1], -y[0]);
	}

	static vector damp_harm(double x, vector y){ /* u'' = -bu' - au */
		return new vector(y[1], -0.2*y[1] - 3*y[0]);
	}
	
	static vector pend_gravity(double x, vector y){ /* u'' = -b*u' - a*sin*u */
		return new vector(y[1], -0.25*y[1] - 5.0*Sin(y[0]));
	}


	public static void Main(){
		vector int_y = new vector(0, 1);
		(var xs, var ys) = driver(harm, 0, int_y, 10);
		var harm_data = new StreamWriter("harm_data.data");
		for(int i=0; i<xs.size; i++) harm_data.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");

		vector int_y1 = new vector(1, 1);
		(var xs1, var ys1) = driver(damp_harm, 0, int_y1, 40);
		var damp_harm_data = new StreamWriter("damp_harm_data.data");
		for(int i=0; i<xs1.size; i++) damp_harm_data.WriteLine($"{xs1[i]} {ys1[i][0]} {ys1[i][1]}");

		vector int_y2 = new vector(PI-0.1, 0);
		(var xs2, var ys2) = driver(pend_gravity, 0, int_y2, 10);
		var pend_data = new StreamWriter("pend_data.data");
		for(int i=0; i<xs2.size; i++) pend_data.WriteLine($"{xs2[i]} {ys2[i][0]} {ys2[i][1]}");
	}
}
