all: out.txt input.txt
	cat out.txt

out.txt: fileio.exe
	mono fileio.exe -input:input.txt -output:out.txt

fileio.exe: fileio.cs
	mcs -target:exe -out:$@ $<

.PHONEY:clean
clean:
	$(RM) [Oo]ut* *.exe [Ll]og*
