using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{
	public static void Main(){
		int[,] arr3 = new int[3,3];
		for(int i=0;i<arr3.GetLength(0);i++){
			for(int j=0;j<arr3.GetLength(1);j++){Write($"{arr3[i,j]} ");}
			WriteLine();
		}	
		WriteLine(matrix_funcs.lngamma(2.3));	

	}
}
