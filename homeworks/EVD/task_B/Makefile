All : rmaxplot.svg drplot.svg
	mv -t plots $^

DIR = $(HOME)/AU/ProgNNum/matlib/matrix/

rmaxplot.svg : rmax.gpi rmax.data
	gnuplot $<

drplot.svg : dr.gpi dr.data
	gnuplot $<

rmax.data : main.exe 
	mono $< -looprmax > $@

dr.data : main.exe 
	mono $< -loopdr > $@

tot.dll : jacobi.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:tot.dll

main.exe : main.cs tot.dll matrix.dll
	mcs main.cs -reference:tot.dll -reference:matrix.dll -target:exe -out:main.exe

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe tot.dll

