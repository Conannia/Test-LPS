Key:
Improper caching

 ada potensi kebocoran memori yang disebabkan oleh penggunaan caching yang tidak tepat. Pada setiap iterasi loop for, objek baru dibuat dan ditambahkan ke cache tanpa ada mekanisme untuk membersihkan atau membatasi ukuran cache. Ini menyebabkan penggunaan memori terus meningkat seiring dengan bertambahnya jumlah item dalam cache.

Pada setiap iterasi loop for, objek baru ditambahkan ke cache menggunakan metode Cache.Add.
Tidak ada mekanisme untuk membersihkan atau menghapus item dari cache, sehingga memori yang digunakan terus meningkat seiring bertambahnya jumlah item dalam cache.
Kebocoran Memori juga terjadi karena cache terus bertambah tanpa batas, penggunaan memori akan terus meningkat hingga akhirnya dapat menyebabkan aplikasi kehabisan memori.

Untuk menghindari kebocoran memori, perlu mengimplementasikan mekanisme untuk membatasi ukuran cache dan membersihkan item yang tidak diperlukan. 
Salah satu pendekatan yang umum digunakan adalah dengan menerapkan cache dengan kapasitas terbatas menggunakan algoritma Least Recently Used (LRU).

using System;
using System.Collections.Generic;

class LRUCache
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<CacheItem>> _cache;
    private readonly LinkedList<CacheItem> _lruList;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
        _lruList = new LinkedList<CacheItem>();
    }

    public void Add(int key, object value)
    {
        if (_cache.ContainsKey(key))
        {
            var node = _cache[key];
            _lruList.Remove(node);
            _lruList.AddFirst(node);
        }
        else
        {
            if (_cache.Count >= _capacity)
            {
                var lruItem = _lruList.Last;
                if (lruItem != null)
                {
                    _lruList.RemoveLast();
                    _cache.Remove(lruItem.Value.Key);
                }
            }

            var newItem = new CacheItem { Key = key, Value = value };
            var newNode = new LinkedListNode<CacheItem>(newItem);
            _lruList.AddFirst(newNode);
            _cache[key] = newNode;
        }
    }

    public object Get(int key)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _lruList.Remove(node);
            _lruList.AddFirst(node);
            return node.Value.Value;
        }
        return null;
    }

    private class CacheItem
    {
        public int Key { get; set; }
        public object Value { get; set; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var cache = new LRUCache(10000);

        for (int i = 0; i < 1000000; i++)
        {
            cache.Add(i, new object());
        }

        Console.WriteLine("Cache populated");
        Console.ReadLine();
    }
}


Penjelasan Solusi:

LRUCache adalah cache dengan kapasitas terbatas yang menggunakan algoritma Least Recently Used (LRU). Ini memastikan bahwa cache tidak akan melebihi kapasitas yang telah ditentukan.
Kapasitas dibatasi juga dengan cara Kapasitas cache nya ditentukan saat membuat instance LRUCache. pada code ini kapasitas ditetapkan ke 10.000.

lalu dilakukan pengelolaan Item dalam Cache dengan cara,
- Jika item dengan kunci yang sama sudah ada di cache, item tersebut dipindahkan ke posisi terdepan dalam daftar LRU.
- Jika cache mencapai kapasitas maksimum, item yang paling jarang digunakan (paling belakang dalam daftar LRU) dihapus dari cache untuk memberi ruang bagi item baru.

Kemudian LinkedList digunakan untuk melacak urutan penggunaan item, dan Dictionary digunakan untuk akses cepat ke item dalam cache.

Dengan mengimplementasikan cache yang memiliki kapasitas terbatas dan menggunakan algoritma LRU, kita dapat menghindari kebocoran memori yang disebabkan oleh penggunaan cache yang tidak tepat. Pendekatan ini memastikan bahwa memori digunakan secara efisien dan cache tidak tumbuh tanpa batas.