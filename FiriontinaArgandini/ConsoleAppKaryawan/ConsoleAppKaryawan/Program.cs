using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppKaryawan
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.WriteLine("\n\tKARYAWAN");
            Console.WriteLine("======================================");
            Console.WriteLine("\t1. Lihat Data Karyawan");
            Console.WriteLine("\t2. Tambah Data Karyawan");
            Console.WriteLine("\t3. Ubah Data Karyawan");
            Console.WriteLine("\t4. Hapus Data Karyawan");
            Console.WriteLine("\t5. Keluar");

            ulang:;
            Console.Write("\nMasukkan Pilihan : ");

            string input    = Console.ReadLine();
            int pilihan     = Convert.ToInt16(input);

            switch (pilihan)
            {
                case 1: TampilDataKaryawan(listKaryawan); break;
                case 2: TambahDataKaryawan(); break;
                case 3: UbahDataKaryawan(); break;
                case 4: HapusDataKaryawan(); break;
                case 5: Environment.Exit(0); break;
                default: 
                {
                    Console.WriteLine("Pilihan tersebut tidak terdapat dalam menu");
                    goto ulang;
                }
            }
        }
        private static List<Karyawan> listKaryawan = new List<Karyawan>()
        {
            new Karyawan(1, "Entol Rasyad Muhammad", "Laki - laki", 20, "Karyawan"),
            new Karyawan(2, "Firiontina Argan Dini", "Perempuan", 20, "Karyawan"),
            new Karyawan(3, "Kovalevshero Al Fayyad", "Laki - laki", 19, "Karyawan")
        };
        private static void TampilDataKaryawan(List<Karyawan> listKaryawan)
        {
            var tampil = (from a in listKaryawan
                          select a).ToList();

            Console.WriteLine("\n\t\t\t\t\tDATA KARYAWAN\n");
            Console.WriteLine("ID \t Nama Karyawan \t\t\t Jenis Kelamin \t Umur \t Jabatan");
            Console.WriteLine("======================================================================================");
            foreach (var employee in tampil)
            {
                Console.Write(employee.Id); Console.Write("\t");
                Console.Write(employee.Nama); Console.Write("\t\t");
                Console.Write(employee.JenisKelamin); Console.Write("\t");
                Console.Write(employee.Umur); Console.Write("\t");
                Console.Write(employee.Jabatan); Console.Write("\n");
            }
            Console.WriteLine("\n\n\n");
            Menu();
        }

        private static void TambahDataKaryawan()
        {
            List<Karyawan> addListKaryawan = new List<Karyawan>();
            Console.Write("ID\t\t : "); string inputId = Console.ReadLine(); int id = Convert.ToInt16(inputId);
            Console.Write("Nama\t\t : "); string nama = Console.ReadLine();
            Console.Write("Jenis Kelamin\t : "); string jk = Console.ReadLine();
            Console.Write("Umur\t\t : "); string inputUmur = Console.ReadLine(); int umur = Convert.ToInt16(inputUmur);
            Console.Write("Jabatan\t\t : "); string jabatan = Console.ReadLine();

            addListKaryawan.Add(new Karyawan (id, nama, jk, umur, jabatan));
            listKaryawan.AddRange(addListKaryawan);;
            Console.WriteLine("\n\n\n");
            Menu();         
        }

        private static void UbahDataKaryawan()
        {
            List<Karyawan> updateListKaryawan = listKaryawan;
            Console.Write("\nMasukkan ID karyawan yang akan diubah : "); string input = Console.ReadLine(); int id = Convert.ToInt16(input);
            
            Console.Write("ID\t\t : " +id);
            Console.Write("\nNama\t\t : "); string nama = Console.ReadLine();
            Console.Write("Jenis Kelamin\t : "); string jk = Console.ReadLine();
            Console.Write("Umur\t\t : "); string inputUmur = Console.ReadLine(); int umur = Convert.ToInt16(inputUmur);
            Console.Write("Jabatan\t\t : "); string jabatan = Console.ReadLine();

            listKaryawan.Where(x => x.Id == id).Select(u => { u.Nama = nama; u.JenisKelamin = jk; u.Umur = umur; u.Jabatan = jabatan; return u; }).ToList();
            Menu();
        }

        private static void HapusDataKaryawan()
        {
            List<Karyawan> removeListKaryawan = listKaryawan;
            Console.Write("\nMasukkan ID karyawan yang akan dihapus : "); string inputId = Console.ReadLine(); int id = Convert.ToInt16(inputId);

            removeListKaryawan.RemoveAll(delegate (Karyawan employee) { return employee.Id == id; });
            Console.WriteLine("\n\n\n");
            Menu();
        }

    }
}
