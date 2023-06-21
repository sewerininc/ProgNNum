using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{

	public static matrix get_D(int n){
                matrix D = new matrix(n, n);
		var rnd = new System.Random();
                for(int i=0; i<n; i++){
                        D[i,i] = rnd.Next(1, 10);
                }
                return D;
        }

	public static matrix get_u(int n){
		matrix u = new matrix(n, 1);
		var rnd = new System.Random();
		for(int i=0; i<n; i++){
			u[i, 0] = rnd.Next(1, 10);
		}
		return u;
	}

	public static void Main(){
		int rnd_size = 3;
		matrix D = get_D(rnd_size);
		D.print("D = ");
		matrix u = get_u(rnd_size);
		u.print("u = ");
		matrix uuT = u*u.transpose();
		uuT.print("uu^T = ");
		matrix A = D + uuT;
		A.print("A = ");	



	}
}
