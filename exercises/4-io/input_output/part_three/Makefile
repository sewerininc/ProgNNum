all: out.txt
	cat $<

out.txt: main.exe
	mono main.exe -input:input.txt -output:out.txt

main.exe: main.cs
	mcs $< -target:exe -out:$@

clean: 
	rm -rf Out.txt main.exe
