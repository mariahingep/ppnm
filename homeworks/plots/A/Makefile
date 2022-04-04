erf.gnuplot.png: erf.data.txt Makefile erf.tab.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set title 'Error function' \n\
	plot [-1.5:1.5] [-1.5:1.5] '$<' index 0 using 1:2 with lines title 'erf', 'erf.tab.txt' with points pointtype 6 title 'tab' \n\
	"| tee log.gpi | gnuplot

erf.data.txt: main.exe
	mono $< > $@

all: main.exe

%.exe: %.cs
	mcs $<
