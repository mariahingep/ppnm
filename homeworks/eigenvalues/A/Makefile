all: out.txt
	cat out.txt

out.txt: main.exe
	mono $< > $@

main.exe: main.cs matrix.dll vector.dll jacobi.dll
	mcs -target:exe -reference:jacobi.dll -reference:matrix.dll -reference:vector.dll $<

jacobi.dll: jacobi.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll $<

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean:
	$(RM) *.exe *.txt *.png *.dll
