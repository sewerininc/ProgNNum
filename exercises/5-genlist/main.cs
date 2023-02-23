using System;
using static System.Math;
using static System.Console;

public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public T this[int i] => data[i]; 
	public genlist(){ data = new T[0]; }
	public void add(T item){
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}
}
static public class main{
	public static void Main(string[] args){
	
	var list = new genlist<double[]>();
	
	foreach(var arg in args)
	{
		var words = arg.Split("\n");
		int n = words.Length;
		var numbers = new double[n];
		for(int i=0;i<n;i++)
		{       
			numbers[i] = double.Parse(words[i]);
		}
		list.add(numbers);
	}
	WriteLine($"list = {list}, list.size = {list.size}");	
	
	for(int i=0; i<list.size;i++)
	{
		var numbers = list[i];
		foreach(var number in numbers) WriteLine($"number = {number : 0.00e+00;-0.00e+00}");
	}


	
	}
}
