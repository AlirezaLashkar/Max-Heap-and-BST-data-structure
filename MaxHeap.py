#Algorithms are designed on the basis that the 
#array starts from index 1, but in the heart of 
#the program, it starts from 0.

def Left(i):#Definition of left child
    L = (2 * (i-1)) + 1
    return L
def Right(i):#Definition of right child
    R = (2 * (i-1)) +2
    return R
def Parent(i):#Definition of parent
    P = int((i-1 ) /2)
    return P

#To maintain the max heap property
def Max_heapify(A  , i):#Definition of Max_heapify
    L = Left(i)
    R = Right(i)
    i = i - 1
    HeapSize = len(A)
    if L < HeapSize and A[L] > A[i]:
        Largest = L
    else:
        Largest = i
    if R < HeapSize and A[R] > A[Largest]:
        Largest = R
    if Largest != i:
        k = A[i]
        A[i] = A[Largest]
        A[Largest] = k
        Max_heapify(A , Largest + 1)

#The definition of Max Heapify, which also receives
#the heap size in the argument of the function
#for the function Print Sorted Heap
def Max_heapify2(A  , i , heapsize):
    L = Left(i)
    R = Right(i)
    i = i - 1
    if L <= heapsize and A[L] > A[i]:
        Largest = L
    else:
        Largest = i
    if R <= heapsize and A[R] > A[Largest]:
        Largest = R
    if Largest != i:
        k = A[i]
        A[i] = A[Largest]
        A[Largest] = k
        Max_heapify2(A , Largest + 1 , heapsize)

def Build_Max_Heap(A):
    length = len(A)
    for i in range(int(length/2) , 0 , -1):
        Max_heapify(A, i)

#1
def Insert_Heap():#Get input and build heap
    A = []
    while True:
        inputnum = input("enter the number! for exit inter e:  ")
        if inputnum == 'e':
            break
        else:
            A.append(int(inputnum))
    Build_Max_Heap(A)
    print(A)
#2
def Is_Heap():#Checking if the input is heap or not
    A = []
    while True:
        inputnum = input("enter the number! for exit inter e:  ")
        if inputnum == 'e':
            break
        else:
            A.append(int(inputnum))
    A1 = A.copy() 
    Build_Max_Heap(A1)
    print ("your input:  " , A)
    print("Make heap whit your input : " , A1)
    if A1 == A:
        print("---------yes---------")
    else:
        print("---------no---------")
        
#3
def Find_Delete_from_Heap():#If it finds the desired node, delete it.
    A = []
    while True:
        inputnum = input("enter the number! for exit inter e:  ")
        if inputnum == 'e':
            break
        else:
            A.append(int(inputnum))
    Build_Max_Heap(A)
    print ("your input:  " , A)
    k = int(input("enter number to finde and delete:   "))
    i = 0
    t = 0 
    while True:
        if i > len(A) - 1:
            break
        if A[i] == k:
            t = 1
            break
        i +=1 
    if t == 1:
        heapsize = len(A) - 1
        k = A[heapsize]
        A[heapsize] = A[i]
        A[i] = k
        A.pop()
        Max_heapify(A, i+1)
    else:
        print("!!!!!!we dont have input in heap !!!!!!")
    print("Final : " , A)
    
#In this function, it finds and deletes all the nodes that have input data.
def Find_Delete_from_Heap2():
    A = []
    while True:
        inputnum = input("enter the number! for exit inter e:  ")
        if inputnum == 'e':
            break
        else:
            A.append(int(inputnum))
    Build_Max_Heap(A)
    print(A)
    k = int(input("enter number to finde and delete:   "))
    i = 0
    t = 0 # check kone k asan k to heap hast ya na
    c = []
    while True:
        if i > len(A) - 1:
            break
        if A[i] == k:
            t = 1
            c.append(i)
        i +=1 
    if t == 1:
        j = 0
        o = 0
        while True:
            if j > len(c) - 1:
                break
            i = c[j] - o #har dafe chon ye ozv az A kam mishe har dafe in o
            #ham update mishe 
            A.pop(i)
            j += 1
            o += 1
        Build_Max_Heap(A)
    else:
        print("we dont have input in heap")
    print(A)

#4
#Display the data of a heap in a sorted manner
def Print_Sorted_Heap():
    
    A = []
    while True:
        inputnum = input("enter the number! for exit inter e:  ")
        if inputnum == 'e':
            break
        else:
            A.append(int(inputnum))
    Build_Max_Heap(A)
    print ("your input:  " , A)
    heapsize = len(A) - 1
    for i in range(len(A),1,-1):
        k = A[heapsize]
        A[heapsize] = A[0]
        A[0] = k
        heapsize -= 1
        Max_heapify2(A, 1 ,heapsize)
    print("Sorted Heap:  " , A)
    return A

#5
#Combine two heaps and turn them into one heap
def Merge_Heaps():
    A1 = []
    while True:
        inputnum = input("enter the number For Heap 1 ! for exit enter e:  ")
        if inputnum == 'e':
            break
        else:
            A1.append(int(inputnum))
    Build_Max_Heap(A1)
    print ("your input:  " , A1)
    A2 = []
    while True:
        inputnum = input("enter the number For Heap 2 ! for exit enter e:  ")
        if inputnum == 'e':
            break
        else:
            A2.append(int(inputnum))
    Build_Max_Heap(A2)
    print ("your input:  " , A2)
    for i in range(0, len(A2)):
        A1.append(A2[i])
    Build_Max_Heap(A1)
    print ("Final Merge :  " , A1)

#6
#Declare the kth largest number in the heap.
def Print_kth_BiggestNumInHeap():
    A = Print_Sorted_Heap()
    k = int(input("enter K :   ")) 
    if k > len(A):
        print("!!!!!!! We dont Have" , k , "node in heap !!!!!!!")
    else:
        print(k , "th Biggest Num InHeap :" , A[len(A)-k])

#7
#bst class definition
class bst:
    def __init__(self, val=None):
        self.left = None
        self.right = None
        self.val = val
    def  insert(self, val):
        if not self.val:
            self.val = val
            return
        if self.val == val:# age vojood dasht kari nakon
            return
        if val < self.val:# age kamtar bod az rishe chap bezar
            if self.left:
                self.left.insert(val)
                return
            self.left = bst(val)
            return
        if self.right:
            self.right.insert(val)
            return
        self.right = bst(val)
    def inorder(self, vals):
        if self.left is not None:
            self.left.inorder(vals)
        if self.val is not None:
            vals.append(self.val)
        if self.right is not None:
            self.right.inorder(vals)
        return vals
    def preorder(self, vals):
        if self.val is not None:
            vals.append(self.val)
        if self.left is not None:
            self.left.preorder(vals)
        if self.right is not None:
            self.right.preorder(vals)
        return vals
def Heap_to_BST():
    h = bst()
    A = []
    while True:
        inputnum = input("enter the number! for exit inter e:  ")
        if inputnum == 'e':
            break
        else:
            A.append(int(inputnum))
    Build_Max_Heap(A)
    print("Heap :  " , A)
    for num in A:
        h.insert(num)
    print("BST inOrder : " , h.inorder([])) 
    print("BST PreOrder : " , h.preorder([])) 

while True:
    print("\n\n1- Insert Heap\n"+ "2- IsHeap\n" + 
          "3- Find Delete from Heap\n" + "4- Print Sorted Heap\n" +
          "5- Merge Heaps\n" + "6- Print kth Biggest Num In Heap\n" +
          "7- Heap to BST ")
    q = input("Please enter number to do function or enter 'e' to exit:   ")
    if q == 'e' :
        print("\n ***Thanks for using this app***")
        break
    elif int(q) == 1 :
        Insert_Heap()
    elif int(q) == 2:
        Is_Heap()
    elif int(q) == 3:
        Find_Delete_from_Heap()
    elif int(q) == 4:
        Print_Sorted_Heap()
    elif int(q) == 5:
        Merge_Heaps()
    elif int(q) == 6:
        Print_kth_BiggestNumInHeap()
    elif int(q) == 7:
        Heap_to_BST()
    else:
        continue