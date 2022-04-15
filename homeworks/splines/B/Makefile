fig.png: data.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Quadratic spline" \n\
	set xlabel "x" \n\
	set ylabel "y" \n\
	set key out \n\
	plot \
	"data.txt" index 0 using 1:2 with points pointtype 5 pointsize 3 title "data" \
	,"data.txt" index 1 using 1:2 with lines title "q-spline" \
	,"data.txt" index 1 using 1:3 with lines title "derivative" \
	,"data.txt" index 1 using 1:4 with lines title "integral" \
	' | tee log | gnuplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs math.dll
	mcs -target:exe -reference:math.dll $<

math.dll: qspline.cs integrate.cs
	mcs -target:library -out:./$@ $^

clean:
	$(RM) *.exe *.dll *.png *.txt
