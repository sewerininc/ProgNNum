All : plot.svg Out.txt
	cat Out.txt

DIR = $(HOME)/AU/ProgNNum/matlib/matrix/

plot.svg: eks_fit.gpi plotdata.data actualdata.data plotdata_minus.data plotdata_plus.data
	gnuplot $<

Out.txt: main.exe
	mono $< half-life > $@

actualdata.data: main.exe
	mono main.exe actualdata > actualdata.data

plotdata_minus.data : main.exe 
	mono main.exe plotdata_minus > $@

plotdata_plus.data : main.exe 
	mono main.exe plotdata_plus > $@

plotdata.data : main.exe 
	mono main.exe plotdata > plotdata.data

tot.dll : QRGS.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:tot.dll

main.exe : main.cs tot.dll matrix.dll
	mcs main.cs -reference:tot.dll -reference:matrix.dll -target:exe -out:main.exe

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe *.dll *.data *.svg 

