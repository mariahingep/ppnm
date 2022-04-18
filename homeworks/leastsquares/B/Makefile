all: out.txt fig.png

out.txt: main.exe
	mono $< > $@

fig.png: out.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Least squares" \n\
	set xlabel "t (time, days)" \n\
	set ylabel " percent activity" \n\
	set key out \n\
	plot \
	"out.txt" index 0 using 1:2:3 pointtype 7 pointsize 1 with yerrorbars title "data" \
	,"out.txt" index 1 using 1:2 with lines title "least-squares fit" \
	' | tee log | gnuplot

main.exe: main.cs lsfit.dll matrix.dll vector.dll
	mcs -target:exe -reference:lsfit.dll -reference:matrix.dll -reference:vector.dll $<

lsfit.dll: lsfit.cs matrix.dll qrgs.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:qrgs.dll -reference:vector.dll $<

qrgs.dll: qrgs.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll $<

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean:
	$(RM) *.exe *.txt *.png
