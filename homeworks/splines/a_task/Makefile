All : Out.txt const_plot.svg rnd_plot.svg Makefile
	cat $<

rnd_plot.svg: rndplot.gpi rnddata.data rndterpdata.data
	gnuplot $<

rnddata.data: main.exe
	mono $< rnddata > $@

rndterpdata.data: main.exe rnddata.data
	mono $< rndterpdata > $@

const_plot.svg: explot.gpi cdata.data cterpdata.data
	gnuplot $<

Out.txt: main.exe rnddata.data
	mono $< test > $@

cdata.data : main.exe
	mono $< cdata > $@

cterpdata.data : main.exe
	mono $< cterpdata > $@

main.exe : main.cs 
	mcs main.cs -target:exe -out:main.exe

clean : 
	rm --force Out.txt main.exe *.data *.svg 

