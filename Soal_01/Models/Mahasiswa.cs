namespace Soal01.Models;

/// <summary>
/// Soal 1: Data Mahasiswa
/// Lengkapi seluruh bagian TODO sesuai instruksi soal.
/// </summary>
public class Mahasiswa
{
    public string NIM { get; set; } = string.Empty;
    public string Nama { get; set; } = string.Empty;
    public string ProgramStudi { get; set; } = string.Empty;
    public int Semester { get; set; }
    public decimal IPK { get; set; }

    public Mahasiswa()
    {
        // TODO 1: Lengkapi inisialisasi objek jika diperlukan.
        Initialize();
    }
    private void BlokirSimbol(object sender, KeyPressEventArgs e)
    {
        if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true; // Blokir input simbol
        }
    }

    private void Initialize()
    {
        NIM = string.Empty;
        Nama = string.Empty;
        ProgramStudi = string.Empty;
        Semester = 0;
        IPK = 0.0m;
    }

    // TODO 2: Buat/implementasikan aturan bisnis untuk soal ini.
    // Petunjuk fungsi yang wajib dibuat: Validasi(), UpdateIPK(decimal nilai), ToString()
    public bool Validasi()
    {
        return !string.IsNullOrWhiteSpace(NIM) &&
               !string.IsNullOrWhiteSpace(Nama) &&
               !string.IsNullOrWhiteSpace(ProgramStudi) &&
               Semester > 0 &&
               IPK >= 0.0m && IPK <= 4.0m;
    }
    

    public void UpdateIPK(decimal nilai)
    {
        if (nilai >= 0.0m && nilai <= 4.0m)
        {
            IPK = nilai;
        }
        else
        {
            MessageBox.Show("IPK harus antara 0.0 dan 4.0.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public override string ToString()
    {
        return $"NIM: {NIM}, Nama: {Nama}, Program Studi: {ProgramStudi}, Semester: {Semester}, IPK: {IPK}";
    }

    public virtual string TampilkanInfo()
    {
        // TODO 3: Kembalikan informasi objek dalam format yang mudah dibaca.
        return $"NIM: {NIM}\nNama: {Nama}\nProgram Studi: {ProgramStudi}\nSemester: {Semester}\nIPK: {IPK:F2}";
    }
}
