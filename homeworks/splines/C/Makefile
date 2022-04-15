all: fig.png main.exe

fig.png: data.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Cubic spline" \n\
	set xlabel "x" \n\
	set ylabel "y" \n\
	set key out \n\
	plot \
	,"data.txt." index 0 using 1:2 with points pointtype 5 pointsize 3 title "data" \
	,"data.txt" index 1 using 1:2 with lines title "c-spline" \
	,"data.txt" index 1 using 1:3 with lines title "derivative" \
	,"data.txt" index 1 using 1:4 with lines title "integral" \
	,"data.txt" index 0 using 1:2 with points smooth csplines title "gnuplot c-spline" \
	' | tee log | gnuplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs cspline.dll
	mcs -target:exe -out:$@ -reference:cspline.dll $<

cspline.dll: cspline.cs
	mcs -target:library -out:./$@ $^

clean:
	$(RM) *.exe *.dll *.png *.txt
