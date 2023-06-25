All : Out.txt Makefile
	cat $<

DIR = $(HOME)/AU/ProgNNum/matlib/matrix/
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)

Out.txt : main.exe  
	mono $< > $@

main.exe : main.cs matrix.dll
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe *.dll

