using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppKaryawan
{
    public class Karyawan
    {
        public Karyawan(int id, string nama, string jk, int umur, string jabatan)
        {
            Id              = id;
            Nama            = nama;
            JenisKelamin    = jk;
            Umur            = umur;
            Jabatan         = jabatan;
        }
        public int Id { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public int Umur { get; set; }
        public string Jabatan { get; set; }
    }
}
