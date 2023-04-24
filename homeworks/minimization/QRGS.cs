using static System.Console;
using static System.Math;
public static class QRGS{
   
	public static void decomp(matrix a, matrix r){/* Here A is turned into Q from A=QR and the emtpy R is filled*/
		for(int col=0; col<a.size2; col++){
			r[col, col] = a[col].norm();
			a[col]/=r[col, col];
			for(int row=col+1;row<a.size2;row++){
				r[col, row] = a[col].dot(a[row]);
				a[row]-=a[col]*r[col,row];
			}
		}
	
	}  

	public static string vector_string(int n, bool random){
		var rnd = new System.Random();
		string str_vec = "";
		for(int i=0; i<n; i++){
			if(random){
				if( i == n - 1) str_vec += $"{rnd.Next(1,11)}";
				else str_vec += $"{rnd.Next(1,11)},";
			}
			else{
				if( i == n - 1) str_vec += "0";
				else str_vec += "0,";
			}
		}
		return str_vec;
	}
	
	public static vector solve(matrix Q, matrix R, vector b){
		vector x = new vector(vector_string(Q.size2, false));
		var QTb = Q.transpose()*b;
		for(int i=Q.size2-1; i>=0; i--){
			double sums = 0.0;
			for(int j=i+1;j<Q.size2;j++){
				sums += R[i, j]*x[j];
			}
			x[i] = (QTb[i] - sums) / R[i, i];
		}

		return x;
	}
	
	public static double det(matrix R){/* only works on triangular matrixes, make a matrix A triangular with decomp*/
		double det_value = 1.0;
		for(int i=0;i<R.size2;i++){
			det_value *= R[i, i];	
		}
		return det_value;
	}

	public static matrix inverse(matrix Q, matrix R){
		matrix A = Q*R;
		matrix B = A.copy();
		vector b = new vector(vector_string(A.size2, false));
		for(int i=0;i<A.size2;i++){
			if(i==0) b[i] = 1;
			else{
				b[i-1] = 0;
				b[i] = 1;
			}
			B[i] = solve(Q, R, b);
		}
		return B;
	}

}
