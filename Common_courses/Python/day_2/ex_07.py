date1_input = input('Enter a date(dd/mm/yyyy): ') 
d1=int(date1_input[:2])
m1=int(date1_input[3:5])
y1=int(date1_input[6:])

c1=365*y1+(y1/4)-(y1/100)+(y1/400)+(306*m1+5)/10+(d1-1)
     
date2_input = input('Enter second date(dd/mm/yyyy): ')    
d2=int(date2_input[:2])
m2=int(date2_input[3:5])
y2=int(date2_input[6:])

c2=365*y2+(y2/4)-(y2/100)+(y2/400)+(306*m2+5)/10+(d2-1)

c=abs(c2-c1)
print(round(c), "days")
