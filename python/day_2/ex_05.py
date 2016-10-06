import math
y= int(input('Enter year between 1900-2099:')) 
if y>2099 or y<1900:
        print("Error")
 
a=y%4
b=y%7
c=y%19
d=(19*c+15)%30
e=(2*a+4*b-d+34)%7

month=math.floor((d+e+114)/31)
day=(d+e+114)%31+1

day2=day+13
if month==3 or month==5:
    if day2>31:
        day2=day2-31
        month=month+1
    else:
        day2=day2
        month=month
else:
    if day2>30:
        day2=day2-30
        month=month+1
    else:
        day2=day2
        month=month

print ("Day:",day2,"Month:",month,end="")
