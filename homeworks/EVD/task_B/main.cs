using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{
	
	public static matrix rnd_matrix(int cols, int rows, bool fill_random_value, bool make_symmetric){	
	/* For symmetric the cols and rows need to be the same*/
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
	matrix A = new matrix(str_mat);
	if(make_symmetric){
		for(int i=0;i<A.size1;i++){
			for(int j=0;j<A.size1;j++){
				A[i, j] = A[j, i];
			}
		}
	}

	return A;
	}
	
	
	public static bool upp_tri_tester(matrix S){ /* S has to be a square matrix*/
		bool answer = true;
		for(int i=0;i<S.size2;i++){
			for(int j=i+1;j<S.size2;j++){
				if(S[j,i] !=0 ) answer = false;
			}
		}
		return answer;
	}
	public static matrix get_I(int n){
		matrix I = rnd_matrix(n, n, false, false);
		for(int i=0; i<n; i++){
		       	I[i,i] = 1;
		}
		return I;
	}

	public static matrix get_H(double rmax, double dr){
		int npoints = (int)(rmax/dr)-1;
		vector r = new vector(npoints);
		for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
		matrix H = new matrix(npoints,npoints);
		for(int i=0;i<npoints-1;i++){
			H[i,i]  =-2;
			H[i,i+1]= 1;
			H[i+1,i]= 1;
		}
		H[npoints-1,npoints-1]=-2;
		matrix.scale(H,-0.5/dr/dr);
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];
		return H;
	}

	public static void Main(string[] args){
		double rmax=10;
		double dr=0.3;
		if(args.Length==0){
			matrix test_H = get_H(rmax, dr);
			var test_w = jacobi.cyclic(test_H);
			WriteLine($"w[0,0] = {test_w[0]}");
		}
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0] == "-rmax"){
			       	rmax = float.Parse(words[1]);
				matrix test_H = get_H(rmax, dr);
				var test_w = jacobi.cyclic(test_H);
				WriteLine($"w[0,0] = {test_w[0]}");
			}
			else if(words[0] == "-dr"){
			       	dr = float.Parse(words[1]);
				matrix test_H = get_H(rmax, dr);
				var test_w = jacobi.cyclic(test_H);
				WriteLine($"w[0,0] = {test_w[0]}");
			}
			else if(words[0] == "-looprmax") {
				for(rmax=2.5; rmax<15;rmax+=0.5){
					matrix H = get_H(rmax, dr);
					var w = jacobi.cyclic(H);
					WriteLine($"{rmax} {w[0]}");
				}
			}
			else if(words[0] == "-loopdr"){
				for(dr=0.05; dr<2;dr+=0.05){
					matrix H = get_H(rmax, dr);
					var w = jacobi.cyclic(H);
					WriteLine($"{dr} {w[0]}");
				}
			}
			else WriteLine("Wrong input. Default input '-rmax:10 -dr:0.3'");
		}

	}
}
