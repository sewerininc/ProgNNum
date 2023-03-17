all: Out.txt
	cat $<

Out.txt: main.exe
	mono main.exe -numbers:1,2,3,4,5 > $@

main.exe: main.cs
	mcs $< -target:exe -out:$@

clean:
	rm -rf *.exe *.txt
