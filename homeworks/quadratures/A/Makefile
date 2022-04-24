all: out.txt erf.png
	cat out.txt

erf.png: erf.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "error function" \n\
	set xlabel "x" \n\
	set ylabel "erf(x)" \n\
	set key out \n\
	set grid \n\
	plot [][] \
	"erf.txt" index 0 using 1:2 with lines title "integrated" \
	,"erfwiki.txt" index 0 using 1:2 with points title "table values" \
	' | tee log | gnuplot

out.txt: main.exe
	mono $< > $@

main.exe: main.cs integrator.dll
	mcs -target:exe -reference:integrator.dll $<

integrator.dll: integrator.cs
	mcs -target:library $<

clean:
	$(RM) *.exe *.txt *.dll *.png
