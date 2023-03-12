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
		string I_str = str_matrix(n, n, false); 
		matrix I = new matrix(I_str);
		for(int i=0; i<n; i++){
		       	I[i,i] = 1;
		}
		return I;
	}
		
	public static void Main(){
	var rnd = new System.Random();
	int rndsize = rnd.Next(100,200);
	string A_str = str_matrix(rndsize, rnd.Next(200,301), true);
	matrix A = new matrix(A_str);
	matrix I1 = get_I(rndsize);
	WriteLine("Random sized matrix A where 100 < m < 199, 200 n < 300 with random values from 0-10");  
	WriteLine($"Dims A.size1(n) = {A.size1}, A.size2(m) = {A.size2}");
	string R_str = str_matrix(rndsize, rndsize, false);
	matrix R = new matrix(R_str);
	matrix Q = A.copy();
	QRGS.decomp(Q, R);
	var test_QTQ = Q.transpose()*Q;
	var test_QR = Q*R;
	WriteLine($"is R upper triangular? {upp_tri_tester(R)}, is A upper triangular? {upp_tri_tester(A)}");	
	WriteLine($"Is Q^TQ = I ? {test_QTQ.approx(I1)}");
	WriteLine($"Is QR = A ? {test_QR.approx(A)}");
	
	WriteLine("Random sized square A created from 200 to 300 with random values from 0-10");  
	WriteLine("A same sized vector b is created with random values from 0-10");  
	rndsize = rnd.Next(200,301);
	matrix I = get_I(rndsize);
	A_str = str_matrix(rndsize, rndsize, true);
	A = new matrix(A_str);
	WriteLine($"Dims A.size1 = {A.size1}, A.size2 = {A.size2}");
	R_str = str_matrix(rndsize, rndsize, false);
	R = new matrix(R_str);
	Q = A.copy();
	QRGS.decomp(Q, R);

	vector b = new vector(QRGS.vector_string(rndsize, true));
	vector x = QRGS.solve(Q, R, b);	
	vector Ax = A*x;
	WriteLine($"Is Ax = b ? {Ax.approx(b)}");
	matrix B = QRGS.inverse(Q, R);
	matrix AB = A*B;
	WriteLine($"Is AB = I ? {AB.approx(I)}");


	}
}
