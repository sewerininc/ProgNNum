all : Out.txt
	cat $<

Out.txt : initial.exe
	mono $^ > Out.txt

DIR = /home/msd/AU/ProgNNum/matlib/complex

lib.dll : $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./lib.dll $^

initial.exe : main.cs lib.dll
	mcs -reference:lib.dll -out:initial.exe $<

clean:
	rm -rf lib.dll initial.exe Out.txt
