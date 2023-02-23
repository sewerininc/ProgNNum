all: Out.txt
	cat $<

Out.txt: main.exe
	mono main.exe $$(cat inputfile) > Out.txt

main.exe: main.cs
	mcs $< -target:exe -out:$@

clean: 
	rm -rf Out.txt main.exe
