# CBS C64 Budget Planner
The December 1983 issue of Compute Gazette contains an article and code listing for a budget planner that my father Charles B. Silbergleith wrote.  In honor of its 35th anniversary and for his as a birthday gift I've restored the old code to working form.  This repository contains a listing of that code as well as a runnable disk image that will work in a modern C64 Emulator.

# Demo
You can try out the application by visiting the online demo: https://ds17f.github.io/cbs-c64-budget-planner/

# Original Magazine
* [Full issue](Compute_Gazette_Issue_06_1983_Dec.pdf)
* [Relevant Content](Compute_Gazette_Issue_06_1983_Dec_Exceprt.pdf)

# Restore Process
I found a copy of [the issue of Compute Gazette at Archive.org](https://ia800604.us.archive.org/20/items/1983-12-computegazette/Compute_Gazette_Issue_06_1983_Dec.pdf).  I then keyed the listing into an editor verbatim.  This included a set of special instructions such as `{2 DOWN}` which instruct the user to literally press the down arrow two times.  There were other instructions such as `{CYN}`, again instructing the user to press the corresponding key on the keyboard, in this case to change the color to cyan.  This gave me a generally runnable program but much of the "control" instructions (clear screen, move cursor, change color, etc...) did not function.  

I read a little bit more about these control characters and discovered that C64 Basic actually contains [character codes for these control chars](https://www.c64-wiki.com/wiki/control_character).  I used some fancy regexes and some manual passes to insert the proper characters as required.  This lead to some issues with line length as the C64 limits lines to 80 characters.  I had to break the lines up adding new lines and line numbers and adjusting `goto`s when necessary.

It was clear, once I was done, why the original instructions of, "Press down arrow 2 times," made sense.  The C64 was significantly limited in terms of code space, so reducing the listing length, and the time to type the listing in, were important factors in designing the code sharing solution.  It was interesting to jump back 35 years and step into the world of open source before there was a name for the concept.  In a way, Compute Gazette was a GitHub like tool for its day.

# Repository Content
## Runnable Disk Image
[cbsBudgetPlanner1983.d64](cbsBudgetPlanner1983.d64)
For ease of use a runnable version has been written to a C64 Disk Image (type `d64`).  That image can be loaded into your emulator of choice and run using the standard: 
```
LOAD "*", 8, 1
RUN
```
Some emulators may even do this by default if you drag and drop the disk image onto a running version of the emulator.

## Original Listing
[CharlesBudgetPlanner.vb](CharlesBudgetPlanner.vb)
For posterity I've included an original exact copy of the original source code as published in the magazine.  This contains the `{2 DOWN}` style instructions as they were listed in the magazine.  

## Character Coded Listing
[CharlesBudgetPlanner_copypaste.vb](CharlesBudgetPlanner_copypaste.vb)
For completeness I've included a version of the source code which has had the control characters entered as character codes.  The file has also been lowercased so that it can be pasted directly into a C64 emulator and it should run without issue.

