all: out.txt
	cat out.txt

out.txt: main.exe qrgs.cs
	mono $< > out.txt

main.exe: main.cs qrgs.dll  matrix.dll vector.dll
	mcs $< -target:exe -reference:qrgs.dll -reference:matrix.dll -reference:vector.dll

qrgs.dll: qrgs.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll -reference:vector.dll

matrix.dll: matrix.cs vector.dll
	mcs $< -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs $< -target:library

clean:
	$(RM) *.exe *.txt
