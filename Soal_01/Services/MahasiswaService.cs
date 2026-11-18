using System.Collections.Generic;
using Soal01.Models;

namespace Soal01.Services;

/// <summary>Tempatkan logika aplikasi di service, jangan menumpuk semua logika di Form1.</summary>
public class MahasiswaService
{
    private readonly List<Mahasiswa> data = new();

    public IReadOnlyList<Mahasiswa> SemuaData => data.AsReadOnly();

    public void Tambah(Mahasiswa item)
    {
        // TODO 4: Validasi item dan tambahkan ke koleksi.
        if (item.Validasi())
        {
            data.Add(item);
            if (item.IPK < 0.0m || item.IPK > 4.0m)
            {
                throw new ArgumentException("IPK mahasiswa tidak valid");
            }
        }
        else
        {
            throw new ArgumentException("Data Mahasiswa tidak valid");
        }
    }

    public bool Hapus(string id)
    {
        // TODO 5: Cari data berdasarkan identitas unik lalu hapus.
        var mahasiswa = Cari(id);
        if (mahasiswa != null)
        {
            data.Remove(mahasiswa);
            return true;
        }
        return false;
    }

    public Mahasiswa? Cari(string id)
    {
        // TODO 6: Cari dan kembalikan data; null jika tidak ditemukan.
        if (string.IsNullOrWhiteSpace(id))
        {
            return null;
        }   

        return data.FirstOrDefault(m => m.NIM == id);
    }
}
