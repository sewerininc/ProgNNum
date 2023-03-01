using static System.Math;

public class math_funcs{
	public static string to_print = "fra math_funcs\n";
	public static void print(){System.Console.Write(to_print);}
	//public math_funcs(string init){to_print=init;}
	//public math_funcs(){}

	public static double gamma(double x){
	///single precision gamma function (formula from Wikipedia)
	if(x<0)return PI/Sin(PI*x)/gamma(1-x); // Euler's reflection formula
	if(x<9)return gamma(x+1)/x; // Recurrence relation
	double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
	return Exp(lngamma);	
	}

	public static double lngamma(double x){
        ///single precision lngamma function (formula from Wikipedia)
	if(x<0)return double.NaN; // Euler's reflection formula
	if(x<9)return lngamma(x+1) - Log(x); // Recurrence relation
        double lgamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
        return lgamma;
	}

	public static double error(double x){
        /// Approx from dimitri from Wikipedia 
	if(x<0) return -error(-x);
	double[] a={0.254829592,-0.284496736,1.421413741,-1.453152027,1.061405429};
	double t=1/(1+0.3275911*x);
	double sum=t*(a[0]+t*(a[1]+t*(a[2]+t*(a[3]+t*a[4]))));/* the right thing */
	return 1-sum*Exp(-x*x);
	}

}
