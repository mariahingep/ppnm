all: fig.png main.exe

fig.png: data.txt Makefile
	echo '\
	set terminal png \n\
	set output "$@" \n\
	set title "Linear interpolation" \n\
	set xlabel "x" \n\
	set ylabel "y" \n\
	set key out \n\
	plot \
	"data.txt" index 0 using 1:2 with points pointtype 6 pointsize 2 title "data" \
	,"data.txt" index 1 using 1:2 with lines title "linterp" \
	,"data.txt" index 1 using 1:3 with lines title "integral"; \
	' | tee log | gnuplot

data.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll
	mcs -target:exe -out:$@ -reference:matlib.dll $<

matlib.dll: linterp.cs
	mcs -target:library -out:./$@ $<

clean:
	$(RM) *.exe *.dll *.png *.txt
