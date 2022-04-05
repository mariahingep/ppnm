all: Out.txt Fig.erf.png

Fig.erf.png: fig.erf.gpi erf.data.txt
	gnuplot $<

Out.txt erf.data.txt: main.exe
	mono $< 1> Out.txt 2> erf.data.txt

main.exe: main.cs integrate.dll

LIBDIR = ../../matlib #path to directory of integrate.cs
#integrate.dll: $(LIBDIR)/integrate/integrate.cs
integrate.dll: integrate.cs
	mcs -target:library -out:integrate.dll integrate.cs

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
