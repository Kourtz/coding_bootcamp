import string
shift=int(input("Enter shift"))
word=str(input("Enter phrase"))
w1=[]
w2=[]
for i in range (0,len(word)):
        w1.append(int(ord(word[i]))+shift)

for i in range (0,len(w1)):
        if w1[i]>90:
              w1[i]=w1[i]-26  
        w2.append(w1[i])
        print(chr(w2[i]),end='')
