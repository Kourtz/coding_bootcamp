import math
print("enter values for ax^2+bx+c")
a= int(input("a equals to:"))
b= int(input("b equals to:"))
c= int(input("c equals to:"))

D= b**2-(4*a*c)
if D<0:
    print("there is no real solution")
else:
    x1=(-b+math.sqrt(D))/(2*a)
    x2=(-b-math.sqrt(D))/(2*a)
    print("x1=",x1)
    print("x2=",x2)
