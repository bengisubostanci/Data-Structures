using System;

namespace DataStructures.Queue
{
    public class ArrayQueue
    {
        // Ders notlarındaki genel dizi sınırı alışkanlığına uygun sabit boyut (Örn: Stack için 100)
        private const int MaxSize = 100; 
        private int[] queueArray;
        private int front; // Kuyruğun önündeki elemanı gösterir (Pop/Dequeue buradan yapılır)
        private int rear;  // Kuyruğun sonundaki elemanı gösterir (Push/Enqueue buradan yapılır)
        private int count; // Kuyruktaki anlık eleman sayısı

        public ArrayQueue()
        {
            queueArray = new int[MaxSize];
            front = 0;
            rear = -1;
            count = 0;
        }

        // --- ENQUEUE (Kuyruğa Eleman Ekleme) ---
        public void Enqueue(int data)
        {
            // Kuyruk dolu mu kontrolü (Stack Overflow benzeri güvence)
            if (count >= MaxSize)
            {
                Console.WriteLine("Queue Overflow! Kuyruk tamamen dolu.");
                return;
            }

            // Dairesel dönme mantığı: Rear sona ulaştıysa dizinin başına (0'a) döner
            rear = (rear + 1) % MaxSize;
            queueArray[rear] = data;
            count++;
        }

        // --- DEQUEUE (Kuyruktan Eleman Çıkarma) ---
        public int Dequeue()
        {
            // Kuyruk boş mu kontrolü (Stack Underflow mantığı)
            if (count == 0)
            {
                Console.WriteLine("Queue Underflow! Kuyruk boş.");
                return -1; // Hocanızın boş yığında -1 dönme kuralına sadık kalındı
            }

            int data = queueArray[front];
            // Dairesel dönme mantığı: Front sona ulaştıysa dizinin başına (0'a) döner
            front = (front + 1) % MaxSize;
            count--;
            return data;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }
    }
}

namespace DataStructures.Queue
{
    // 5. ve 7. hafta notlarındaki 'block' / 'Block' yapısının aynısı
    public class QueueBlock
    {
        public int Data { get; set; }
        public QueueBlock Next { get; set; }
        public QueueBlock Prev { get; set; }

        public QueueBlock(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}

using System;

namespace DataStructures.Queue
{
    public class LinkedQueue
    {
        private QueueBlock front; // Kuyruğun başı
        private QueueBlock rear;  // Kuyruğun sonu

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        // --- ENQUEUE (Listenin Sonuna Ekleme - Kuyruk Mantığı) ---
        public void Enqueue(int data)
        {
            QueueBlock bl = new QueueBlock(data);

            // Eğer kuyruk tamamen boşsa yeni eleman hem baş hem sondur
            if (rear == null)
            {
                front = bl;
                rear = bl;
                return;
            }

            // 5. haftadaki listenin sonuna eleman ekleme mantığı
            rear.Next = bl;
            bl.Prev = rear;
            rear = bl; // Kuyruğun son pointer'ını güncelliyoruz
        }

        // --- DEQUEUE (Listenin Başından Eleman Çıkarma - FIFO) ---
        public int Dequeue()
        {
            if (front == null)
            {
                Console.WriteLine("Queue Underflow! Kuyruk boş.");
                return -1;
            }

            int data = front.Data;
            front = front.Next; // Başlangıç pointer'ını bir sonraki düğüme kaydırıyoruz

            if (front != null)
            {
                front.Prev = null; // Bellek sızıntısı olmaması için eski bağı koparıyoruz
            }
            else
            {
                rear = null; // Eğer front null olduysa kuyruk tamamen boşalmıştır
            }

            return data;
        }

        public bool IsEmpty()
        {
            return front == null;
        }
    }
}

using System;
using DataStructures.Queue;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DAİRESEL DİZİ TABANLI KUYRUK TESTİ ===");
            ArrayQueue arrQueue = new ArrayQueue();

            arrQueue.Enqueue(10);
            arrQueue.Enqueue(20);
            arrQueue.Enqueue(30);

            Console.WriteLine("Kuyruktan Çıkan (İlk Giren): " + arrQueue.Dequeue()); // 10
            Console.WriteLine("Kuyruktan Çıkan: " + arrQueue.Dequeue());             // 20

            Console.WriteLine("\n=== BAĞLI LİSTE TABANLI KUYRUK TESTİ ===");
            LinkedQueue linkedQueue = new LinkedQueue();

            linkedQueue.Enqueue(100);
            linkedQueue.Enqueue(200);
            linkedQueue.Enqueue(300);

            Console.WriteLine("Kuyruktan Çıkan (İlk Giren): " + linkedQueue.Dequeue()); // 100
            Console.WriteLine("Kuyruktan Çıkan: " + linkedQueue.Dequeue());             // 200

            Console.ReadLine();
        }
    }
}
