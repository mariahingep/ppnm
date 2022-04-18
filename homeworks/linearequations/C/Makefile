all: out.txt time.png
	cat out.txt

out.txt: main.exe
	mono $< > $@

time.png: out.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Time to QR factorize" \n\
	set xlabel "x" \n\
	set ylabel "y" \n\
	set key out \n\
	f(x) = a*x*x*x+b \n\
	fit f(x) "out.txt" index 0 using 1:2 via a,b \n\
	plot \
	"out.txt" index 0 using 1:2 with points title "decomposed time" \
	f(x) title "fit" \n\
	' | tee log | gnuplot

main.exe: main.cs qrgs.dll matrix.dll vector.dll
	mcs -target:exe -reference:qrgs.dll -reference:matrix.dll -reference:vector.dll $<

qrgs.dll: qrgs.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll $<

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean:
	$(RM) *.exe *.txt *.dll *.png
