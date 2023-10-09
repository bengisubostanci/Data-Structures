using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Linked List
            Block tmp = new Block();
            tmp.data = 0;
            tmp.next = null;
            Block head = tmp;
            Block last = tmp;
            for (int i = 1; i < 10; i++)
            {
                tmp = new Block();
                tmp.data = i;
                tmp.next = null;
                last.next = tmp;
                last = tmp;

            }

            //Print all elements in a Linked list
            Block bl = head;
            while (bl != null)
            {
                Console.WriteLine(bl.data);
                bl = bl.next;
            }


        }
        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }
    }
}
