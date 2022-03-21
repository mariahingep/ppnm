all: ms.pdf

ms.pdf: ms.tex exp_gnuplot.tex
	pdflatex $<
	pdflatex $<
#	bibtex $<
#	bibtex $<

exp_gnuplot.tex: expfig.gnuplot.gpi out.exp.txt tab.exp.txt Makefile
	gnuplot $<
	cat $@ | sed 's/\\definecolor/%\\definecolor/' > tmpfile
	mv tmpfile $@

out.exp.txt: main.exe
	mono $< > $@

main.exe: main.cs
	mcs -t:exe -out:$@ $<
