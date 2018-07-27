10 rem def variables 
20 sz=100:i=-19 
30 r$=chr$(13):ta=0 
40 dim a$(sz),ae(sz) 
50 deffnrn(x)=int(x*100+.5)/100 
200 rem mainroutine 
210 gosub6000 
220 z$="":getz$:ifz$=""thengoto220 
230 ifz$=chr$(133)theni=i+20:gosub1000 
235 ifz$=chr$(134)thengosub3000 
240 ifz$=chr$(135)thengosub5000 
245 ifz$=chr$(136)thengosub7000 
250 ifz$=chr$(137)thengosub2000 
255 ifz$=chr$(138)thengosub4000 
260 ifz$=chr$(139)thengosub6000 
265 ifz$=chr$(140)thengosub8000 
270 ifz$=chr$(17)theni=i-1:gosub1000 
275 ifz$=chr$(145)theni=i+1:gosub1000 
299 goto220 
300 rem accum totals 
310 ta=0 
320 for j=1tomx 
330 ta=ta+ae(j) 
340 nextj 
399 return 
400 rem load files 
410 input"file name";f$ 
420 iff$="*end"thengosub6000:return
450 open1,8,2,f$+",seq,read" 
455 printchr$(18)chr$(30)"found"chr$(146)chr$(144);f$ 
460 input#1,mx 
470 forj=1tomx 
480 input#1,y,a$(j),ae(j) 
490 nextj 
495 close1
499 return 
500 rem sort by name 
505 ifmx=1thengoto599 
510 printchr$(17)chr$(17)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
511 printchr$(18)"sorting"chr$(146) 
520 forj=1tomx-1 
530 fork=j+1tomx 
540 ifa$(k)>a$(j)thengoto590 
550 sm$=a$(k):sm=ae(k) 
560 a$(k)=a$(j) :ae(k)=ae(j) 
570 a$(j)=sm$:ae(j)=sm 
590 nextk 
595 nextj 
599 return 
1000 rem display 
1010 if(i<1)or(i>mx)theni=1 
1020 printchr$(147)" #"tab(5)chr$(159)"expenses"chr$(144)tab(16)chr$(156)"amt";
1021 printchr$(144)
1030 forj=itoi+19
1040 ifj>mxthenprint" ":goto1080
1050 pr$=str$(ae(j)+.001):pr$=mid$(pr$,2,(len(pr$)-2))
1060 ifae(j)=0thenpr$="0.00"
1065 j$=mid$(str$(j),2)
1070 printtab(3-len(j$))j$;tab(4)a$(j)tab(21-len(pr$))pr$
1080 nextj
1090 ta$=str$(ta+.001)
1100 ta$=left$(ta$,len(ta$)-1)
1110 ifta=0thenta$="0.00"
1120 printchr$(159)"total "chr$(144)ta$
1999 return
2000 rem add new
2010 r=mx+1:n$="":e1$=""
2020 printchr$(147)chr$(29)chr$(29)chr$(29)"add new expenses"
2030 printchr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
2031 printchr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
2032 printchr$(17)"item #";r;chr$(17)
2040 input"item name ";n$
2050 ifn$="*end"thengoto2999
2055 iflen(n$)>10thenn$=left$(n$,10)
2060 a$(r)=n$
2070 printchr$(17);
2071 input"item amt  ";e1$
2080 ife1$="*end"thengoto2999
2085 ifval(e1$)=0thenae(r)=0:goto2100
2090 ae(r)=fnrn(val(e1$))
2095 ifae(r)>9999.99thenae(r)=9999.99
2100 mx=mx+1
2110 goto2010
2220 mx=mx+1
2999 gosub500:gosub300:gosub6000:return
3000 rem update
3010 printchr$(147)chr$(31)" expense ";chr$(18)"update"chr$(146)chr$(144);
3020 printchr$(13)
3021 input"item # ";p1$
3025 ifp1$="*end"thengoto3999
3026 if(val(p1$)=0)or(val(p1$)<1)thenprintchr$(13)chr$(13)chr$(29)chr$(29);
3027 if(val(p1$)=0)or(val(p1$)<1)thenprintchr$(29)chr$(29)chr$(156)chr$(18);
3028 if(val(p1$)=0)or(val(p1$)<1)thenprint"input error"chr$(146)chr$(144);"
3029 if(val(p1$)=0)or(val(p1$)<1)thengoto3020
3030 p=int(val(p1$))
3032 n$="":e1$=""
3040 ifp>szthenprint"max exceeded":p=sz:mx=p
3050 ifp>mxthenmx=p
3060 pr$=str$(ae(p) +.001):pr$=mid$(pr$,2,(len(pr$)-2))
3065 ifae(p)=0thenpr$="0.00"
3070 printp;tab(4)a$(p)tab(21-len(pr$))pr$chr$(17)
3080 input"item name";n$
3090 ifn$="*end"thengoto3999
3100 ifn$<>""thena$(p)=n$
3105 iflen(a$(p))>10thena$(p)=left$(a$(p),10)
3110 input"amt ";e1$
3120 ife1$="*end"thengoto3999
3125 ife1$=""goto3010
3130 if(val(e1$)=0)and(e1$<>"0")thenprintchr$(13)chr$(13)chr$(29)chr$(29);
3131 if(val(e1$)=0)and(e1$<>"0")thenprintchr$(29)chr$(18)chr$(156)chr$(18);
3133 if(val(e1$)=0)and(e1$<>"0")thenprint"input error"chr$(146)chr$(144)
3134 if(val(e1$)=0)and(e1$<>"0")thengoto3110
3135 ifval(e1$)=0thenae(p)=0:goto3800
3140 ae(p)=fnrn(val(e1$))
3150 ifae(p)>9999.99thenae(p)=9999.99
3800 goto3010
3999 gosub500:gosub300:gosub6000;return
4000 rem save file
4010 printchr$(147)chr$(29)chr$(29)chr$(29)"save expense list"chr$(13)chr$(13);
4020 input"file name";f$
4030 iff$="*end"thengosub6000:return
4050 open1,8,2,f$+",seq,write"
4060 print#1,mx
4070 forj=1tomx
4080 print#1,j;r$;a$(j)r$;ae(j);r$
4090 nextj
4100 close1 :rem 108
4999 gosub6000:return
5000 rem delete
5005 dt=0:tm=0
5010 printchr$(147)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
5011 printchr$(29)"delete"
5020 s1$=""
5021 printchr$(13)chr$(13)
5030 input"start at";s1$
5040 ifs1$="*end"thengoto5900
5050 ds=int(val(s1$))
5060 s1$=""
5070 ifds=0thenprintchr$(17)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
5071 ifds=0thenprintchr$(18)chr$(156)"input error"chr$(146);
5073 ifds=0thenprintchr$(144):goto5020
5080 s1$=""
5081 printchr$(13)chr$(13);
5090 input"end at";s1$
5100 ifs1$="*end"thengoto5900
5110 ifs1$=""ors1$="0"thende=0:goto5200
5120 de=int(val(s1$))
5125 ifde>mxthende=mx
5130 ifde=>dsthengoto5200
5135 printchr$(13)chr$(13)chr$(29)chr$(29)chr$(18)chr$(156);
5136 print"0 or number greater"
5140 printchr$(13)chr$(13)chr$(29)chr$(29);
5141 print"than "chr$(146)chr$(28);de;chr$(18)chr$(156);
5142 print"required"chr$(144);
5150 goto5080
5200 ifde=0thende=ds
5205 tm=de-ds+1
5207 dt=dt+tm
5210 forj=dstode
5220 a$(j)="<9 b>":ae(j)=0 :rem "this line might need an edit
5230 nextj
5240 goto5010
5900 gosub500
5910 mx=mx-dt
5999 gosub300:gosub6000:return
6000 rem options menu
6009 printchr$(147)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
6010 printchr$(156)"options: ",chr$(144)"
6020 printchr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(158);
6021 print"========";chr$(144)
6030 printchr$(17)chr$(18)chr$(156);"f1";chr$(146)chr$(144);"-display expenses"
6040 printchr$(17)chr$(18)chr$(156);"f2";chr$(146)chr$(144);"-add new expenses"
6050 printchr$(17)chr$(18)chr$(156);"f3";chr$(146)chr$(144);
6051 print"-update expense list"
6060 printchr$(17)chr$(18)chr$(156);"f4";chr$(146)chr$(144);"-save expense list"
6070 printchr$(17)chr$(18)chr$(156);"f5";chr$(146)chr$(144);"-delete from list"
6080 printchr$(17)chr$(18)chr$(156);"f6";chr$(146)chr$(144);"-options screen"
6090 printchr$(17)chr$(18)chr$(156);"f7";chr$(146)chr$(144);"-load/merge files"
6100 printchr$(17)chr$(18)chr$(156);"f8";chr$(146)chr$(144);"-end"
6999 return 
7000 rem load/merge
7010 printchr$(147)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)"load/merge"
7020 printchr$(17)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29)"expense files"
7030 input"load or merge (l/m)";an$
7040 ifan$="l"thenmx=0:gosub400:goto7999
7050 ifan$="*end"thengosub6000:return
7060 ifan$<>"m"goto7030
7070 printchr$(17)chr$(29)chr$(29)chr$(29)chr$(29)"merge"chr$(17)
7080 input"file name";f$
7090 iff$="*end"thengosub6000:return
7120 open1,8,2,f$+",seq,read"
7130 input#1,t1
7140 fort2=1tot1
7150 input#1,y,t3$,t4
7160 forj=1tomx
7170 ifa$(j)=t3$thenae(j)=int(((ae(j)+t4)/2)*100)/100:t3$=""
7180 nextj
7190 ift3$<>""thenmx=mx+1:a$(mx)=t3$:ae(mx)=t4
7200 next
7210 close1
7999 gosub500:gosub300:gosub6000:return
8000 rem end of job
8010 printchr$(147)chr$(29)chr$(29)chr$(29)chr$(29)"end of program";
8011 printchr$(13)chr$(13)
8020 print"would you like to save (y/n)":input an$
8030 ifan$="*end"thengosub6000:return
8040 ifan$="n"thengoto8060
8050 gosub4000
8060 printchr$(147)"thank you"
8070 printchr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
8071 printchr$(29)chr$(29)chr$(29)chr$(29)chr$(29)chr$(29);
8072 printchr$(29)"end"
8075 print chr$(154)
8080 end

