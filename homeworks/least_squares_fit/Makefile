All : plot.svg Out.txt
	cat Out.txt

plot.svg: eks_fit.gpi plotdata.data actualdata.data
	gnuplot $<

Out.txt: main.exe
	mono $< half-life > $@

actualdata.data: main.exe
	mono main.exe actualdata > actualdata.data

plotdata.data : main.exe 
	mono main.exe plotdata > plotdata.data

tot.dll : QRGS.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:tot.dll

main.exe : main.cs tot.dll matrix.dll
	mcs main.cs -reference:tot.dll -reference:matrix.dll -target:exe -out:main.exe

clean : 
	rm --force Out.txt main.exe tot.dll *.data *.svg 

