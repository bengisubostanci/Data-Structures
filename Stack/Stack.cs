using System;

namespace DataStructures.Stack
{
    public class ArrayStack
    {
        // Ders notlarındaki sabit 100 eleman sınırı (sp 99'u geçemez)
        private const int MaxSize = 100; 
        private int[] stackArray;
        private int sp; // Stack Pointer

        public ArrayStack()
        {
            stackArray = new int[MaxSize];
            sp = -1; // -1 yığının boş olduğunu gösterir
        }

        // --- PUSH (Yığına Eleman Ekleme) ---
        public void Push(int data)
        {
            // Stack Overflow (Yığın Taşması) kontrolü - Sınavlarda hayat kurtarır
            if (sp >= MaxSize - 1)
            {
                Console.WriteLine("Stack Overflow! Yığın tamamen dolu.");
                return;
            }

            sp++; 
            stackArray[sp] = data;
        }

        // --- POP (Yığından Eleman Çıkarma) ---
        public int Pop()
        {
            // Yığının boş olma denetimi (Hocanızın sonradan eklediği mantık)
            if (sp >= 0) 
            {
                int data = stackArray[sp];
                sp--;
                return data;
            }
            
            // Yığın boşsa -1 döner (Hata/Boşluk yönetimi için)
            return -1; 
        }

        // --- PEEK (Pop etmeden en üstteki elemana bakma - Infix/Postfix'te kullanılan komut) ---
        public int Peek()
        {
            if (sp >= 0)
            {
                return stackArray[sp];
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return sp == -1;
        }
    }
}




namespace DataStructures.Stack
{
    public class Block
    {
        public int Data { get; set; }
        public Block Next { get; set; }
        public Block Prev { get; set; }

        public Block(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}

using System;

namespace DataStructures.Stack
{
    public class LinkedStack
    {
        // Sp (Stack Pointer) başlangıçta null'dır ve yığının en üstünü gösterir
        private Block sp; 

        public LinkedStack()
        {
            sp = null;
        }

        // --- PUSH (Bağlı Listenin Başına Ekleme Mantığı) ---
        public void Push(int data)
        {
            Block bl = new Block(data);
            bl.Next = sp; // Yeni elemanın sonraki göstericisi eski tepeyi işaret eder
            bl.Prev = null; // Güvenlik için açıkça null tutulur

            if (sp != null)
            {
                sp.Prev = bl; // Eğer içeride eleman varsa eskisinin önceliğini yeni eleman yaparız
            }

            sp = bl; // Stack pointer artık yeni gelen bloğu gösterir
        }

        // --- POP (Bağlı Listenin Başından Eleman Çıkarma Mantığı) ---
        public int Pop()
        {
            // Yığın boş mu kontrolü (sp null ise eleman çekilemez)
            if (sp == null)
            {
                Console.WriteLine("Stack Underflow! Yığın boş.");
                return -1;
            }

            int data = sp.Data; // En üstteki veriyi alıyoruz
            sp = sp.Next;       // Stack pointer'ı bir alt satıra/bloğa kaydırıyoruz
            
            if (sp != null)
            {
                sp.Prev = null; // Yeni tepenin prev pointer'ını boşa çıkarıyoruz
            }

            return data;
        }

        public bool IsEmpty()
        {
            return sp == null;
        }
    }
}

using System;
using DataStructures.Stack;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ARRAY STACK TEST (Kelime Ters Çevirme) ===");
            ArrayStack stringStack = new ArrayStack();
            string s = "merhaba bilgisayar mühendisleri";
            
            // Karakterleri byte cinsinden yığına atıyoruz
            for (int i = 0; i < s.Length; i++)
            {
                stringStack.Push((byte)s[i]);
            }

            string s1 = "";
            while (!stringStack.IsEmpty())
            {
                s1 += (char)stringStack.Pop();
            }
            
            Console.WriteLine("Orijinal: " + s);
            Console.WriteLine("Ters Hali: " + s1); // irelsidnehüm rayasiglib abahrem


            Console.WriteLine("\n=== LINKED STACK TEST (Sayısal İşlem) ===");
            LinkedStack numStack = new LinkedStack();
            
            numStack.Push(10);
            numStack.Push(20);
            numStack.Push(30);

            Console.WriteLine("Pop edilen: " + numStack.Pop()); // 30
            Console.WriteLine("Pop edilen: " + numStack.Pop()); // 20

            Console.ReadLine();
        }
    }
}
