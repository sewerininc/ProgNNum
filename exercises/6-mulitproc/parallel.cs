using System;
using static System.Math;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;

static public class main{
	
	public class datas{public int a,s; public double partsum;}
	public static void harm_sum(object obj){
		var local = (datas)obj;
		local.partsum = 0;
		Parallel.For( local.a, local.s, delegate(int i){local.partsum +=1.0/i;});
	}		
	
	
	public static void Main(string[] args){
		int threads = 1;
		int to_sum = (int)2e8;
		foreach(var arg in args)
		{
			var words = arg.Split(':');
			if (words[0] == "-threads") threads = int.Parse(words[1]);
			else if (words[0] == "-to_sum") to_sum = (int)float.Parse(words[1]);
			else WriteLine($"Nothing to be done for input {words}.\nSyntaxes -threads:number or -to_sum:number");
		}	
		WriteLine($"to_sum = {to_sum}, threads = {threads}");
		
		datas[] data = new datas[threads];
		for(int i=0;i<threads;i++)
		{
			data[i] = new datas();
			data[i].a = 1 + (to_sum * i) / threads;
			data[i].s = 1 + (to_sum * (i + 1)) / threads;
			WriteLine($"i = {i}, a = {data[i].a}, s = {data[i].s}");
		}
		
		var threads_cpu = new Thread[threads];
	       	for(int i=0;i<threads;i++)
		{
			threads_cpu[i] = new Thread(harm_sum);
			threads_cpu[i].Start(data[i]);
		}
		
		for(int i=0; i<threads;i++)
		{
			threads_cpu[i].Join();
		}

		double tot_sum = 0;
		for(int i=0; i<threads;i++) tot_sum += data[i].partsum;
		WriteLine($"tot_sum = {tot_sum}");


	}

}
