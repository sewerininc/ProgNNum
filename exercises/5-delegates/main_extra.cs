using System;
using static System.Console;
using static System.Math;

public class genlist<T>{
	public T[] data;
	public int size => data.Length; // property
	public T this[int i] => data[i]; // indexer
	public genlist(){ data = new T[0]; }
	public void add(T item){ /* add item to the list */
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}
}

public static class main{
public static Func<double> make_fa(){
	double a=0;
	Func<double> fa = delegate(){a++;return a;};
	return fa;
}

public delegate double fun_of_3_doubles(double x, double y, double z);

public static void Main(){
	System.Func<double> fun = delegate(){return 7;};
	Func<double,double> square = delegate(double x){return x*x;};
	Action hello = delegate(){ WriteLine("hello");};
	fun_of_3_doubles f3 = delegate(double x, double y, double z){return 9;};
	Func<double,double,double,double> f4 =
		 delegate(double x, double y, double z){return 4;};
	hello();
	WriteLine($"fun()={fun()} should be equal 7");
	WriteLine($"square(2)={square(2)} should be equal 4");
	WriteLine($"f3(1,2,3)={f3(1,2,3)} should be equal 9");
	WriteLine($"f4(1,2,3)={f4(1,2,3)} should be equal 4");

	double a=0;
	Action fa = delegate(){a++;};
	fa();
	WriteLine($"a={a} should be 0 or >1<");
	fa();
	WriteLine($"a={a} should be 0 or >2<");
	fa();
	WriteLine($"a={a} should be 0 or >3<");
	fa();
	WriteLine($"a={a} should be 0 or >4<");

	Func<double> fb = make_fa();
	WriteLine($"fb()={fb()} should be 1");
	WriteLine($"fb()={fb()} should be 2");
	WriteLine($"fb()={fb()} should be 3");
	Func<double> fc = make_fa();
	WriteLine($"fc()={fc()} should be 4 or >1<");	
	
	genlist<string> list = new genlist<string>();
	list.add("hello");
	list.add("I");
	list.add("am");
	list.add("big");
	list.add("stupid");
	for (int i=0; i<list.size;i++) WriteLine(list[i]);


	}
}

