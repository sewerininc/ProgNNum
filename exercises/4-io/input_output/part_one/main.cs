using static System.Math;
using static System.Console;
static public class main{
	public static void Main(string[] args){
		foreach(var arg in args){
			var words=arg.Split(':');
			if(words[0]=="-numbers"){
				var numbers=words[1].Split(',');
				foreach(var num in numbers){
					double x = double.Parse(num);
					WriteLine($"{x}, {Sin(x)}, {Cos(x)}");


				}
			}
		}
	}
}
