CMATHDIR = /Users/mariahingep/repos/ppnm/complex

complexgamma.gnuplot.png: erf.data.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set xlabel "$$Re(z)$$" \n\
	set ylabel "$$Im(z)$$" \n\
	set zlabel "$$|Gamma(z)|$$" \n\
	set title "Gamma function" \n\
	set key below \n\
	splot [-5: 5] [-5: 5] [0: 6] "$<" index 0 using 1:2:3 with lines title "Gamma function" \n\
	'| tee log.gpi | gnuplot

erf.data.txt: main.exe
	mono $< > $@

main.exe: main.cs cmath.dll
	mcs -target:exe -reference:cmath.dll -out:$@ $<

cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^
