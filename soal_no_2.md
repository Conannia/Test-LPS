//kode asli
public ApplicationInfo GetInfo()
{
 var application = new ApplicationInfo
 {
 Path = "C:/apps/",
 Name = "Shield.exe"
 };
 return application;
}
Deklarasi Metode:
Metode GetInfo adalah metode publik yang mengembalikan objek ApplicationInfo.

Inisialisasi Objek:
Di dalam metode GetInfo, objek ApplicationInfo diinisialisasi dengan nilai properti Path dan Name.

Pengembalian Objek:
Metode ini mengembalikan objek application yang berisi dua nilai: Path dan Name.

Alternatif lain adalah menggunakan Tuple untuk mengembalikan beberapa nilai tanpa harus mendefinisikan class baru.
public (string Path, string Name) GetInfo()
{
    var path = "C:/apps/";
    var name = "Shield.exe";
    return (path, name);
}

// Memanggil metode
var info = GetInfo();
Console.WriteLine($"Path: {info.Path}, Name: {info.Name}");

Penjelasan Tuple:
Deklarasi Metode:
Metode GetInfo mengembalikan tuple yang berisi dua nilai: Path dan Name.

Pengembalian Nilai:
Di dalam metode, dua nilai path dan name dikembalikan sebagai tuple.

Mengakses Nilai:
Ketika memanggil metode GetInfo, kita dapat mengakses nilai yang dikembalikan menggunakan properti tuple.

Kesimpulan:
Menggunakan class atau tuple adalah cara yang efektif untuk mengembalikan lebih dari satu nilai dari suatu metode. Pemilihan metode tergantung pada kompleksitas dan kebutuhan spesifik dari aplikasi. Jika nilai yang dikembalikan memiliki hubungan logis dan sering digunakan bersama, mendefinisikan class baru seperti ApplicationInfo adalah pilihan yang baik. Namun, jika hanya diperlukan untuk pengembalian nilai sementara atau sederhana, menggunakan tuple dapat menjadi solusi yang lebih cepat dan mudah.