DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
DIR = $(HOME)/AU/ProgNNum/matlib/matrix/


All : Out.txt test_error_plot.svg
	cat $<

test_error_plot.svg: n_error_plot.gpi estimated_error.data
	gnuplot $<

Out.txt: main.exe 
	mono $< $@ > $@

estimated_error.data : main.exe
	mono $< $@ > $@

main.exe : main.cs matrix.dll 
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe *.data *.svg 

