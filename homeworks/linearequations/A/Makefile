all: out.txt
	cat out.txt

out.txt: main.exe qrgs.cs
	mono $< > out.txt

main.exe: main.cs qrgs.dll  math.dll
	mcs $< -target:exe -reference:qrgs.dll -reference:math.dll

qrgs.dll: qrgs.cs math.dll
	mcs $< -target:library -reference:math.dll

math.dll: matrix.cs vector.cs
	mcs $< -target:library

clean:
	$(RM) *.exe *.txt
