Key:
Large object graphs

Terdapat potensi kebocoran memori yang disebabkan oleh penggunaan grafik objek yang besar. 
Pada setiap iterasi loop, sub-pohon baru dengan 10.000 node dibuat dan ditambahkan ke rootNode.
Seiring berjalannya waktu, jumlah node dalam rootNode akan bertambah tanpa batas, menyebabkan penggunaan memori yang terus meningkat.
kemudian juga tidak ada mekanisme untuk membersihkan atau menghapus node yang tidak diperlukan, memori yang digunakan oleh objek TreeNode tidak akan pernah dibebaskan, menyebabkan kebocoran memori.

Untuk menghindari kebocoran memori, kita harus memastikan bahwa grafik objek yang besar dikelola dengan baik. Salah satu solusi adalah dengan menghapus node yang tidak lagi diperlukan atau membatasi ukuran grafik objek.

using System;
using System.Collections.Generic;

namespace MemoryLeakExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new TreeNode();
            while (true)
            {
                // create a new subtree of 10000 nodes
                var newNode = new TreeNode();
                for (int i = 0; i < 10000; i++)
                {
                    var childNode = new TreeNode();
                    newNode.AddChild(childNode);
                }
                
                rootNode.AddChild(newNode);
                
                // Clear nodes to free up memory
                if (rootNode.ChildrenCount > 10)
                {
                    rootNode.RemoveChild(0); // Remove the oldest child node
                }
            }
        }
    }

    class TreeNode
    {
        private readonly List<TreeNode> _children = new List<TreeNode>();

        public void AddChild(TreeNode child)
        {
            _children.Add(child);
        }

        public void RemoveChild(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                _children.RemoveAt(index);
            }
        }

        public int ChildrenCount => _children.Count;
    }
}


Penjelasan Solusi
Metode RemoveChild ditambahkan untuk menghapus node anak dari daftar _children pada indeks yang ditentukan.
Pembatasan Ukuran Grafik Objek dengan cara pada setiap iterasi loop, setelah menambahkan sub-pohon baru ke rootNode, dilakukan cek jumlah anak dalam rootNode.
Jika jumlah anak lebih dari 10, node anak tertua dihapus menggunakan RemoveChild(0). Ini memastikan bahwa jumlah node dalam rootNode tidak bertambah tanpa batas, membatasi penggunaan memori.

Dengan menambahkan mekanisme untuk menghapus node yang tidak diperlukan, kita dapat menghindari kebocoran memori yang disebabkan oleh grafik objek yang besar. Pendekatan ini membantu menjaga penggunaan memori tetap terkendali dan memastikan bahwa aplikasi berjalan dengan efisien.