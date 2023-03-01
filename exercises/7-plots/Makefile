All: Gamma.svg Lngamma.svg Error.svg 
	mv -t all_plots $^ 

Error.svg: error.gpi error.data fac_error.data
	gnuplot $<

Lngamma.svg: lngamma.gpi lngamma.data
	gnuplot $<

Gamma.svg: gamma.gpi gamma.data factorials.data
	gnuplot $<

error.data : main.exe
	mono $< error > $@

gamma.data : main.exe
	mono $< gamma > $@

lngamma.data : main.exe
	mono $< lngamma > $@

factorials.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@

fac_error.data : Makefile
	>$@
	echo 0 0 >>$@
	echo 0.2 0.222702589 >>$@
	echo 1 0.842700793 >>$@
	echo 0.6 0.60385609 >>$@
	echo 1.3 0.934007945 >>$@
	echo -0.2 -0.222702589 >>$@
	echo -1 -0.842700793 >>$@
	echo -0.6 -0.60385609 >>$@
	echo -1.3 -0.934007945 >>$@

lib.dll: math_funcs.cs
	mcs $^ -target:library -out:$@

main.exe : main.cs lib.dll
	mcs $< -reference:lib.dll -target:exe -out:$@

clean:
	rm -rf *.txt *.exe *.dll *.data *.svg

