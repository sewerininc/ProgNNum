using static System.Console;
using static System.Math;
public class eps{
	
	public static int maxint(){
		int i=1; 
		while(i+1>i){i++;}
		return i;
	}

	
	public static int minint(){
		int i=1; 
		while(i-1<i){i--;}
		return i;
	}

	public static bool approx(double a, double b, double acc = 1e-9, double relative = 1e-9){
		if ( Abs(a-b) < acc) return true;
		if ( Abs(a-b)/Max(Abs(a), Abs(b)) < relative) return true;
		else return false;
	}
	
}
