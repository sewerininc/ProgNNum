DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)

All : Out.txt #test_error_plot.svg
	cat $<

test_error_plot.svg: n_error_plot.gpi estimated_error.data
	gnuplot $<

Out.txt: main.exe 
	mono $< $@ > $@

estimated_error.data : main.exe
	mono $< $@ > $@

QRGS.dll : QRGS.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:QRGS.dll

main.exe : main.cs matrix.dll QRGS.dll 
	mcs -target:exe -out:$@ $(DLLS) $(CODE)

clean : 
	rm --force Out.txt main.exe *.data *.svg 

