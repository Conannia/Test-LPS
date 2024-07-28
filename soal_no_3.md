modifications by using private members.

class Laptop
{
    private string _os; // Anggota private

    public string GetOs()
    {
        return _os;
    }

    public void SetOs(string os)
    {
        // logika validasi  jika diperlukan
        _os = os;
    }

    public Laptop(string os)
    {
        _os = os;
    }
}

// Penggunaan
var laptop = new Laptop("macOs");
Console.WriteLine("Laptop OS: " + laptop.GetOs()); // Output: Laptop OS: macOs

// Modifikasi OS
laptop.SetOs("Windows");
Console.WriteLine("Laptop OS: " + laptop.GetOs()); // Output: Laptop OS: Windows

Penjelasan:

member private:

Properti Os diubah menjadi member private bernama _os. Ini memastikan bahwa _os hanya bisa diakses dan dimodifikasi melalui metode yang disediakan oleh kelas Laptop.
Metode GetOs dan SetOs:

Metode public GetOs digunakan untuk mengakses nilai _os.
Metode public SetOs digunakan untuk mengubah nilai _os. Di dalam metode ini, 
Konstruktor:

Konstruktor Laptop tetap digunakan untuk menginisialisasi nilai _os ketika objek Laptop dibuat.


Saat membuat objek Laptop, kita bisa mengakses nilai OS menggunakan metode GetOs dan mengubahnya menggunakan metode SetOs.

Dengan menggunakan anggota private dan metode public untuk mengakses dan memodifikasi nilai, kita dapat mengontrol akses dan modifikasi properti dengan lebih baik. Pendekatan ini memungkinkan kita untuk menambahkan logika validasi atau pembatasan pada saat pengubahan nilai, sehingga lebih aman dan fleksibel dibandingkan dengan penggunaan properti public langsung.