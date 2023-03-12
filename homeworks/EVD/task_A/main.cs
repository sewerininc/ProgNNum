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
		
	public static void Main(){
	var rnd = new System.Random();
	int rndsize = rnd.Next(200,301);
	matrix I = get_I(rndsize);
	matrix A = rnd_matrix(rndsize, rndsize, true, true);
	WriteLine($"Generating a random symmetric matrix A from size 200-300 with the random size of {A.size1}");
	matrix aT = A.transpose();
	WriteLine($"A == A^T ? {A.approx(aT)}");
	(var w, var V) = jacobi.cyclic(A); 	
	matrix VTV = V.transpose()*V;
	matrix VVT = V*V.transpose();
	matrix D = rnd_matrix(rndsize, rndsize, false, false);
	for(int i=0;i<D.size1;i++) D[i,i] = w[i];

	matrix VTAV = V.transpose()*A*V;
	matrix VDVT = V*D*V.transpose();
	WriteLine($" V^TAV == D ? {VTAV.approx(D, 1e-3)}, (Is only true when accuracy is turned down acc=1e-3)");
	WriteLine($" VDV^T == A ? {VDVT.approx(A)}");
	WriteLine($"V^TV == I ? {VTV.approx(I)}, VV^T == I ? {VVT.approx(I)}");

	}
}
