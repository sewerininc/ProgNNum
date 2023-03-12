using static System.Console;
using static System.Math;
public static class jacobi{
   
	public static void timesJ(matrix A, int p, int q, double theta){
		double cos=Cos(theta);
		double sin=Sin(theta);
		for(int i=0;i<A.size1;i++){
			double a_ip=A[i,p];
			double a_iq=A[i,q];
			A[i,p] = cos*a_ip - sin*a_iq;
			A[i,q] = sin*a_ip + cos*a_iq;
		}
	}

	public static void Jtimes(matrix A, int p, int q, double theta){
		double cos=Cos(theta);
		double sin=Sin(theta);
		for(int i=0;i<A.size1;i++){
			double a_ip=A[p,i];
			double a_iq=A[q,i];
			A[p,i] = cos*a_ip + sin*a_iq;
			A[q,i] = -sin*a_ip + cos*a_iq;
		}
	}


	public static vector cyclic(matrix M){
		matrix A=M.copy();
		matrix V=matrix.id(M.size1);
		vector w=new vector(M.size1);
		bool changed;
		do{
		changed=false;
			for(int p=0;p<A.size1-1;p++)
			for(int q=p+1;q<A.size1;q++){
				double apq=A[p,q], app=A[p,p], aqq=A[q,q];
				double theta=0.5*Atan2(2*apq,aqq-app);
				double c=Cos(theta),s=Sin(theta);
				double new_app=c*c*app-2*s*c*apq+s*s*aqq;
				double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
				if(new_app!=app || new_aqq!=aqq){
					changed=true;
					timesJ(A,p,q, theta); // A←A*J 
					Jtimes(A,p,q,-theta); // A←JT*A 
					timesJ(V,p,q, theta); // V←V*J	
				}
			
			}

		}while(changed);
		matrix D = V.transpose()*M*V;
		for(int i=0;i<V.size1;i++) w[i] = D[i,i];
		return w;
	}
}

