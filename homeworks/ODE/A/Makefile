all: out.txt scipyodeint.png oscillator.png
	cat out.txt

scipyodeint.png: scipyode.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Solution scipy.odeint example" \n\
	set xlabel "t" \n\
	set ylabel "numerical solution" \n\
	set key out \n\
	set grid \n\
	set xrange [0:10] \n\
	plot \
	"scipyode.txt" index 0 using 1:2 with lines title "theta(t)" \
	,"scipyode.txt" index 0 using 1:3 with lines title "omega(t)" \
	' | tee log | gnuplot

oscillator.png: oscillator.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Solution harmonic oscillator with y0=(0,1)" \n\
	set xlabel "t" \n\
	set ylabel "numerical solution" \n\
	set key out \n\
	set grid \n\
	set xrange [0:10] \n\
	plot \
	"oscillator.txt" index 0 using 1:2 with lines title "sin(t)" \
	,"oscillator.txt" index 0 using 1:3 with lines title "cos(t)" \
	' | tee log | gnuplot

out.txt: main.exe
	mono $< > $@

main.exe: main.cs ode.dll matrix.dll vector.dll
	mcs -target:exe -reference:ode.dll -reference:matrix.dll -reference:vector.dll $<

ode.dll: ode.cs matrix.dll vector.dll
	mcs -target:library -reference:matrix.dll -reference:vector.dll $<

matrix.dll: matrix.cs vector.dll
	mcs -target:library -reference:vector.dll $<

vector.dll: vector.cs
	mcs -target:library $<

clean: 
	$(RM) *.exe *.txt *.png *.dll
