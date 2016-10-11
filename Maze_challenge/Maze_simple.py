#MAZE CHALLENGE#

#Maze should have a form like S___X,__XX_,__X__,_X__E,___X_  where
#S=start,E=end,X=wall,_=path (find mazes in txt file)
maze=str(input("Enter a maze:")) 

#Split maze in rows (list of strings) 
m=maze.split(',')

#Find the starting point
s=[]
for x in range(0,len(m)):
    for y in range (0,len(m[1])):
        if m[x][y]=="S":
            s=[x,y]
            print([x+1,y+1],"(S)",end=",")

#make rows lists            
m2=[]
for i in range(0,len(m)):
    m2.append(list(m[i]))

#Function that solves the maze
def path(x,y):    
        if x>len(m)-1 or y>len(m[1])-1 or x<0 or y<0: #limits of the maze 
            return False
        elif m2[x][y]=='X':  #wall
            return False
        elif m2[x][y]=='P':  #P from pass-see below
            return False
        elif m2[x][y]=='E':  #End returns true
            print([x+1,y+1],"(E)") 
            return True
        
        print([x+1,y+1],end=",")
        m2[x][y]='P'         #make the point a pass point 
        
        if path(x+1,y) or path(x,y-1) or path(x-1,y) or path(x,y+1):  #search all the near squares:N,W,S,E 
            return True   
        return False

path(s[0],s[1])              #s[0] and s[1] is the starting point because s[x,y]="S"     
                         
##references: http://www.laurentluce.com/posts/solving-mazes-using-python-simple-recursivity-and-a-search/ ###
