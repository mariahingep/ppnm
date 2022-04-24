all: out.txt threebody.png

out.txt: main.exe
	mono $< > $@

threebody.png: out.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Solution figure-8 problem" \n\
	set xlabel "x" \n\
	set ylabel "y" \n\
	set key out \n\
	plot [][] \
	"out.txt" index 0 using 2:3 with lines title "body 1" \
	,"out.txt" index 0 using 6:7 with lines title "body 2" \
	,"out.txt" index 0 using 10:11 with lines title "body" \
	' | tee log | gnuplot

main.exe: main.cs ode.dll matrix.dll vector.dll genlist.dll
	mcs -target:exe -reference:ode.dll -reference:matrix.dll -reference:vector.dll -reference:genlist.dll $<

ode.dll: ode.cs matrix.dll vector.dll genlist.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll -reference:genlist.dll $<

genlist.dll: genlist.cs
	mcs -target:library $<

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean: 
	$(RM) *.exe *.txt *.dll *.png
