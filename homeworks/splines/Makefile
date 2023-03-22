All : Out.txt plot.svg
	cat $<

plot.svg: explot.gpi data.data terpdata.data
	gnupot $<

Out.txt: main.exe
	mono $< > $@

data.data : main.exe
	mono $< data > $@

terpdata.data : main.exe
	mono $< terpdata > $@

main.exe : main.cs 
	mcs main.cs -target:exe -out:main.exe

clean : 
	rm --force Out.txt main.exe *.data *.svg 

