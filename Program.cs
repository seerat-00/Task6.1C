using System;
using System.Collections.Generic;

//part 1
class MergeSort {
    void merge(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        int[] L = new int[n1];
        int[] R = new int[n2];

        for (int c = 0; c < n1; ++c)
            L[c] = arr[l + c];
        for (int d = 0; d < n2; ++d)
            R[d] = arr[m + 1 + d];

        int i = 0, j = 0;

        int k = l;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                arr[k] = L[i];
                i++;
            }
            else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    void sort(int[] arr, int l, int r)
    {
        if (l < r) {
            int m = (l + r) / 2;

            sort(arr, l, m);
            sort(arr, m + 1, r);

            merge(arr, l, m, r);
        }
    }

    public bool bool_test(int[] n, int x)
    {
        sort(n, 0, n.Length-1);
        int a = 0;
        int b = n.Length-1;

        while(a<b)
        {
            if(n[a]+n[b]==x){
                return true;
            }
            else if(n[a]+n[b]>x){
                b--;
            }
            else{
                a++;
            }
        }
        return false;
    }
    static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("\n");
    }

    public static void Main(String[] args)
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Given Array");
        printArray(arr);

        MergeSort ob = new MergeSort();
        ob.sort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nSorted array");
        printArray(arr);

        Console.WriteLine("Please enter a number: ");
        int x = Convert.ToInt32(Console.ReadLine());

        bool result = ob.bool_test(arr,x);
        Console.WriteLine("The sum exists: "+result);

    }
}

//part 2
class MainStack {

    private Stack<int> stack = new Stack<int>(); 
    private Stack<int> minstack = new Stack<int>(); 

    public void Push(int v)
    {
        stack.Push(v);

        if(minstack.Count==0 || v<=minstack.Peek()){
            minstack.Push(v);
        }
        Console.WriteLine("Pushed: " +v);
        Console.WriteLine("Stack: "+ string.Join(",",stack));
        Console.WriteLine("Min Stack: " + string.Join(",",minstack));
        Console.WriteLine("Current Min: " + Min());
        Console.WriteLine("\n");
    }

    public void Pop()
    {
        if(stack.Count==0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        int top = stack.Pop();

        if(top == minstack.Peek())
        {
            minstack.Pop();
        }

        Console.WriteLine("Popped: " + top);
        Console.WriteLine("Stack: "+ (stack.Count>0 ? string.Join(",",stack): "The stack is empty"));
        Console.WriteLine("Min Stack: " + (minstack.Count>0 ? string.Join(",",minstack): "The stack is empty"));
        Console.WriteLine("Current Min: " + (minstack.Count>0 ? Min().ToString(): "The stack is empty"));
        Console.WriteLine("\n");
    }

    public int Peek()
    {
        if(stack.Count==0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return stack.Peek();
    }

    public int Min()
    {
        if(minstack.Count==0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return minstack.Peek();
    }
    public static void Main(String[] args)
    {
        MainStack ms = new MainStack();

        ms.Push(4);
        ms.Push(1);
        ms.Push(5);
        ms.Push(2);
        ms.Push(7);

        ms.Pop();
        ms.Pop();
        ms.Pop();
        ms.Pop();
        ms.Pop();
    }
}


