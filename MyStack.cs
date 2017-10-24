using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverDevicesQuestionnaire
{
   public static class StackTest
    {
        public static void main()
        {
            MyStack ms = new MyStack();
            ms = ms.CreateMyStack();
            for (int i = 11; i < 10000; i++)
            {
                ms.Push(ms, i);
            }

            Console.WriteLine("Is Stack Empty? {0}\n", ms.isEmpty(ms));
            Console.WriteLine("Stack size: " + ms.size(ms) + "\n");
            Console.WriteLine("Element at the top of the Stack is: {0}\n", ms.head.data);

            Console.WriteLine("Item popped is " + ms.Pop(ms) + "\n");

            Console.WriteLine("Element at the top after the POP: {0}\n", ms.head.data);

            Console.WriteLine("Is Stack Empty? {0}\n", ms.isEmpty(ms));

            ms.Pop(ms);
            Console.WriteLine("Element at the top after the POP: {0}\n", ms.head.data);
            Console.WriteLine("Stack size: " + ms.size(ms) + "\n");

            Console.ReadLine();
        }
    }

    /// <summary>
    ///  A Doubly Linked List Node 
    /// </summary>
    public class DLLNode
    {
        public DLLNode prev;
        public int data;
        public DLLNode next;
        public DLLNode(int d) { data = d; }
    }

    /// <summary>
    /// The Stack is implemented using Doubly Linked List.It maintains pointer to head node, pointer to middle node and count of nodes.
    /// </summary>
    public class MyStack
    {
        public DLLNode head;
        public DLLNode mid;
        public int count;

        /// <summary>
        /// Function to create the stack data structure.
        /// </summary>
        /// <returns></returns>
        public MyStack CreateMyStack()
        {
            MyStack myStack = new MyStack();
            myStack.count = 0;
            return myStack;
        }

        /// <summary>
        /// Function to push an element to the stack
        /// </summary>
        /// <param name="myStack">Stack</param>
        /// <param name="newData">Integer which would be inserted in to stack</param>
        public void Push(MyStack myStack, int newData)
        {
            //Allocate DLLNode and put in data
            DLLNode newDllNode = new DLLNode(newData);

            //Since we are adding at the beginning, prev is always NULL
            newDllNode.prev = null;

            // link the old list off the new DLLNode
            newDllNode.next = myStack.head;

            //Increment count of items in stack
            myStack.count += 1;

            /* Change mid pointer in two cases
               1) Linked List is empty.
               2) Number of nodes in linked list is odd.
            */
            if (myStack.count == 1)
            {
                myStack.mid = newDllNode;
            }
            else
            {
                myStack.head.prev = newDllNode;

                if ((myStack.count % 2) != 0) // Update mid if ms->count is odd.
                    myStack.mid = myStack.mid.prev;
            }

            //move head to point to the new DLLNode.
            myStack.head = newDllNode;
        }

        /// <summary>
        /// To verify if the stack is empty
        /// </summary>
        /// <param name="ms">Stack List</param>
        /// <returns>True/False</returns>
        public bool isEmpty(MyStack ms)
        {
            if (ms.count == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// To get the count of the data in the stack
        /// </summary>
        /// <param name="ms">Stack list</param>
        /// <returns>Count of the stack</returns>
        public int size(MyStack ms)
        {
            return ms.count;
        }

        /// <summary>
        /// Function to pop an element from stack.
        /// </summary>
        /// <param name="ms">Stack List</param>
        /// <returns>The data it removed from the stack</returns>
        public int Pop(MyStack ms)
        {
            // Stack underflow
            if (ms.count == 0)
            {
                Console.WriteLine("Cannot pop as the stack is empty");
                return -1;
            }

            DLLNode head = ms.head;
            int item = head.data;
            ms.head = head.next;

            // If linked list doesn't become empty, update prev of new head as NULL
            if (ms.head != null)
                ms.head.prev = null;

            ms.count -= 1;

            // update the mid pointer when we have even number of elements in the stack, i,e move down the mid pointer.
            if (ms.count % 2 == 0)
            {
                ms.mid = ms.mid.next;
            }

            return item;
        }
    }
}
