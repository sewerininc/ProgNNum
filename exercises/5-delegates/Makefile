all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< -input:input.txt -output:$@


main.exe: main.cs
	mcs $< -target:exe -out:$@

clean: 
	rm -rf Out.txt main.exe
