using static System.Console;
using static System.Math;
public class vec{
	public double x,y,z;
	public vec (double a, double b, double c){x=a; y=b; z=c;}
	public vec(){x=y=z=2;}
	public void print(string s){Write(s); WriteLine($"({x}, {y}, {z})");}
	
	public static vec operator+(vec f, vec g){return new vec(f.x+g.x, f.y+g.y, f.z+g.z);}
	
	public static vec operator-(vec f, vec g){return new vec(f.x-g.x, f.y-g.y, f.z-g.z);}
	
	public static vec operator-(vec g){return new vec(-g.x, -g.y, -g.z);}
	
	public static vec operator*(double d, vec g){return new vec(d*g.x, d*g.y, d*g.z);}
	
	public static vec operator*(vec g, double d){return new vec(d*g.x, d*g.y, d*g.z);}	
	
	public static double operator %(vec f, vec g){return f.x*g.x + f.y*g.y + f.z*g.z;}
	
	public static vec operator/(vec f, vec g){return new vec(f.y*g.z-f.z*g.y, f.z*g.x-f.x*g.z, f.x*g.y-f.y*g.x);}

	public double dot(vec other){return this%other;}

	public double norm(){return Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);}

	static bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
		if(Abs(a-b)<acc) return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps) return true;
		return false;
	}
	
	public bool approx(vec other){
		if(!approx(this.x,other.x)) return false;
		if(!approx(this.y,other.y)) return false;
		if(!approx(this.z,other.z)) return false;
		return true;
	}
	
	public override string ToString(){return $"x = {x}, y = {y}, z = {z}";}

}
