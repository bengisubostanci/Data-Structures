namespace DataStructures.BinaryTree
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
            // .NET otomatik olarak null atasa da ders dokümanınızdaki gibi 
            // güvenlik amacıyla açıkça belirtmek en iyisidir.
        }
    }
}

using System;

namespace DataStructures.BinaryTree
{
    public class BinaryTree
    {
        // Ders notlarındaki HEAD veya SP mantığı gibi, ağacın başlangıç noktası ROOT'tur.
        public Node Root { get; private set; }

        public BinaryTree()
        {
            Root = null;
        }

        // Dışarıdan çağrılan ana ekleme metodu
        public void Insert(int data)
        {
            Root = InsertRecursive(Root, data);
        }

        // Ders notlarınızdaki recursive mantığa uygun yardımcı metot
        private Node InsertRecursive(Node current, int data)
        {
            // Eğer boş bir dallanmaya geldiysek yeni düğümü oluşturup geri döndürürüz
            if (current == null)
            {
                return new Node(data);
            }

            // Binary Search Tree (İkili Arama Ağacı) kuralı: 
            // Küçük olanlar sola, büyük olanlar sağa eklenir.
            if (data < current.Data)
            {
                current.Left = InsertRecursive(current.Left, data);
            }
            else if (data > current.Data)
            {
                current.Right = InsertRecursive(current.Right, data);
            }

            return current;
        }

        // --- AĞAÇ DOLAŞMA (TRAVERSAL) METOTLARI ---
        // Notlarınızdaki recursive mantıkla (örneğin 'linkedyaz' metodu gibi) çalışır.

        // 1. In-Order Dolaşma (Sol -> Kök -> Sağ) : Verileri sıralı (küçükten büyüğe) basar.
        public void TraverseInOrder(Node node)
        {
            if (node == null) return; // Base case (Durma koşulu)

            TraverseInOrder(node.Left);
            Console.Write(node.Data + " ");
            TraverseInOrder(node.Right);
        }

        // 2. Pre-Order Dolaşma (Kök -> Sol -> Sağ)
        public void TraversePreOrder(Node node)
        {
            if (node == null) return;

            Console.Write(node.Data + " ");
            TraversePreOrder(node.Left);
            TraversePreOrder(node.Right);
        }

        // 3. Post-Order Dolaşma (Sol -> Sağ -> Kök)
        public void TraversePostOrder(Node node)
        {
            if (node == null) return;

            TraversePostOrder(node.Left);
            TraversePostOrder(node.Right);
            Console.Write(node.Data + " ");
        }
    }
}

using System;
using DataStructures.BinaryTree;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree.BinaryTree tree = new BinaryTree.BinaryTree();

            // Örnek verilerin ağaca eklenmesi
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(70);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(60);
            tree.Insert(80);

            Console.WriteLine("--- Binary Tree (İkili Ağaç) Gösterimi ---\n");

            // Küçükten büyüğe sıralı çıktı vermesi beklenir: 20 30 40 50 60 70 80
            Console.Write("In-Order Dolaşma:   ");
            tree.TraverseInOrder(tree.Root);
            Console.WriteLine();

            Console.Write("Pre-Order Dolaşma:  ");
            tree.TraversePreOrder(tree.Root);
            Console.WriteLine();

            Console.Write("Post-Order Dolaşma: ");
            tree.TraversePostOrder(tree.Root);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
