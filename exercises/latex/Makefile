all: latex.pdf

latex.pdf: latex.tex exp_plot.tex
	pdflatex $<
	pdflatex $<

exp_plot.tex: exp.gnuplot.gpi out.exp.txt tab.exp.txt Makefile
	gnuplot $<
	cat $@ | sed 's/\\definecolor/%\\definecolor/' > tmpfile
	mv tmpfile $@

out.exp.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<
