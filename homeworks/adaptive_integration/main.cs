using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
public static class main{
	
	static double integrate(Func<double,double> f, double a, double b,
			double simga=1e-8, double eps=1e-8, double f2=double.NaN, double f3=double.NaN){
		double h=b-a;
		if(double.Equals(double.NaN, f2)){ f2=f(a+2*h/6); f3=f(a+4*h/6); } // first call, no points to reuse
		double f1=f(a+h/6), f4=f(a+5*h/6);
		double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
		double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
		double err = Abs(Q-q);
		if (err <= simga+eps*Abs(Q)) return Q;
		else return integrate(f,a,(a+b)/2,simga/Sqrt(2),eps,f1,f2) + integrate(f,(a+b)/2,b,simga/Sqrt(2),eps,f3,f4);

	}

	static double sqrt(double x){ return Sqrt(x);}
	
	static double div_sqrt(double x){ return 1/Sqrt(x);}
	
	static double fourroot(double x){ return Sqrt(1-Pow(x, 2))*4;}

	static double log_sq(double x){ return Log(x)/Sqrt(x);}

	static double exp_xx(double x){ return Exp(-Pow(x,2));}

	static double expt_t(double x, double z){ return Exp(-Pow(z+(1-x)/x, 2))/Pow(x, 2);}
	
	public static bool approx(double x, double y, double acc=0.001, double eps=0.001){
		if(Abs(x-y)<acc)return true;
		if(Abs(x-y)/Max(Abs(x),Abs(y))<eps)return true;
		return false;
	}

	public static double error_func(double z){/*error function wiht integrals*/
		Func<double, double> f_exp_xx = exp_xx;
		if(z < 0.0) return -error_func(-z);
		if(z >= 0.0 & z <= 1.0) return 2/Sqrt(PI)*integrate(f_exp_xx, 0, z);
		if(z > 1.0) return 1 - 2/Sqrt(PI)*integrate(x => Exp(-Pow(z+(1-x)/x,2))/x/x, 0, 1);
		return 0.0;
	}

	public static double app_error(double x){
        /// Approx from dimitri from Wikipedia
	if(x<0) return -app_error(-x);
	double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
	double t=1/(1+0.3275911*x);
	double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
	return 1-sum*Exp(-x*x);
	}


	public static void Main(string[] args){
		
		foreach(var arg in args){
			if(arg == "Out.txt"){	
				Func<double, double> f_sqrt = sqrt;
				Func<double, double> f_div_sqrt = div_sqrt;
				Func<double, double> f_fourroot = fourroot;
				Func<double, double> f_log_sq = log_sq;
				WriteLine("Accuracy goals are simga=0.001, eps=0.001 and is tested with bool statement to the right of the value");

				double one = integrate(f_sqrt, 0, 1);
				double two = integrate(f_div_sqrt, 0, 1);
				double three = integrate(f_fourroot, 0, 1);
				double four = integrate(f_log_sq, 0, 1);
				
				WriteLine($"Integral of sqrt(x) from 0 to 1 = {one}, {approx(one, 2.0/3.0)}");
				WriteLine($"Integral of 1/sqrt(x) from 0 to 1 = {two}, {approx(two, 2.0)}");
				WriteLine($"Integral of (1-x^2)^(1/4) from 0 to 1 = {three}, {approx(three, PI)}");
				WriteLine($"Integral of sqrt(x) from 0 to 1 = {four}, {approx(four, -4.0)}");
				double sigma = 1e-8;
				double eps = 1e-8;
				WriteLine($"Checking which errorfucntion is most correct with simga={sigma}, eps={eps}");
				List<double> correct = new List<double> {
				       	-0.999593047982555041060435784260025087279651322596286579860879221, -0.966105146475310727066976261645947858681410479257636780449967846, -0.520499877813046537682746653891964528736451575757963700058805725, 0.5204998778130465376827466538919645287364515757579637000588057256, 0.9661051464753107270669762616459478586814104792576367804499678464, 0.9995930479825550410604357842600250872796513225962865798608792212
				};
				List<double> approxi = new List<double>();
				List<double> integral = new List<double>();	
				List<double> values = new List<double>();	
				for(double i=-2.5; i<=2.5; i+=1){
					integral.Add(error_func(i));
					approxi.Add(app_error(i));
					values.Add(i);
				}
				for(int i=0; i<=5; i++) WriteLine($"z = {values[i]} | Integral: {approx(correct[i], integral[i], sigma, eps)} , Approximated: {approx(correct[i], approxi[i], sigma, eps)}");
				WriteLine("With both simga and eps = 1e-6 both are true so the approximation works good unless one wants more accuracy than 1e-6 ish");
			}
			else if(arg == "int_error.data"){
				for(double i=-3; i<3; i+=1/32.0) WriteLine($"{i} {error_func(i) - 0.5}");
			}
			else if(arg == "test_point.data"){
				for(double i=-2.5; i<=2.5; i+=1) WriteLine($"{i} {error_func(i)}");
			}

			else if(arg == "app_error.data"){
				for(double i=-3; i<3; i+=1/32.0) WriteLine($"{i} {app_error(i) + 0.5}");
		
			}
		}
	
	}
}
