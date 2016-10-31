number= str(input("Enter a sequence of 0s and 1s"))
ones=number.split("0")
zeros=number.split("1")

max1=len(max(ones))
max0=len(max(zeros))

if max1>max0:
        print("Longest run was ones with length:",max1)
elif max0>max1:
        print("Longest run was zeros with length:",max0)
else:
        print("Longest run of ones and zeros with length:",max0)

