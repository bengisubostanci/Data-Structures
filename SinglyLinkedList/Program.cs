using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Linked List-1
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
            //Create Linked List-2
            Block last = null;
            Block head = null;
            Block tmp = null;
            for (int i = 0; i < 10; i++)
            {
                tmp = new Block();
                tmp.data = i;
                tmp.next = last;
                last = tmp;
            }
            head = last;

            

            //Insertion Operation

            //1-Add a node at the beginning of a linked list
            Block bl = new Block();
            bl.data = 22;
            bl.next = head;
            head = bl;

            //2-Add node to end of linked list
            Block bl = new Block();
            bl.data = 66;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            bl.next = null;
            tmp.next = bl;

            //3-Insert element before last element of linked list
            Block bl = head;
            Block t1 = new Block();
            t1.next = null;
            t1.data = 33;

            while (bl.next.next != null)
            {
                bl = bl.next;
            }
            bl.next = t1;
            t1.next = bl.next;


        }
        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }
    }
}
