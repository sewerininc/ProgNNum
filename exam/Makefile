All : Out.txt operations_pr_n.svg
	cat $<

DIR = $(HOME)/AU/ProgNNum/matlib/matrix/
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)

operations_pr_n.svg: operations_plot.gpi plotdata.data
	gnuplot $<

Out.txt : main.exe  
	mono $< $@ > $@

functions.dll : functions.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:$@

plotdata.data : main.exe
	mono $< $@ > $@

main.exe : main.cs matrix.dll functions.dll
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe *.dll

