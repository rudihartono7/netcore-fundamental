using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tugasRadya1
{
    class Program
    {   
        static string[] nama = new string[20];
        static string[] umur = new string[20];
        static string[] jabatan = new string[20];
        static int a,b,c,d,i;
        static void tambah(){

            Console.WriteLine("Jumlah Data Yang Akan Diinput: ");
            b = int.Parse(Console.ReadLine());

            d=0;

            for(c = 0; c < b; c++ ){
                d++;

                Console.WriteLine($"Data Ke {d}");
                Console.Write("Nama: ");
                nama[a]  = Console.ReadLine();
                Console.Write("Umur: ");
                umur[a]  = Console.ReadLine();
                Console.Write("Jabatan: ");
                jabatan[a]  = Console.ReadLine();

                a++;
            }
            
        }

        static void lihat(){
            int j;

            j=0;
            if(a==0){
               
                Console.WriteLine("\nData Tidak Tersedia.\n");
              
            }else{
                    for(i = 0; i < a; i++){
                    j++;

                    Console.WriteLine($"Karyawan {j}");
                    Console.WriteLine($"Nama: {nama[i]}");
                    Console.WriteLine($"Umur: {umur[i]}");
                    Console.WriteLine($"Jabatan: {jabatan[i]}");
                    Console.WriteLine("");
                }
            }
           
        }

        static void hapus(){
            int x;
            // Console.WriteLine($"{a} ");
            if(a==0){
               
                Console.WriteLine("\nData Tidak Tersedia.\n");
              
            }else{
                Console.Write("Hapus Data Karyawan Ke : ");
                x = int.Parse(Console.ReadLine());

                for(i = x-1; i < a; i++){
                    i = i + 1;
                }
                a--;
            }
        }
            
        static void ubah(){
            int k,l;

            if(a==0){
               
                Console.WriteLine("-");
              
            }else{
                Console.Write("Ubah Data ke : ");
                k = int.Parse(Console.ReadLine());

                l=k-1;

                Console.Write("Nama: ");
                nama[l]  = Console.ReadLine();
                Console.Write("Umur: ");
                umur[l]  = Console.ReadLine();
                Console.Write("Jabatan: ");
                jabatan[l]  = Console.ReadLine();
            }
        }
        static void Main(string[] args){
            int pilih;

            awal:  
            Console.WriteLine("Pilihan : ");
            Console.WriteLine("1. Tambah Data");
            Console.WriteLine("2. Lihat Data");
            Console.WriteLine("3. Hapus Data");
            Console.WriteLine("4. Ubah Data");
            Console.WriteLine("5. Exit");
            Console.Write("Masukkan Pilihan : ");
            pilih = int.Parse(Console.ReadLine());

            switch(pilih){
                case 1:
                 Console.Clear();
                 tambah();
                 goto awal;
        
                case 2:
                 Console.Clear();
                 lihat();
                 goto awal;

                case 3:
                 hapus();
                 goto awal;

                case 4:
                 Console.Clear();
                 lihat();
                 ubah();
                 goto awal;

                 case 5:
                 Console.WriteLine("Program Selesai.");
                 break;

                default:
                goto awal;
            }
        }
    }
}