CMATHDIR = /Users/mariahingep/repos/ppnm/complex

all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll -out:$@ $<

cmath.dll : $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^ # note "./" in front of cmath.dll
