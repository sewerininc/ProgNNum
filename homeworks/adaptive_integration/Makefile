DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
DIR = $(HOME)/AU/ProgNNum/matlib/matrix/

All : Out.txt error_plot.svg
	cat $<

error_plot.svg: error_plot.gpi test_point.data int_error.data app_error.data
	gnuplot $<

int_error.data: main.exe
	mono $< $@ > $@

Out.txt: main.exe 
	mono $< $@ > $@

app_error.data : main.exe
	mono $< $@ > $@

test_point.data : main.exe
	mono $< $@ > $@

main.exe : main.cs matrix.dll 
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe *.data *.svg 

