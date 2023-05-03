All : Out.txt
	cat $^

DIR = $(HOME)/AU/ProgNNum/matlib/matrix/


Out.txt : main.exe 
	mono main.exe > Out.txt

tot.dll : QRGS.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:tot.dll

main.exe : main.cs tot.dll matrix.dll
	mcs main.cs -reference:tot.dll -reference:matrix.dll -target:exe -out:main.exe

matrix.dll : $(DIR)vector.cs $(DIR)matrix.cs
	mcs -target:library -out:$@ $^

clean : 
	rm --force Out.txt main.exe *.dll

