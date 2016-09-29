b= input("Enter binary number(8-bits)")

if len(b) != 8:
    print("8-digits numbers only")
else:
    b1=[int(x) for x in b[0:8]]
    b2=b1[:7]     #xwris teleutaio
    
    sum=0 
    for i in range (7):
        if b1[i]==1:
            sum=sum+b1[i]
    
    if sum%2==0 and b1[7]==0: 
        print("Parity check OK")
    elif sum%2!=0 and b1[7]==1:    
        print("Parity check OK")
    else:
        print("Parity check not OK")
            
