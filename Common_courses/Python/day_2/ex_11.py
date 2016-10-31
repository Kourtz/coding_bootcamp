import math
limit= int(input("Enter limit"))
if limit<3:
        print("Error")

x1=[int(x) for x in range(3,limit+1)]
b=len(x1)
x3=[]

##synarthsh gia na vroume divisors kathe stoixeiou##
def divisors(x):
    div=[]
    y=2
    while y <= x:
        if x % y == 0:
            div.append(y)
        y += 1
    return div

##an kapoios diaireths einai monos tote o arithmos einai polite###
for i in range (b):
        a=divisors(x1[i])
        for n in range (len(a)):
                if a[n]%2 !=0:
                        x3.append(x1[i])
                        break

##ektupwsh ana 10##
for x in range(0,len(x3),10):
        x4=x3[0+x:10+x]
        for i in range (len(x4)):
                print(x4[i],end=" ")
        print()
