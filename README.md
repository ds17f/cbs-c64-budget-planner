# cbs-budget-planner-1983
A budget planner my father wrote in 1983 and had published in Compute Gazette Issue 6 1983.  You can find it in the archive: 

https://ia800604.us.archive.org/20/items/1983-12-computegazette/Compute_Gazette_Issue_06_1983_Dec.pdf

The VB file contains a typed out, cleaned up version of the listing in the magazine.  I made it write to floppy instead of tape because the emulator I was using could only read from tape.  I also made the color change back to default c64 light blue on termination.

It's important to note that the vb can just be pasted into an emulator (lower case it first) and then you can execute "RUN" and the program will run.  But since this is a direct copy of what was in the magazine you won't get the exact program as my dad wrote it.  You'll find that there are entries like {DOWN} in the listing.  This was an instruction that as you were keying it in you were to press the down arrow.  Similarly there are clear screen commands and color changes that you can do with keys on the keyboard.

In order to make the listing copy/paste ready, I intend to go back through it and change these entries into the corresponding character codes, for example:
PRINT CHR$(156)
will get you the purple that my dad used.  The only issue might be the limits to line length (80 chars).
(see here for more: https://www.c64-wiki.com/wiki/control_character)


The d64 disk image has a full, runnable, correct implementation using the colors and other control characters.  In addition I've added a file SAMPLE.BDG which contains the "typical budget" that my father listed in the original article.
