10 REM DEF VARIABLES 
20 SZ=100:I=-19 
30 R$=CHR$(13):TA=0 
40 DIM A$(SZ),AE(SZ) 
50 DEFFNRN(X)=INT(X*100+.5)/100 
200 REM MAINROUTINE 
210 GOSUB6000 
220 Z$="":GETZ$:IFZ$=""THENGOTO220 
230 IFZ$=CHR$(133)THENI=I+20:GOSUB1000 
235 IFZ$=CHR$(134)THENGOSUB3000 
240 IFZ$=CHR$(135)THENGOSUB5000 
245 IFZ$=CHR$(136)THENGOSUB7000 
250 IFZ$=CHR$(137)THENGOSUB2000 
255 IFZ$=CHR$(138)THENGOSUB4000 
260 IFZ$=CHR$(139)THENGOSUB6000 
265 IFZ$=CHR$(140)THENGOSUB8000 
270 IFZ$=CHR$(17)THENI=I-1:GOSUB1000 
275 IFZ$=CHR$(145)THENI=I+1:GOSUB1000 
299 GOTO220 
300 REM ACCUM TOTALS 
310 TA=0 
320 FOR J=1TOMX 
330 TA=TA+AE(J) 
340 NEXTJ 
399 RETURN 
400 REM LOAD FILES 
410 INPUT"FILE NAME";F$ 
420 IFF$="*END"THENGOSUB6000:RETURN
450 OPEN1,8,2,F$+",SEQ,READ" 
455 PRINT"{RVS}{GRN}FOUND{OFF}{BLK}";F$ 
460 INPUT#1,MX 
470 FORJ=1TOMX 
480 INPUT#1,Y,A$(J),AE(J) 
490 NEXTJ 
495 CLOSE1
499 RETURN 
500 REM SORT BY NAME 
505 IFMX=1THENGOTO599 
510 PRINT"{2 DOWN}{5 RIGHT}{RVS}SORTING{OFF}" 
520 FORJ=1TOMX-1 
530 FORK=J+1TOMX 
540 IFA$(K)>A$(J)THENGOTO590 
550 SMS=A$(K):SM=AE(K) 
560 A$(K)=A$(J) :AE(K)=AE(J) 
570 A$(J)=SM$:AE(J)=SM 
590 NEXTK 
595 NEXTJ 
599 RETURN 
1000 REM DISPLAY 
1010 IF(I<1)OR(I>MX)THENI=1 
1020 PRINT"{CLR} #"TAB(5)"{CYN}EXPENSES{BLK}"TAB(16)"{PUR}AMT{BLK}"
1030 FORJ=ITOI+19
1040 IFJ>MXTHENPRINT" ":GOTO1080
1050 PR$=STR$(AE(J)+.001):PR$=MID$(PR$,2,(LEN(PR$)-2))
1060 IFAE(J)=0THENPR$="0.00"
1065 J$=MID$(STR$(J),2)
1070 PRINTTAB(3-LEN(J$))J$;TAB(4)A$(J)TAB(21-LEN(PR$))PR$
1080 NEXTJ
1090 TA$=STR$(TA+.001)
1100 TA$=LEFT$(TA$,LEN(TA$)-1)
1110 IFTA=0THENTA$="0.00"
1120 PRINT"{CYN)TOTAL {BLK}"TA$
1999 RETURN
2000 REM ADD NEW
2010 R=MX+1:N$="":E1$=""
2020 PRINT"{CLR){3 RIGHT}ADD NEW EXPENSES"
2030 PRINT"{DOWN}{12 RIGHT)ITEM #";R
2040 INPUT"{DOWN)ITEM NAME ";N$
2050 IFN$="*END"THENGOTO2999
2055 IFLEN(N$)>10THENN$=LEFT$(N$,10)
2060 A$(R)=N$
2070 INPUT"{DOWN}ITEM AMT{2 SPACES}";E1$
2080 IFE1$="*END"THENGOTO2999
2085 IFVAL(E1$)=0THENAE(R)=0:GOTO2100
2090 AE(R)=FNRN(VAL(E1$))
2095 IFAE(R)>9999.99THENAE(R)=9999.99
2100 MX=MX+1
2110 GOTO2010
2220 MX=MX+1
2999 GOSUB500:GOSUB300:GOSUB6000:RETURN
3000 REM UPDATE
3010 PRINT "{CLR}{BLU}EXPENSE ";"{RVS}UPDATE{OFF}{BLK}"
3020 INPUT"{DOWN}ITEM # ";P1$
3025 IFP1$="*END"THENGOTO3999
3026 IF(VAL(P1$)=0)OR(VAL(P1$)<1)THENPRINT"{2 DOWN}{4 RIGHT}{PUR}{RVS}INPUT ERROR{OFF}{BLK}":GOTO3020
3027 P=INT(VAL(P1$))
3030 N$="":E1$=""
3040 IFP>SZTHENPRINT"MAX EXCEEDED":P=SZ:MX=P
3050 IFP>MXTHENMX=P
3060 PR$=STR$(AE(P) +.001):PR$=MID$(PR$,2,(LEN(PR$)-2))
3065 IFAE(P)=0THENPR$="0.00"
3070 PRINTP;TAB(4)A$(P)TAB(21-LEN(PR$))PR$
3080 INPUT"{DOWN}ITEM NAME";N$
3090 IFN$="*END"THENGOTO3999
3100 IFN$<>""THENA$(P)=N$
3105 IFLEN(A$(P))>10THENA$(P)=LEFT$(A$(P),10)
3110 INPUT"AMT ";E1$
3120 IFE1$="*END"THENGOTO3999
3125 IFE1$=""GOTO3010
3130 IF(VAL(E1$)=0)AND(E1$<>"0")THENPRINT"{2 DOWN}{3 RIGHT}{RVS}{PUR}INPUT ERRORE{OFF}{BLK}":GOTO3110
3135 IFVAL(E1$)=0THENAE(P)=0:GOTO3800
3140 AE(P)=FNRN(VAL(E1$))
3150 IFAE(P)>9999.99THENAE(P)=9999.99
3800 GOTO3010
3999 GOSUB500:GOSUB300:GOSUB6000;RETURN
4000 REM SAVE FILE
4010 PRINT"{CLR}(3 RIGHT}SAVE EXPENSE LIST"
4020 INPUT"{2 DOWN}FILE NAME";F$
4030 IFF$="*END"THENGOSUB6000:RETURN
4050 OPEN1,8,2,F$+",SEQ,WRITE"
4060 PRINT#1,MX
4070 FORJ=1TOMX
4080 PRINT#1,J;R$;A$(J)R$;AE(J);R$
4090 NEXTJ
4100 CLOSE1 :REM 108
4999 GOSUB6000:RETURN
5000 REM DELETE
5005 DT=0:TM=0
5010 PRINT"{CLR}{8 RIGHT}DELETE"
5020 S1$=""
5030 INPUT"{2 DOWN}START AT";S1$
5040 IFS1$="*END"THENGOTO5900
5050 DS=INT(VAL(S1$))
5060 S1$=""
5070 IFDS=0THENPRINT"{DOWN}{6 RIGHT}{RVS}{PUR]INPUT ERROR{OFF}{BLK}":GOTO5020
5080 S1$=""
5090 INPUT"{2 DOWN}END AT";S1$
5100 IFS1$="*END"THENGOTO5900
5110 IFS1$=""ORS1$="0"THENDE=0:GOTO5200
5120 DE=INT(VAL(S1$))
5125 IFDE>MXTHENDE=MX
5130 IFDE=>DSTHENGOTO5200
5135 PRINT"{2 DOWN}{2 RIGHT}{RVS}{PUR}0 OR NUMBER GREATER"
5140 PRINT"{2 DOWN}{2 RIGHT}THAN{OFF}[RED}";DE;"{RVS}{PUR}REQUIRED"
5150 GOTO5080
5200 IFDE=0THENDE=DS
5205 TM=DE-DS+1
5207 DT=DT+TM
5210 FORJ=DSTODE
5220 A$(J)="<9 B>":AE(J)=0 :REM "THIS LINE MIGHT NEED AN EDIT
5230 NEXTJ
5240 GOTO5010
5900 GOSUB500
5910 MX=MX-DT
5999 GOSUB300:GOSUB6000:RETURN
6000 REM OPTIONS MENU
6010 PRINT"{CLR}{7 RIGHT}{PUR}OPTIONS: {BLK}"
6020 PRINT"{7 RIGHT}(YEL)========{BLK}"
6030 PRINT"{DOWN}{RVS}{PUR}F1{OFF}{BLK}-DISPLAY EXPENSES"
6040 PRINT"{DOWN}{RVS}{PUR}F2{OFF}{BLK}-ADD NEW EXPENSES"
6050 PRINT"{DOWN}{RVS}{PUR}F3{OFF}{BLK}-UPDATE EXPENSE LIST"
6060 PRINT"[DOWN}{RVS}{PUR}F4{OFF}{BLK}-SAVE EXPENSE LIST"
6070 PRINT"[DOWN}{RVS}{PUR}F5{OFF}{BLK}-DELETE FROM LIST"
6080 PRINT"{DOWN}{RVS}{PUR}F6{OFF}{BLK}-OPTIONS SCREEN"
6090 PRINT"{DOWN}{RVS}{PUR}F7{OFF}{BLK}-LOAD/MERGE FILES"
6100 PRINT"{DOWN}{RVS}{PUR}F8{OFF}{BLK}-END"
6999 RETURN 
7000 REM LOAD/MERGE
7010 PRINT"{CLR}{6 RIGHT}LOAD/MERGE"
7020 PRINT"{DOWN}{5 RIGHT}EXPENSE FILES"
7030 INPUT"LOAD OR MERGE (L/M)";AN$
7040 IFAN$="L"THENMX=0:GOSUB400:GOTO7999
7050 IFAN$="*END"THENGOSUB6000:RETURN
7060 IFAN$<>"M"GOTO7030
7070 PRINT"{DOWN}{4 RIGHT}MERGE"
7080 INPUT"{DOWN}FILE NAME";F$
7090 IFF$="*END"THENGOSUB6000:RETURN
7120 OPEN1,8,2,F$+",SEQ,READ"
7130 INPUT#1,T1
7140 FORT2=1TOT1
7150 INPUT#1,Y,T3$,T4
7160 FORJ=1TOMX
7170 ifa$(j)=t3$thenae(j)=int(((ae(j)+t4)/2)*100)/100:t3$=""
7180 NEXTJ
7190 IFT3$<>""THENMX=MX+1:A$(MX)=T3$:AE(MX)=T4
7200 NEXT
7210 CLOSE1
7999 GOSUB500:GOSUB300:GOSUB6000:RETURN
8000 REM END OF JOB
8010 PRINT"{CLR}{4 RIGHT}END OF PROGRAM{2 DOWN}"
8020 PRINT"WOULD YOU LIKE TO SAVE (Y/N)":INPUT AN$
8030 IFAN$="*END"THENGOSUB6000:RETURN
8040 IFAN$="N"THENGOTO8060
8050 GOSUB4000
8060 PRINT"{CLR}THANK YOU"
8070 PRINT"{13 RIGHT}END"
8075 PRINT CHR$(154)
8080 END