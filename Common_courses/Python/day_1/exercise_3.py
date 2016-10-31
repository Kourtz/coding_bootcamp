import math
a= int(input("a side is:"))
b= int(input("b side is:"))
c= int(input("c side is:"))

up=(a+b+c)*(b-a+c)*(a-b+c)*(a+b-c)
area=0.25* math.sqrt(up)

print( "The area is", area)
