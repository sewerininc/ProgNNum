all: Out.txt
	cat $<

input.txt: 
	echo 1 2 3 4 5 > $@

Out.txt: main.exe input.txt
	mono $< < input.txt > $@

main.exe: main.cs
	mcs $< -target:exe -out:$@

clean: 
	rm -rf Out.txt main.exe
