DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
DIR = $(HOME)/AU/ProgNNum/matlib/matrix/

All : Out.txt higgs.txt higgs_fit.svg
	cat $<
	cat higgs.txt

higgs_fit.svg: plot_higgs.gpi fitdata.data fitsdata.data
	gnuplot $<

fitdata.data: main.exe 
	mono $< $@ > $@

fitsdata.data: main.exe
	mono $< $@ > $@

higgs.txt: main.exe
	mono $< $@ > $@

Out.txt: main.exe 
	mono $< $@ > $@

QRGS.dll : QRGS.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:QRGS.dll

main.exe : main.cs matrix.dll QRGS.dll 
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe estimated_error.data *.svg *.dll 

