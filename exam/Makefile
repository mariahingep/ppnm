all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll vector.dll eigenvals.dll
	mcs -target:exe -reference:matrix.dll -reference:vector.dll -reference:eigenvals.dll $<

eigenvals.dll: eigenvals.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll $<

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean:
	$(RM) *.exe *.txt *.dll
