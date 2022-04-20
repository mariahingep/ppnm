all: out.txt hydrogen.png

out.txt: main.exe
	mono $< > $@

hydrogen.png: out.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set multiplot \n\
	set key out \n\
	set grid \n\

	set title "Ground state energy, convergence with rmax" \n\
	set xlabel "rmax" \n\
	set ylabel "energy" \n\
	set origin -5,4 \n\
	plot[][-0.51:-0.25] \
	"out.txt" index 0 using 1:3 with lines col red title "exact energy" \
	,"out.txt" index 1 using 1:2 with lines col blue title "eigenval energy" \n\

	set title "First excited state, convergence with rmax" \n\
	set xlabel "rmax" \n\
	set ylabel "energy" \n\
	set origin 5,4 \n\
	plot [5:][:0] \
	"out.txt" index 1 using 1:3 with lines col red title "exact energy" \
	,"out.txt" index 1 using 1:2 with lines col blue title "eigenval energy" \n\

	set title "Ground state energy, convegence with dr" \n\
	set xlabel "dr" \n\
	set ylabel "energy" \n\
	set origin -5,-4 \n\
	plot [][-0.51:-0.2] \
	"out.txt" index 2 using 1:3 with lines col red title "exact energy" \
	,"out.txt" index 2 using 1:2 with lines col blue title "eigenval energy" \n\

	set title "First excited state, convergence with dr" \n\
	set xlabel "dr" \n\
	set ylabel "energy" \n\
	set origin 5,-4 \n\
	plot [][:0] \
	"out.txt" index 3 using 1:3 with lines col red title "exact energy" \
	,"out.txt" index 3 using 1:2 with lines col blue title "eigenval energy" \n\
	unset multiplot \n\
	' | tee log | gnuplot

main.exe: main.cs jacobi.dll matrix.dll vector.dll
	mcs -target:exe -reference:jacobi.dll -reference:matrix.dll -reference:vector.dll $<

jacobi.dll: jacobi.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll	$<

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean:
	$(RM) *.exe *.dll *.txt
