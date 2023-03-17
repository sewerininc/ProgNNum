using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{
	
	public static string str_matrix(int cols, int rows, bool fill_random_value){	
	var rnd = new System.Random();
        string str_mat = "";
	if(fill_random_value){
        for(int i=0; i<rows; i++){
                for(int j=0; j<cols; j++)
                {
                        if(j == cols-1)str_mat += $"{rnd.Next(11)}";
                        else str_mat += $"{rnd.Next(11)},";
                }
                if(i != rows-1) str_mat +=$";";
	}
	}
	else{
	for(int i=0; i<rows; i++){
		for(int j=0; j<cols; j++){
			if(j == cols-1)str_mat += $"0";
			else str_mat += $"0,";
		}
		if(i != rows-1) str_mat +=$";";
	}
	}
	return str_mat;
	}

	
	public static vector lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
		int n = x.size;
		int m = fs.Length;
		matrix A = new matrix(n, m);
		vector b = new vector(n);
		for(int i=0;i<n;i++){
			b[i] = y[i] / dy[i]; 
			for(int j=0;j<m; j++) A[i, j] = fs[j](x[i]) / dy[i]; //need the f[k] here fix it stupid
		}
		matrix Q = A.copy();
		matrix R = new matrix(n, n);
		QRGS.decomp(Q, R);
		vector results = QRGS.solve(Q, R, b);	
		return results;
	}
	
	
	public static void Main(string[] args){
		
		var func = new Func<double, double>[2];
		string[] lines = System.IO.File.ReadAllLines(@"/home/msd/AU/ProgNNum/homeworks/least_squares_fit/data.txt");	
		func[0] = x => 1;
		func[1] = x => -x;
		int n = lines.Length;
		string std_vec = QRGS.vector_string(n, false);
		vector xs = new vector(std_vec);
		vector ys = new vector(std_vec);
		vector dys = new vector(std_vec);
		for(int i=0;i<n;i++){
			var words = lines[i].Split(" ");
			xs[i] = float.Parse(words[0]);
			ys[i] = Log(float.Parse(words[1]));
			dys[i] = float.Parse(words[2])/ys[i];
		}
		vector res = lsfit(func, xs, ys, dys);
		foreach(var arg in args){
			if(arg == "plotdata"){
				for(double i=xs[0]-0.5; i<xs[xs.size-1]+0.5;i+=1.0/20){
					WriteLine($"{i} {Log(res[0]-res[1]*i)}");
				}
			}
			if(arg == "actualdata"){
				for(int i = 0; i<xs.size; i++) WriteLine($"{xs[i]} {Log(ys[i])} {dys[i]/ys[i]}");	
			}
			if(arg == "half-life"){
				res.print("res = ");
				double T12 = Log(2)/res[1];
				WriteLine($"T_1/2 = {T12:e3} days. The correct value is 3.6 days");
				WriteLine($"a deiviation of {(T12-3.6)/3.6*100:e3}% os good consindering 9 datapoints was used to calculate it");
			}
		}
		


			
	}
}
