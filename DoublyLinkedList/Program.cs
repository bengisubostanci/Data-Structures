using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Doubly Linked List
            Block first = null;
            Block last = null;
            for (int i = 0; i < 10; i++)
            {
                Block tmp = new Block();
                tmp.data = i;
                tmp.next = null;
                tmp.prev = null;
                if (first == null)
                {
                    first = tmp;
                }
                else
                {
                    last.next = tmp;
                    tmp.prev = last;
                }
                last = tmp;

            }
            while (last != null)
            {
                Console.WriteLine(last.data);
                last = last.prev;
            }

            //Convert doubly linked list to circular list

            Block bl = first;
            while (bl.next != null) bl = bl.next;
            bl.next = first;
            first.prev = bl;

            //Add a new block after the block with data value 5
            Block tmp = first;
            while (tmp != null)
            {
                if (tmp.data == 5)
                {
                    Block b1 = new Block();
                    b1.data = 10;
                    b1.prev = tmp;
                    b1.next = tmp.next;
                    tmp.next.prev = b1;
                    tmp.next = b1;
                }
                tmp = tmp.next;
            }

            //Add block to the end of the list
            Block b3 = new Block();
            b3.data = 5;
            b3.next = null;
            b3.prev = null;
            Block t4 = first;
            while (t4.next == null) t4 = t4.next;
            t4.next = b3;
            b3.prev = t4;
            last = b3;

        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }
    }
}
