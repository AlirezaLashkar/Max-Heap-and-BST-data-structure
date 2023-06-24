using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT2
{
    //Defining the MaxHeap class to convert BST to MaxHeap (using MaxHeap project algorithms)
    public class maxheap
    {
        int[] Maxheap;

        public int Left(int i)
        {
            int L = (2 * (i - 1)) + 1;
            return L;
        }
        public int Right(int i)
        {
            int L = (2 * (i - 1)) + 2;
            return L;
        }
        public void Max_heapify(int[] A, int i)
        {
            int L = Left(i);
            int R = Right(i);
            int Largest;
            i = i - 1;
            int HeapSize = A.Length;
            if (L < HeapSize && A[L] > A[i])
                Largest = L;
            else
                Largest = i;
            if (R < HeapSize && A[R] > A[Largest])
                Largest = R;
            if (Largest != i)
            {
                int k = A[i];
                A[i] = A[Largest];
                A[Largest] = k;
                Max_heapify(A, Largest + 1);
            }
        }
        public void Build_Max_Heap(int[] A)
        {
            int length = A.Length;
            for (int i = Convert.ToInt32(length / 2); i > 0; i--)
                Max_heapify(A, i);
        }
        public void InsertToHeap(int[] input)
        {
            Maxheap = input;
            Build_Max_Heap(Maxheap);
            Console.WriteLine("\nNow we convert Bst to MaxHeap:  ");
            for (int i = 0; i < Maxheap.Length; i++)
            {
                if (i == Maxheap.Length - 1)
                    Console.Write(Maxheap[i]);
                else
                    Console.Write(Maxheap[i] + " --> ");
            }

        }
    }

    //Definition of node class and use of link lists
    public class node
    {
        public node right;
        public node left;
        public node parent;
        public int Data;
        public node()
        {
            right = null;
            left = null;
            parent = null;
            Data = 0;
        }
    }

    public class BST
    {
        public int[] inorderarray;// The array in which we store the Traversal  of the inorder
        public int[] postorderarray;//The array in which we store the Traversal  of the postorder
        public node root;
        public int BstSize;//Size Of BsT
        public BST() //Constructor function
        {
            BstSize = 0;
            inorderarray = new int[BstSize];
        }
        //1
        public void Insert_node(int data)//Add node to BST
        {
            node z = new node();
            z.Data = data;
            node x = root;
            node y = x;
            while (x != null)//Find node location to add
            {
                y = x;
                if (z.Data <= x.Data)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }
            //Identify father, left child, right child
            z.parent = y;
            if (y == null)
            {
                root = z;
            }
            else if (z.Data < y.Data)
                y.left = z;
            else
                y.right = z;

            BstSize++;
        }
        
        //2
        public int[] inorder(node x)//inorder Traversal
        {
            if (x != null)
            {
                inorder(x.left);
                inorderarray = inorderarray.Append(x.Data).ToArray();
                inorder(x.right);
            }
            return inorderarray;
        }
        public int[] postorder(node x)//postorder Traversal
        {
            if (x != null)
            {
                postorder(x.left);
                postorderarray = postorderarray.Append(x.Data).ToArray();//ezafe krdn be arry
                postorder(x.right);
            }
            return postorderarray;
        }
        
        public static void IsBST()//Get an input from the user and check if it is BST or not
        {
            List<int> list = new List<int>();
            BST bst = new BST();
            while (true)
            {
                Console.Write("please enter the number. for exit enter !!e!!:  ");
                string k = Console.ReadLine();
                if (k == "e")
                    break;
                else
                {
                    bst.Insert_node(Convert.ToInt32(k));
                    list.Add(Convert.ToInt32(k));
                }
            }
            int[] c1 = bst.inorder(bst.root);
            int[] inputs = list.ToArray();
            bool isbst = c1.SequenceEqual(inputs);

            if (isbst == true)
                Console.WriteLine("--------Yes it is BST--------");
            else
                Console.WriteLine("--------NO it is not BST--------");
        }
        
        //3
        public int bstMIN()//Minimum in bst
        {
            node x = root;
            while (true)
            {
                x = x.left;
                if (x.left == null)
                    break;
            }
            return x.Data;
        }
        public node bstMIN2(node x)//Minimum bst(Node)
        {
            while (x.left != null)
            {
                x = x.left;
            }
            return x;
        }
        public void transplant(node u, node v)//Moving two subtrees for the delete function
        {
            if (u.parent == null)
                root = v;
            else if (u == u.parent.left)
                u.parent.left = v;
            else
                u.parent.right = v;
            if (v != null)
                v.parent = u.parent;
        }
        public void Delete(int data)//Delete a node with specific data
        {
            node y;
            int q = 0;
            node x = root;
            while (x != null)
            {
                if (x.Data == data)
                {
                    q = 1;
                    break;
                }
                else
                {
                    if (data < x.Data)
                        x = x.left;
                    else
                        x = x.right;
                }
            }
            if (q == 0)
            {
                Console.WriteLine("!!!!!!!!!ERROR!!!!!!!!!");
            }
            else
            {
                if (x.left == null)
                    transplant(x, x.right);
                else if (x.right == null)
                    transplant(x, x.left);
                else
                {
                    y = bstMIN2(x.right);
                    if (y.parent != x)
                    {
                        transplant(y, y.right);
                        y.right = x.right;
                        y.right.parent = y;
                    }
                    transplant(x, y);
                    y.left = x.left;
                    y.left.parent = y;
                }
                BstSize--; 
                Console.WriteLine("-----DONE-----");
            }
        }
        
        //4
        public void printIorder(node x)//Print sorted BST
        {
            if (x != null)
            {
                printIorder(x.left);
                Console.Write(x.Data + "  ---> ");
                printIorder(x.right);
            }
        }
        
        //5
        public static void MergBst()//Combining two BSTs
        {
            List<int> list = new List<int>();
            BST bst1 = new BST();
            while (true)
            {
                Console.Write("\nplease enter the number for bst1. for exit enter !!e!!:  ");
                string k = Console.ReadLine();
                if (k == "e")
                    break;
                else
                {
                    bst1.Insert_node(Convert.ToInt32(k));
                    list.Add(Convert.ToInt32(k));
                }
            }
            BST bst2 = new BST();
            while (true)
            {
                Console.Write("\nplease enter the number for bst2. for exit enter !!e!!:  ");
                string k = Console.ReadLine();
                if (k == "e")
                    break;
                else
                {
                    bst2.Insert_node(Convert.ToInt32(k));
                    list.Add(Convert.ToInt32(k));
                }
            }
            BST bstMerg = new BST();
            foreach (var i in list)
            {
                bstMerg.Insert_node(i);
            }
            Console.WriteLine("\ninorder for mergBST : ");
            bstMerg.printIorder(bstMerg.root);
        }
        
        //6
        public void kthBiggest()//#Declare the kth largest number in the heap.
        {
            Console.Write("\nenter the kth-Biggest_Num: ");
            int k = Convert.ToInt32(Console.ReadLine());
            if (k <= 0 || k > BstSize)
                Console.WriteLine("\n!!!!!!!ERROR!!!!!!!!");
            else
            {
                inorder(root);
                Console.WriteLine("\nthe " + k + "th Biggest_Num in BST is : " + inorderarray[BstSize - k]);
            }
        }
        
        //7
        public void Bst_To_Heap()//Convert BST to Max Heap
        {
            maxheap maxheap = new maxheap();
            int[] k = inorder(root);
            maxheap.InsertToHeap(k);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BST bST = new BST();
            int k = 1;
            while (k != 0)
            {
                Console.WriteLine("\n\n1- Insert TO BST\n2- Is BST ?" +
                    "\n3- Find & Delete from BST\n4- Print Sorted BST" +
                    "\n5- Merge BST\n6- Print kth Biggest Num In BST" +
                    "\n7- BST to heap");
                Console.Write("Please enter number to do function or enter '0' to exit:  ");
                k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 0:
                        break;
                    case 1:
                        while (true)
                        {
                            Console.Write("\nplease enter the number. for exit enter !!e!!:  ");
                            string q = Console.ReadLine();
                            if (q == "e")
                                break;
                            else
                            {
                                bST.Insert_node(Convert.ToInt32(q));//ham b bst add mikonim va bst misazim
                            }
                        }
                        Console.WriteLine("-----DONE-----");
                        break;
                    case 2:
                        BST.IsBST();
                        break;
                    case 3:
                        Console.Write("\nplease enter the number to delete: ");
                        int w = Convert.ToInt32(Console.ReadLine());
                        bST.Delete(w);
                        break;
                    case 4:
                        Console.WriteLine();
                        bST.printIorder(bST.root);
                        Console.WriteLine();
                        break;
                    case 5:
                        BST.MergBst();
                        break;
                    case 6:
                        bST.kthBiggest();
                        break;
                    case 7:
                        BST bST1 = new BST();
                        while (true)
                        {
                            Console.Write("\nplease enter the number. for exit enter !!e!!:  ");
                            string q = Console.ReadLine();
                            if (q == "e")
                                break;
                            else
                            {
                                bST1.Insert_node(Convert.ToInt32(q));//ham b bst add mikonim va bst misazim
                            }
                        }
                        maxheap maxheap = new maxheap();
                        int[] g = bST1.inorder(bST1.root);
                        maxheap.InsertToHeap(g);
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}