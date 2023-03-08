using static System.Math;

public class math_funcs{

	public static double lngamma(double x){
        ///single precision lngamma function (formula from Wikipedia)
	if(x<0)return double.NaN; // Euler's reflection formula
	if(x<9)return lngamma(x+1) - Log(x); // Recurrence relation
        double lgamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
        return lgamma;
	}

	


}
