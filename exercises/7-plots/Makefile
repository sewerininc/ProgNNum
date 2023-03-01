All: Gamma.svg Lngamma.svg Error.svg 
	mv -t all_plots $^ 

Error.svg: error.gpi error.data
	gnuplot $<

Lngamma.svg: lngamma.gpi lngamma.data
	gnuplot $<

Gamma.svg: gamma.gpi gamma.data
	gnuplot $<

error.data : main.exe
	mono $< error > $@

gamma.data : main.exe
	mono $< gamma > $@

lngamma.data : main.exe
	mono $< lngamma > $@

lib.dll: math_funcs.cs
	mcs $^ -target:library -out:$@

main.exe : main.cs lib.dll
	mcs $< -reference:lib.dll -target:exe -out:$@

clean:
	rm -rf *.txt *.exe *.dll *.data *.svg

