using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{ // If this takes long time to rung look at the two performace places identified as # (First or Second) place

	public static void Main(string[] args){
	foreach(var arg in args){
		if( arg == "Out.txt"){
		var rnd = new System.Random();
		int rnd_size = 5;
		matrix D = functions.get_D(rnd_size);
		matrix u = functions.get_u(rnd_size);
		matrix uuT = u*u.transpose();
		matrix uTu = u.transpose()*u;
		matrix A = D + uuT;
		WriteLine($"The dimensions is first set as a 5x5 for matrix D and vector u is of length 5");
		WriteLine($"Values for u is random between 1 and 5");
		WriteLine($"D's diagonalvalues is random between 1 and 5 however the max possible value for u^Tu (25n) times two is added to the next d_i such this is in compliance with d_n ≤ λ_n ≤ d_n + u^Tu (the factor two is there for extra seperation) ");
				
		D.print("D = ");
		u.print("u = ");
		uuT.print("uu^T = ");
		A.print("A = D + uu^T = ");
		uTu.print("u^Tu = ");
		
		WriteLine($"Next equation 23 in the chapter eigenvalues is calculated where the roots m of the equation is the (updated) eigenvalues \nThe roots are found with the Newton-Raphson method and each guess will be d_i + u^Tu/2 \nSince all values in u is above 0 there are 5 possible solutions which will be found with the uncertainty that f(λ) = 0 +- 1e-3");
		
		
		Func<double, double> sec = x => functions.secular_eq(x, D, u);
		Func<double, double> diff_sec = x => functions.diff_secular_eq(x, D, u);
		vector results = new vector(rnd_size);
		double guess = 0.0;
		
		for(int i=0; i<rnd_size; i++){
			guess = D[i,i] + uTu[0,0]/2;		
			 results[i] = functions.get_one_root(sec, diff_sec, guess, 1e-3, true);
		}
		
		WriteLine($"The total number of found eigenvalues = {functions.get_size_eigen(results)} (should be equal to n which is {rnd_size} for this case)");
		WriteLine($"Is all n eigenvalues different ? {functions.test_difference(results)}\n");
		
		rnd_size = rnd.Next(400, 450); // Put both values down to 40, 45 if performance problems # First place
		
		WriteLine($"Next we will test the implication a bit more with a random generated n:[400;450], n = {rnd_size}");
		
		vector results_big = new vector(rnd_size);
		matrix D_big = functions.get_D(rnd_size);
		matrix u_big = functions.get_u(rnd_size);
		matrix uTu_big = u_big.transpose()*u_big;
		
		Func<double, double> sec_big = x => functions.secular_eq(x, D_big, u_big);
		Func<double, double> diff_sec_big = x => functions.diff_secular_eq(x, D_big, u_big);
		
		double guess_big = 0.0;
		
		for(int i=0; i<rnd_size; i++){
			guess_big = D_big[i,i] + uTu_big[0,0]/2;		
			results_big[i] = functions.get_one_root(sec_big, diff_sec_big, guess_big, 1e-3, false);
		}
		
		WriteLine($"The total number of found eigenvalues = {functions.get_size_eigen(results_big)}");
		WriteLine($"Is all n eigenvalues different ? {functions.test_difference(results_big)} \n");
		
		WriteLine($"This then proves that the program finds all possible (updated) eigenvalues. \nNext task is to show that the operations scale with O(n²), this will be shown on the plot 'operations_pr_n.svg'.");
		WriteLine("The sum of all itterations to find all n (update) eigenvalues is divided with n² such the plot should be a straight line if the number of operations scales with n²");
		WriteLine("The plot is linear when the matrix is reasonably large and therefore I have found the eigenvalues of A using only O(n²) operations");
		}
		if( arg == "plotdata.data" ){
		for(int i=5; i<400; i+=5){ // Put this down if to i<100 if performance problems # Second place
		
			double sum_itterations = 0;
			matrix D_data = functions.get_D(i);
			matrix u_data = functions.get_u(i);
			matrix uTu_data = u_data.transpose()*u_data;
			
			Func<double, double> sec_data = x => functions.secular_eq(x, D_data, u_data);
			Func<double, double> diff_sec_data = x => functions.diff_secular_eq(x, D_data, u_data);
			
			double guess_data = 0.0;
			for(int j=0; j<i; j++){
				guess_data = D_data[j,j] + uTu_data[0,0]/2;		
				sum_itterations += functions.get_itterations(sec_data, diff_sec_data, guess_data, 1e-3, false);
			}
			WriteLine($"{i} {sum_itterations/Pow(i, 2)}");
		}
			
		
		}
	}
		
		

	}
}














