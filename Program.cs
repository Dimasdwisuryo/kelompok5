// # Kelas:IS-07-04 //
// # Kelompok:5 //
// # Anggota Kelompok: //
// #1. Gita Naisya Wardani (102062400034) //
// #2. Azizah Fitria Wibisono (102062400142) //
// #3. Dimas Arya Irwansyah (102062400113) //
// #4. Dimas Dwi Suryo Aji (102062400139) //

using System;
using System.Collections.Generic;
using System.Linq;

namespace AplikasiManajemenBioskop_0405
{
    class Film
    {
        public int Id { get; set; }
        public int Durasi { get; set; }
        public string? Judul { get; set; }
        public string? Genre { get; set; }
        public double Harga { get; set; }
    }

    class Pemesanan
    {
        public int Id { get; set; }
        public string? NamaPembeli { get; set; }
        public string? JudulFilm { get; set; }
        public string? JamTayang { get; set; }
        public string? Kursi { get; set; }
        public string? Kategori { get; set; }
        public double HargaTiket { get; set; }
        public double Diskon { get; set; }
        public double TotalBayar { get; set; }
        public double Kembalian { get; set; }
    }

    class Program
    {
        static List<Film> daftarFilm = new List<Film>();
        static List<Pemesanan> daftarPemesanan = new List<Pemesanan>();
        static int idCounter = 1;
        static int idPemesananCounter = 1;

        static void Main(string[] args)
        {
            // Cek login terlebih dahulu
            if (Login_0405())
            {
                Console.WriteLine("Selamat datang di kasir bioskop!");

                // Program utama yang berjalan terus-menerus
                while (true)
                {
                    // Menampilkan menu
                    Console.WriteLine("=== Aplikasi Manajemen Bioskop ===");
                    Console.WriteLine("1. Tambah Film");
                    Console.WriteLine("2. Tampilkan Semua Film");
                    Console.WriteLine("3. Update Film");
                    Console.WriteLine("4. Hapus Film");
                    Console.WriteLine("5. Cari Film");
                    Console.WriteLine("6. Filter Film Berdasarkan Durasi");
                    Console.WriteLine("7. Pemesanan Tiket");
                    Console.WriteLine("8. Tampilkan Invoice");
                    Console.WriteLine("9. Keluar");
                    Console.Write("Pilih menu: ");

                    // Membaca input dari pengguna
                    string? input = Console.ReadLine();

                    try
                    {
                        // Mengonversi input ke angka (int)
                        int pilihan_0405 = Convert.ToInt32(input);

                        // Mengeksekusi pilihan sesuai menu
                        switch (pilihan_0405)
                        {
                            case 1:
                                TambahFilm_0405();
                                break;
                            case 2:
                                LihatFilm_0405();
                                break;
                            case 3:
                                UpdateFilm_0405();
                                break;
                            case 4:
                                HapusFilm_0405();
                                break;
                            case 5:
                                CariFilm_0405();
                                break;
                            case 6:
                                FilterFilm_0405();
                                break;
                            case 7:
                                PemesananTiket_0405();
                                break;
                            case 8:
                                TampilkanInvoice_0405();
                                break;
                            case 9:
                                Console.WriteLine("Terima kasih telah menggunakan aplikasi ini!");
                                return; // Keluar dari program
                            default:
                                throw new FormatException("Harap masukkan angka sesuai menu (1-9).");
                        }
                    }
                    catch (FormatException)
                    {
                        // Menangkap kesalahan jika input bukan angka
                        Console.WriteLine("Input tidak valid." + "Harap masukkan angka sesuai menu (1-9).");
                    }
                }
            }
            else
            {
                // Jika login gagal
                Console.WriteLine("Username atau password salah.");
            }
        }


        static bool Login_0405() // Untuk login kasir
        {
            try
            {
                Console.WriteLine("=== Login Kasir Bioskop ===");
                Console.Write("Masukkan username: ");
                string? username = Console.ReadLine();
                Console.Write("Masukkan password: ");
                string? password = Console.ReadLine();

                // Validasi input username dan password
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    throw new FormatException("Username atau password tidak boleh kosong.");
                }

                if (username == "admin" && password == "admin")
                {
                    Console.WriteLine("Login berhasil!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Login gagal.");
                    return false;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Terjadi kesalahan: " + ex.Message);
                return false;
            }
        }

        static void TambahFilm_0405() // Untuk fitur menambahkan film
        {
            try
            {
                Console.WriteLine("=== Tambah Film ===");
                Console.Write("Masukkan Judul Film: ");
                string? judul = Console.ReadLine();

                Console.Write("Masukkan Durasi Film (dalam menit): ");
                int durasi = int.Parse(Console.ReadLine());

                Console.Write("Masukkan Genre Film: ");
                string? genre = Console.ReadLine();

                Console.Write("Masukkan Harga Tiket: Rp.");
                if (double.TryParse(Console.ReadLine(), out double harga))
                {
                    Film filmBaru = new Film
                    {
                        Id = idCounter++,
                        Judul = judul,
                        Durasi = durasi,
                        Genre = genre,
                        Harga = harga
                    };
                    daftarFilm.Add(filmBaru);
                    Console.WriteLine("Film berhasil ditambahkan.");
                }
                else
                {
                    throw new FormatException("Harga harus berupa angka.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input tidak valid: " + ex.Message);
            }
        }

        static void LihatFilm_0405() // Untuk menampilkan daftar film yang sudah ditambahkan
        {
            try
            {
                Console.WriteLine("=== Daftar Film ===");
                if (daftarFilm.Count == 0)
                {
                    Console.WriteLine("Belum ada film yang terdaftar.");
                    return;
                }

                foreach (var film in daftarFilm)
                {
                    Console.WriteLine($"ID: {film.Id}, Judul: {film.Judul}, Durasi: {film.Durasi} menit, Genre: {film.Genre}, Harga: Rp.{film.Harga}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan saat menampilkan daftar film: " + ex.Message);
            }
        }

        static void UpdateFilm_0405() // Untuk mengubah film jika ada kesalahan input
        {
            try
            {
                Console.WriteLine("=== Update Film ===");
                Console.Write("Masukkan ID Film yang ingin diubah: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var film = daftarFilm.Find(f => f.Id == id);
                    if (film != null)
                    {
                        Console.Write("Masukkan Judul Film Baru: ");
                        film.Judul = Console.ReadLine();

                        Console.Write("Masukkan Durasi Film Baru (dalam menit): ");
                        film.Durasi = int.Parse(Console.ReadLine());

                        Console.Write("Masukkan Genre Film Baru: ");
                        film.Genre = Console.ReadLine();

                        Console.Write("Masukkan Harga Tiket Baru: Rp.");
                        if (double.TryParse(Console.ReadLine(), out double hargaBaru))
                        {
                            film.Harga = hargaBaru;
                            Console.WriteLine("Data film berhasil diubah.");
                        }
                        else
                        {
                            throw new FormatException("Harga harus berupa angka.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Film dengan ID tersebut tidak ditemukan.");
                    }
                }
                else
                {
                    throw new FormatException("ID harus berupa angka.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input tidak valid: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan saat mengupdate film: " + ex.Message);
            }
        }

        static void HapusFilm_0405() // Untuk menghapus film jika ada kesalahan input
        {
            try
            {
                Console.WriteLine("=== Hapus Film ===");
                Console.Write("Masukkan ID Film yang ingin dihapus: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var film = daftarFilm.Find(f => f.Id == id);
                    if (film != null)
                    {
                        daftarFilm.Remove(film);
                        Console.WriteLine("Film berhasil dihapus.");
                    }
                    else
                    {
                        Console.WriteLine("Film dengan ID tersebut tidak ditemukan.");
                    }
                }
                else
                {
                    throw new FormatException("ID harus berupa angka.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input tidak valid: " + ex.Message);
            }
        }

        static void CariFilm_0405() // Untuk mencari film dengan judul yang di inputkan
        {
            try
            {
                Console.WriteLine("=== Cari Film ===");
                Console.Write("Masukkan Judul Film yang ingin dicari: ");
                string? judul = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(judul)) // Validasi input jika user mengisi dengan enter atau dikosongi
                {
                    Console.WriteLine("Judul film tidak boleh kosong.");
                    return;
                }

                var hasil = daftarFilm.Where(f => f.Judul != null && f.Judul.ToLower().Contains(judul)).ToList();
                if (hasil.Count > 0)
                {
                    foreach (var film in hasil)
                    {
                        Console.WriteLine($"ID: {film.Id}, Judul: {film.Judul}, Durasi: {film.Durasi} menit, Genre: {film.Genre}, Harga: Rp.{film.Harga}");
                    }
                }
                else
                {
                    throw new FormatException("Film tidak ditemukan.");
                }
            }
            catch (FormatException ex) // Eror handling atau memberi informasi pada user
            {
                Console.WriteLine("Terjadi kesalahan: " + ex.Message);
            }
        }

        static void FilterFilm_0405()
        {
            try
            {
                Console.WriteLine("=== Filter Film Berdasarkan Durasi ===");
                Console.Write("Masukkan Durasi Film yang ingin difilter: ");
                int durasi = int.Parse(Console.ReadLine());

                var films = daftarFilm.FindAll(f => f.Durasi == durasi);
                if (films != null && films.Count > 0)
                {
                    foreach (var film in films)
                    {
                        Console.WriteLine($"ID: {film.Id}, Judul: {film.Judul}, Durasi: {film.Durasi} menit, Genre: {film.Genre}, Harga: Rp.{film.Harga}");
                    }
                }
                else
                {
                    throw new Exception("Film tidak ditemukan.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan saat filter film: " + ex.Message);
            }
        }

        static void PemesananTiket_0405()
        {
            try
            {
                Console.WriteLine("=== Pemesanan Tiket ===");
                Console.Write("Masukkan Nama Pembeli: ");
                string? namaPembeli = Console.ReadLine();

                Console.Write("Masukkan ID Film: ");
                if (int.TryParse(Console.ReadLine(), out int idFilm))
                {
                    var film = daftarFilm.Find(f => f.Id == idFilm);
                    if (film != null)
                    {
                        Console.Write("Masukkan Jam Tayang: ");
                        string? jamTayang = Console.ReadLine();

                        // Tampilkan kursi yang tersedia
                        Console.WriteLine("Kursi yang tersedia: ");
                        var kursiTersedia = new HashSet<string> { "A1", "A2", "A3", "A4", "A5", "B1", "B2", "B3", "B4", "B5" };

                        // Hapus kursi yang sudah dipesan untuk film dan jam tayang tersebut
                        foreach (var pemesanan in daftarPemesanan)
                        {
                            if (pemesanan.JudulFilm == film.Judul && pemesanan.JamTayang == jamTayang)
                            {
                                kursiTersedia.Remove(pemesanan.Kursi);
                            }
                        }

                        if (kursiTersedia.Count == 0)
                        {
                            Console.WriteLine("Maaf, semua kursi telah dipesan untuk jam tayang ini.");
                            return;
                        }

                        Console.WriteLine(string.Join(", ", kursiTersedia));

                        Console.Write("Masukkan Nomor Kursi (pisahkan dengan koma jika memilih lebih dari satu): ");
                        string? inputKursi = Console.ReadLine();
                        var kursiDipilih = inputKursi?.Split(',').Select(k => k.Trim()).ToList();

                        if (kursiDipilih == null || kursiDipilih.Count == 0 || !kursiDipilih.All(k => kursiTersedia.Contains(k)))
                        {
                            Console.WriteLine("Satu atau lebih kursi yang dipilih tidak tersedia atau sudah dipesan. Silakan coba lagi.");
                            return;
                        }

                        Console.WriteLine("Masukkan Kategori Tiket: ");
                        Console.WriteLine("1. Reguler");
                        Console.WriteLine("2. Premium");
                        Console.WriteLine("3. VVIP");
                        Console.Write("Pilih kategori: ");
                        string? kategori = Console.ReadLine();

                        double hargaTiket = film.Harga;
                        double diskon = 0;

                        switch (kategori)
                        {
                            case "1":
                                kategori = "Reguler";
                                break;
                            case "2":
                                kategori = "Premium";
                                hargaTiket = 1.5 * hargaTiket;
                                break;
                            case "3":
                                kategori = "VVIP";
                                hargaTiket = 2 * hargaTiket;
                                break;
                            default:
                                Console.WriteLine("Kategori tidak valid.");
                                return;
                        }

                        Console.WriteLine("Kode Diskon (opsional): ");
                        string? kodeDiskon = Console.ReadLine();
                        if (kodeDiskon == "DISKON10")
                        {
                            diskon = 0.1 * hargaTiket;
                        }
                        else if (kodeDiskon == "DISKON20")
                        {
                            diskon = 0.2 * hargaTiket;
                        }
                        else if (!string.IsNullOrEmpty(kodeDiskon))
                        {
                            Console.WriteLine("Kode diskon tidak valid.");
                            return;
                        }

                        double totalBayar = (hargaTiket - diskon) * kursiDipilih.Count;

                        Console.WriteLine("Pilih metode pembayaran: ");
                        Console.WriteLine("1. Tunai");
                        Console.WriteLine("2. Non-Tunai");
                        Console.Write("Pilih metode pembayaran: ");
                        string? metodePembayaran = Console.ReadLine();

                        if (metodePembayaran == "1")
                        {
                            Console.WriteLine("=== Pembayaran Tunai ===");
                            Console.Write("Masukkan jumlah uang: Rp. ");
                            if (double.TryParse(Console.ReadLine(), out double uangBayar))
                            {
                                if (uangBayar < totalBayar)
                                {
                                    Console.WriteLine("Uang tidak cukup untuk membayar.");
                                    return;
                                }
                                else
                                {
                                    double kembalian = uangBayar - totalBayar;
                                    Console.WriteLine($"Pembayaran berhasil. Kembalian: Rp.{kembalian}");
                                }
                            }
                            else
                            {
                                throw new FormatException("Jumlah uang harus berupa angka.");
                            }
                        }
                        else if (metodePembayaran == "2")
                        {
                            Console.WriteLine("=== Pembayaran Non-Tunai ===");
                            Console.Write("Masukkan nomor kartu kredit: ");
                            string? nomorKartu = Console.ReadLine();

                            Console.Write("Masukkan nama pemilik kartu: ");
                            string? namaPemilikKartu = Console.ReadLine();
                            if (string.IsNullOrEmpty(namaPemilikKartu) || namaPemilikKartu != namaPembeli)
                            {
                                Console.WriteLine("Nama pemilik kartu tidak sesuai dengan nama pembeli.");
                                return;
                            }
                            Console.WriteLine("Pembayaran berhasil menggunakan kartu kredit.");
                        }
                        else
                        {
                            Console.WriteLine("Metode pembayaran tidak valid. Silakan coba lagi.");
                            return;
                        }

                        // Tandai kursi sebagai dipesan
                        foreach (var kursi in kursiDipilih)
                        {
                            Pemesanan pemesananBaru = new Pemesanan
                            {
                                Id = idPemesananCounter++,
                                NamaPembeli = namaPembeli,
                                JudulFilm = film.Judul,
                                JamTayang = jamTayang,
                                Kursi = kursi,
                                Kategori = kategori,
                                HargaTiket = hargaTiket,
                                Diskon = diskon,
                                TotalBayar = (hargaTiket - diskon)
                            };

                            // Tambahkan pemesanan ke daftar pemesanan
                            daftarPemesanan.Add(pemesananBaru);
                        }

                        Console.WriteLine("Pemesanan berhasil. Kursi yang Anda pilih: " + string.Join(", ", kursiDipilih));
                    }
                    else
                    {
                        Console.WriteLine("Film tidak ditemukan.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("ID Film tidak valid.");
                    return;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input tidak valid: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan saat pemesanan tiket: " + ex.Message);
            }
        }


        // Tampilkan Invoice
        static void TampilkanInvoice_0405()
        {
            Console.WriteLine("=== Invoice Pemesanan ===");
            if (daftarPemesanan.Count == 0)
            {
                Console.WriteLine("Belum ada pemesanan.");
                return;
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("| ID  | Nama Pembeli    | Film           | Jam   | Kursi   |");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var pemesanan in daftarPemesanan)
            {
                Console.WriteLine($"| {pemesanan.Id,-4} | {pemesanan.NamaPembeli,-15} | {pemesanan.JudulFilm,-14} | {pemesanan.JamTayang,-5} | {pemesanan.Kursi,-7} |");
            }

            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("=== Detail Pemesanan ===");
            foreach (var pemesanan in daftarPemesanan)
            {
                Console.WriteLine($"ID Pemesanan   : {pemesanan.Id}");
                Console.WriteLine($"Nama Pembeli   : {pemesanan.NamaPembeli}");
                Console.WriteLine($"Judul Film     : {pemesanan.JudulFilm}");
                Console.WriteLine($"Jam Tayang     : {pemesanan.JamTayang}");
                Console.WriteLine($"Kursi          : {pemesanan.Kursi}");
                Console.WriteLine($"Kategori Tiket : {pemesanan.Kategori}");
                Console.WriteLine($"Harga Tiket    : Rp.{pemesanan.HargaTiket:N}");
                Console.WriteLine($"Diskon         : Rp.{pemesanan.Diskon:N}");
                Console.WriteLine($"Total Bayar    : Rp.{pemesanan.TotalBayar:N}");

                // Cek apakah ada kembalian (hanya jika metode pembayaran adalah tunai)
                if (pemesanan.Kembalian > 0)
                {
                    Console.WriteLine($"Kembalian      : Rp.{pemesanan.Kembalian:N}");
                }
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

    }
}
