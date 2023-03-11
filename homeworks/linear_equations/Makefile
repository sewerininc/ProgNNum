All : Out.txt
	cat $^

Out.txt : main.exe 
	mono main.exe > Out.txt

tot.dll : QRGS.cs matrix.dll
	mcs $< -reference:matrix.dll -target:library -out:tot.dll

main.exe : main.cs tot.dll matrix.dll
	mcs main.cs -reference:tot.dll -reference:matrix.dll -target:exe -out:main.exe

clean : 
	rm --force Out.txt main.exe tot.dll

