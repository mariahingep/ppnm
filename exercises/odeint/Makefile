all: Out.ode.txt ode.png

ode.png: fig.ode.gpi Out.ode.txt
	gnuplot $<

Out.ode.txt: main.exe
	mono $< > $@

main.exe: main.cs matlib.dll

matlib.dll: ode.cs vector.cs
	mcs -target:library -out:./$@ $^

%.exe: %.cs
	mcs -t:exe $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

%.dll: %.cs
	mcs -t:library $(addprefix -r:,$(filter %.dll,$^)) $(filter %.cs,$^)

clean:
	$(RM) *.dll *.exe *.png *.txt log*
