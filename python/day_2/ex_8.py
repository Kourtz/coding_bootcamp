number= list(input("Enter number sequence:"))
n=[int(x) for x in number] 

if len(n)%2==0:   
    sum=0
    for i in range(1,len(n),2):
        b=n[i-1]*n[i]
        sum=sum+b 
    print(sum)        
else:
    sum=0
    for i in range(1,(len(n)-1),2):
        b=n[i-1]*n[i]
        sum=sum+b
    sum=sum+n[-1]    
    print(sum)     
    

