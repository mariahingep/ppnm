all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs vec.dll
	mcs -target:library -out:main.exe -reference:vec.dll main.cs

vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs

clean:
	$(RM) *.exe *.dll [Oo]ut*.txt
