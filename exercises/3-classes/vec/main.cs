using System;
using static System.Console;
public static class main{
	public static void Main(){
	vec u = new vec(1, 2, 3);
	vec g = new vec(2, 3, 4);
	u.print("u=");
	g.print("g=");
	(u+g).print("u+g");
	(-u).print("-u=");
	(u-g).print("u-g=");
	vec w = u*2;
	w.print("u*2=");
	(2*u).print("2*u=");
	WriteLine($"u.dot(g) = {u.dot(g)}");	
	(u/g).print("u X g=");
	WriteLine($"u.norm()={u.norm()}");
	WriteLine($"u.approx(g)={u.approx(g)}");

	WriteLine($"u.ToString(): {u.ToString()}");
	WriteLine($"g.ToString(): {g.ToString()}");
	
	WriteLine($"u.approx(g) = {u.approx(g)}");
	WriteLine($"u.x+0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1 == u.x+0.1*8 {u.x+0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1 == u.x+0.1*8}");	
	
	u.x = u.x +0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	vec k = u;
	k.x = k.x + 0.1*8;

	WriteLine($"u.x = u.x +0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;\nk.x = k.x + 0.1*8 \nu.approx(k) = {u.approx(k)}");


	}
}

