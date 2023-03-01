All: Gamma.svg Lngamma.svg Error.svg 
	mv -t all_plots $^ 

Error.svg: error.gpi error.data
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
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
	echo 6 $$(echo '6*120' | bc) >>$@

lib.dll: math_funcs.cs
	mcs $^ -target:library -out:$@

main.exe : main.cs lib.dll
	mcs $< -reference:lib.dll -target:exe -out:$@

clean:
	rm -rf *.txt *.exe *.dll *.data *.svg

