all: Out.txt
	cat $<

Out.txt: main.exe Makefile
	cat /dev/null > $@
	time -p mono main.exe >> $@

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*
