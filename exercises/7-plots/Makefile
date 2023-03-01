Gamma.png: gamma.gpi plot.data
	gnuplot $<

plot.data : main.exe
	mono $< > $@

lib.dll: math_funcs.cs
	mcs $^ -target:library -out:$@


main.exe : main.cs lib.dll
	mcs $< -reference:lib.dll -target:exe -out:$@

clean:
	rm -rf *.txt *.exe *.dll *.data *.png

