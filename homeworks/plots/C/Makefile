CMATHDIR = /Users/mariahingep/repos/ppnm/complex

complexgamma.gnuplot.png: erf.data.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set xlabel "Re$$(z)$$" \n\
	set ylabel "Im$$(z)$$" \n\
	set xlabel "$$|\\Gamma (z)|$$" \n\
	set title "Complex gamma function" \n\
	splot [-5:5] [-5:5] [0:10] "$<" index 0 using 1:2:3 with lines title "$$|\\Gamma(z)|$$" \n\
	'| tee log.gpi | gnuplot

erf.data.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll -out:$@ $<

cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^
