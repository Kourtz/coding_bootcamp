number= list(input("Enter a 10 digit number:"))

if len(number)==10:
    for i in range(0,10,2):
        print(number[i],end=' ')
    print()
    number.insert(0," ")
    for i in range(0,11,2):
        print(number[i],end=' ')

else:
    print("not a 10 digit number")
    

