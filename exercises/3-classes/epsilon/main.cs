using System;
using static System.Console;
using static System.Math;
public static class main{
	public static void Main(){
	
	//WriteLine($"{eps.maxint()}");
		
	int maxl = eps.maxint();
	int minl = eps.minint();

	WriteLine($"max int with loop = {maxl}, with int.MaxValue = {int.MaxValue}, maxl==int.Max? {maxl==int.MaxValue}");
	
	WriteLine($"min int with loop = {minl}, with int.MinValue = {int.MinValue}, minl==int.Min? {minl==int.MinValue}");
	
	double k = 1;
	while(1+k!=1){k/=2;}
	WriteLine($"k before k*=2, {k}");	
	k*=2;
	WriteLine($"double k = {k}, Pow(2,-52) = {Pow(2,-52)}, equal? {k==Pow(2,-52)}");

	float j=1F;
       	while((float)(1F+j) != 1F){j/=2F;} 
	j*=2F;	
	WriteLine($"float j = {j}, Pow(2,-23) = {Pow(2,-23)}, equal? {j==Pow(2,-23)}");
	
	int n=(int)1e6;
	double epsilon = Pow(2,-52);
	double tiny = epsilon/2;

	double sum_a = 1; 
	for(int i=0;i<n;i++){sum_a+=tiny;}
	WriteLine($"1 + tiny + tiny... = {sum_a}");

	double sum_b = 0; 
	for(int i=0;i<n;i++){sum_b+=tiny;}
	sum_b += 1;
	WriteLine($"...tiny + tiny + 1 = {sum_b}");
	
	WriteLine("The difference originates from the fact that when one tiny thing is added to one it is approximated to one all over the forloop, but when a tiny number is added to a tiny number the values are added together which can not be approximated to zero");
	
	double long_b = 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1 + 0.1;
	double short_b = 0.1*8;

	WriteLine($"long_b = {long_b:e15}");
	WriteLine($"short_b = {short_b:e15}");
	WriteLine($"long_b == short_b ? {short_b==long_b}");
	WriteLine($"approx(a,b) ? {eps.approx(long_b,short_b)}");
	
	


	}
}

