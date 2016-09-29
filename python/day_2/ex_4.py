number= list(input("Enter a 9 digit number:"))

if len(number)==9:
    for i in range(0,9,3):
        print(number[i],end='  ')
    print()
    print(" ",end="")
    for i in range(1,9,3):
        print(number[i],end='  ')
    print()
    print("  ",end="")
    for i in range(2,9,3):
        print(number[i],end='  ')
        
else:
    print("not a 9 digit number")
    

