namespace DataStructures.Hashing
{
    // Ders notlarındaki 'blockt' yapısının Hashing'e uyarlanmış hali
    public class HashNode
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public HashNode Next { get; set; } // Çakışma durumunda bir sonraki düğümü gösterir

        public HashNode(string key, int value)
        {
            Key = key;
            Value = value;
            Next = null; // .NET otomatik sıfırlasa da ders notlarındaki gibi açıkça yazıldı
        }
    }
}

using System;

namespace DataStructures.Hashing
{
    public class HashTable
    {
        // Ders notlarındaki sabit boyutlu dizi mantığı (Örn: Stack için 100 eleman sınırı gibi)
        private const int TableSize = 10; 
        private HashNode[] buckets;

        public HashTable()
        {
            buckets = new HashNode[TableSize];
            // Başlangıçta tüm bucket'lar null'dır (Boş tablo)
        }

        // --- HASH FONKSİYONU ---
        // Gönderilen string anahtarı (Key) tablonun boyutuna göre bir indekse dönüştürür.
        // Hocanızın ASCII değer çıkarma mantığı kullanılmıştır (s[i] - '0' örneğindeki gibi).
        private int GetHash(string key)
        {
            int hashValue = 0;
            foreach (char ch in key)
            {
                hashValue += ch; // Karakterlerin ASCII değerlerini topluyoruz
            }
            return hashValue % TableSize; // Mod alma işlemi ile tablo sınırları içinde tutuyoruz
        }

        // --- ELEMAN EKLEME (PUT / INSERT) ---
        public void Put(string key, int value)
        {
            int index = GetHash(key);
            HashNode head = buckets[index];

            // 1. Durum: Anahtar zaten varsa değerini güncelle (Ders notlarındaki arama/güncelleme mantığı)
            HashNode temp = head;
            while (temp != null)
            {
                if (temp.Key == key)
                {
                    temp.Value = value;
                    return;
                }
                temp = temp.Next;
            }

            // 2. Durum: Çakışma (Collision) var veya slot tamamen boş. 
            // Yeni elemanı bağlı listenin BAŞINA ekliyoruz (Ders notlarındaki 'head2 = bt' mantığı).
            HashNode newNode = new HashNode(key, value);
            newNode.Next = buckets[index];
            buckets[index] = newNode;
        }

        // --- ELEMAN GETİRME (GET / SEARCH) ---
        public int Get(string key)
        {
            int index = GetHash(key);
            HashNode temp = buckets[index];

            // Bağlı listede anahtarı recursive olmayan temiz bir while döngüsüyle arıyoruz
            while (temp != null)
            {
                if (temp.Key == key)
                {
                    return temp.Value; // Değer bulundu
                }
                temp = temp.Next;
            }

            // Sınavlarda hata yönetimini göstermek adına, bulunamadığında -1 dönüyoruz 
            // (Hocanızın Stack boşken -1 dönme kuralına uygun olarak).
            return -1; 
        }

        // --- TABLOYU GÖRSELLEŞTİRME (DISPLAY) ---
        // Ders notlarındaki 'linkedyaz' fonksiyonunun mantığıyla tabloyu ekrana basar
        public void DisplayTable()
        {
            Console.WriteLine("\n--- HASH TABLE DURUMU ---");
            for (int i = 0; i < TableSize; i++)
            {
                Console.Write($"Slot [{i}]: ");
                HashNode temp = buckets[i];
                while (temp != null)
                {
                    Console.Write($"({temp.Key} -> {temp.Value}) -> ");
                    temp = temp.Next;
                }
                Console.WriteLine("null");
            }
            Console.WriteLine("-------------------------\n");
        }
    }
}

using System;
using DataStructures.Hashing;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new HashTable();

            // Verilerin eklenmesi
            table.Put("Ahmet", 85);
            table.Put("Mehmet", 92);
            table.Put("Ayşe", 74);
            
            // Çakışma ihtimali yüksek veriler ekleyerek zincirleme (chaining) yapısını test edelim
            table.Put("Ali", 100);
            table.Put("Veli", 60); 

            // Tablonun görsel halini ekrana basalım
            table.DisplayTable();

            // Eleman arama testi
            string arananKey = "Mehmet";
            int sonuc = table.Get(arananKey);
            
            if (sonuc != -1)
                Console.WriteLine($"{arananKey} anahtarına ait değer: {sonuc}");
            else
                Console.WriteLine($"{arananKey} tablonun içinde bulunamadı!");

            Console.ReadLine();
        }
    }
}
