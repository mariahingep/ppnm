all: out.txt
	cat $<

out.txt : main.exe
	mono $< > $@

main.exe : main.cs
	mcs main.cs -target:exe -out:main.exe

clean:
	rm -f out.txt hello.exe
