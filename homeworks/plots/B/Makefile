all: lngamma.gnuplot.png gamma.gnuplot.png

lngamma.gnuplot.png: lngamma.data.txt Makefile lngamma.tab.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Ln(gamma)' \n\
	plot [0:5] '$<' index 0 using 1:2 with lines title 'Ln(gamma)', 'lngamma.tab.txt' with points pointtype 6 title 'tab' \n\
	"| tee log.gpi | gnuplot

gamma.gnuplot.png: gamma.data.txt Makefile gamma.tab.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Gamma function' \n\
	plot [0:5] '$<' index 0 using 1:2 with lines title 'Gamma', 'gamma.tab.txt' with points pointtype 6 title 'tab' \n\
	"| tee log.gpi | gnuplot

lngamma.data.txt: lngamma.exe
	mono $< > $@

gamma.data.txt: gamma.exe
	mono $< > $@

%.exe: %.cs
	mcs $<
