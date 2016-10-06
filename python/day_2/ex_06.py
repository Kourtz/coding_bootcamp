x1= str(input("Enter 3 numbers with 1 digit, 2 digits, 3 digits:"))
x2= str(input("Enter 3 numbers with 1 digit, 2 digits, 3 digits:"))
x3= str(input("Enter 3 numbers with 1 digit, 2 digits, 3 digits:"))

x11=x1.split(" ")
x22=x2.split(" ")
x33=x3.split(" ")

x11.sort(key=len)
x22.sort(key=len)
x33.sort(key=len)

if len(x11[0])!=1 or len(x11[1])!=2 or len(x11[2])!=3:
    print("Error at first number set")
if len(x22[0])!=1 or len(x22[1])!=2 or len(x22[2])!=3:
    print("Error at second number set")
if len(x33[0])!=1 or len(x33[1])!=2 or len(x33[2])!=3:
    print("Error at third number set")
    
if len(x11)>3 or len(x22)>3 or len(x33)>3:
    print("Error")
else:
    print("  "+x11[0]+"|"," "+x22[0]+"|"," "+x33[0],end="")
    print()
    print(" "+x11[1]+"|",x22[1]+"|",x33[1],end="")
    print()
    print(x11[2]+"|"+x22[2]+"|"+x33[2],end="")

    

