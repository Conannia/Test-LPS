Keeping references to objects unnecessarily

terdapat potensi kebocoran memori (memory leak) karena daftar myList terus-menerus bertambah tanpa ada upaya untuk membersihkan atau mengosongkannya. Ini terjadi dalam loop while (true) yang menyebabkan daftar myList terus bertambah besar seiring berjalannya waktu, sehingga memori yang digunakan oleh aplikasi akan terus meningkat.



Pada setiap iterasi while (true), daftar myList diisi dengan 1000 objek Product baru.
Tidak ada upaya untuk mengosongkan atau menghapus elemen dalam daftar myList, sehingga ukurannya terus bertambah dan memori yang digunakan juga meningkat.
Kemudian juga terdapat Referensi yang tidak diperlukan myList terus menampung referensi ke objek Product yang dibuat, memori tidak akan dibebaskan oleh garbage collector, menyebabkan kebocoran memori.

Untuk mencegah kebocoran memori, kita perlu memastikan bahwa daftar myList tidak terus bertambah tanpa batas. Salah satu solusi sederhana adalah dengan mengosongkan daftar myList setelah melakukan operasi tertentu. Berikut adalah contoh modifikasi kodenya

using System;
using System.Collections.Generic;

namespace MemoryLeakExample
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var myList = new List<Product>();
                
                // populate list with 1000 integers
                for (int i = 0; i < 1000; i++)
                {
                    myList.Add(new Product(Guid.NewGuid().ToString(), i));
                }

                // do something with the list object
                Console.WriteLine(myList.Count);

                // Clear the list to free up memory
                myList.Clear();
            }
        }
    }

    class Product
    {
        public Product(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
        public string SKU { get; set; }
        public decimal Price { get; set; }
    }
}

Dengan mendeklarasikan myList di dalam loop while (true), kita memastikan bahwa setiap iterasi loop akan membuat daftar baru, yang akan menghapus referensi ke daftar sebelumnya dan memungkinkan garbage collector untuk membebaskan memori yang tidak lagi digunakan.

Sebelum memulai iterasi baru, kita dapat mengosongkan daftar dengan memanggil myList.Clear(). Ini akan menghapus semua elemen dalam daftar, membebaskan memori yang digunakan oleh objek Product.

Dengan memastikan bahwa referensi objek tidak disimpan lebih lama dari yang diperlukan, kita dapat menghindari kebocoran memori. Pendekatan ini penting dalam aplikasi yang berjalan terus-menerus atau dalam jangka waktu lama untuk menjaga penggunaan memori tetap efisien dan stabil.