TIN= input("Enter Tax Identification Number:")

if len(TIN) != 9:
    print("Tax Identification Number not valid (must be 9-digits)")
else:
    tin=[int(x) for x in TIN[0:9]]        
    tin2=tin[:8]     #xwris teleutaio
    s1=[2**x for x in range(1,9)]
    s1.reverse()
    sum=0 
    for i in range (8):
        a=tin2[i]*s1[i]
        sum=sum+a
    b=(sum%11)%10
    if b==tin[8]:
        print("Tax Identification Number valid")
    else:
        print("Tax Identification Number not valid")
            
