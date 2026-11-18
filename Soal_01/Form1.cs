using System;
using System.Windows.Forms;
using Soal01.Models;
using Soal01.Services;

namespace Soal01;

public class Form1 : Form
{
    private readonly MahasiswaService service = new();
    private readonly DataGridView grid = new();
    private readonly TextBox txtIdentitas = new();
    private readonly TextBox txtNama = new();
    private readonly Button btnTambah = new();
    private readonly Button btnHapus = new();
    private readonly Button btnMuat = new();

    public Form1()
    {
        Text = "Soal 1 - Data Mahasiswa";
        Width = 900;
        Height = 600;
        StartPosition = FormStartPosition.CenterScreen;

        var lblId = new Label { Text = "Kode/Identitas", Left = 20, Top = 20, Width = 120 };
        txtIdentitas.SetBounds(150, 18, 220, 28);
        var lblNama = new Label { Text = "Nama/Judul", Left = 20, Top = 60, Width = 120 };
        txtNama.SetBounds(150, 58, 220, 28);

        btnTambah.Text = "Tambah";
        btnTambah.SetBounds(390, 18, 100, 32);
        btnHapus.Text = "Hapus";
        btnHapus.SetBounds(500, 18, 100, 32);
        btnMuat.Text = "Muat Data";
        btnMuat.SetBounds(610, 18, 110, 32);

        grid.SetBounds(20, 110, 840, 410);
        grid.ReadOnly = true;
        grid.AllowUserToAddRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        Controls.AddRange(new Control[] { lblId, txtIdentitas, lblNama, txtNama,
            btnTambah, btnHapus, btnMuat, grid });

        btnTambah.Click += (_, _) => TambahData();
        btnHapus.Click += (_, _) => HapusData();
        btnMuat.Click += (_, _) => TampilkanData();
    }

    private void TambahData()
    {
        // TODO 7: Ambil nilai dari TextBox dan NumericUpDown/ComboBox tambahan.
        var nim = txtIdentitas.Text;
        var nama = txtNama.Text;

        // TODO 8: Buat objek Mahasiswa, validasi, lalu panggil service.Tambah().
        // MessageBox.Show("Lengkapi event TambahData().");
        Mahasiswa mahasiswa = new Mahasiswa
        {
            NIM = nim,
            Nama = nama,
            ProgramStudi = "Teknik Informatika", //default
            Semester = 1,
            IPK = 2.0m
        };

        try
        {
            service.Tambah(mahasiswa);
            MessageBox.Show("Data mahasiswa berhasil ditambahkan", "Tes satu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TampilkanData();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Salahki ini bang", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void HapusData()
    {
        // TODO 9: Pastikan baris dipilih, ambil identitas, lalu panggil service.Hapus().
        //MessageBox.Show("Lengkapi event HapusData().");
        foreach (DataGridViewRow row in grid.SelectedRows)
        {
            if (row.DataBoundItem is Mahasiswa coba)
            {
                service.Hapus(coba.NIM);
            }
        }
        TampilkanData();
    }

    private void TampilkanData()
    {
        // TODO 10: Tampilkan service.SemuaData pada DataGridView.
        grid.DataSource = null;
        grid.DataSource = service.SemuaData.ToList();
    }
}
