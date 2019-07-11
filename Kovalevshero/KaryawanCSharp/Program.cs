using System;
using System.Collections.Generic;
using System.Linq;

namespace KaryawanCSharp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
        {
            Console.WriteLine("======= MAIN MENU =======");
            Console.WriteLine("1. List Karyawan");
            Console.WriteLine("2. Add Karyawan");
            Console.WriteLine("3. Delete Karyawan");
            Console.WriteLine("4. Update Karyawan");
            var result = Console.ReadLine();

            switch(result)
            {
                case "1" :
                ShowKaryawan();
                break;

                case "2" :
                AddKaryawan();
                MainMenu();
                break;

                case "3" :
                DeleteKaryawan();
                MainMenu();
                break;

                case "4" :
                UpdateKaryawan();
                MainMenu();
                break;
            }
        }
        public static void ShowKaryawan()
        {

            foreach (Karyawan theKaryawan in listKaryawan)
            {
                Console.WriteLine("Nama : " + theKaryawan.Name);
                Console.WriteLine("Alamat : " + theKaryawan.Address);
                Console.WriteLine("Jabatan : " + theKaryawan.Position);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
            MainMenu();
        }

        public static List<Karyawan> listKaryawan = new List<Karyawan>()
        {
            new Karyawan("Levs", "Bandung", "Web Dev"),
            new Karyawan("Val", "Cirebon", "Manager")
        };

        public static IEnumerable<Karyawan> DeleteKaryawan()
        {
            Console.WriteLine("Nama yang akan dihapus :");
            String deleteName = Console.ReadLine();
            var item = listKaryawan.First(x => x.Name == deleteName);

            listKaryawan.Remove(item);
            return listKaryawan;
        }

        public static IEnumerable<Karyawan> AddKaryawan()
        {
            Console.WriteLine("Input karyawan name : ");
            String inputName = Console.ReadLine();
            Console.WriteLine("Input karyawan address : ");
            String inputAddress = Console.ReadLine();
            Console.WriteLine("Input karyawan position : ");
            String inputPosition = Console.ReadLine();
            
            listKaryawan.Add(new Karyawan(inputName,inputAddress,inputPosition));

            return listKaryawan;

        }

        public static IEnumerable<Karyawan> UpdateKaryawan()
        {
            Console.WriteLine("Nama Karyawan yang akan di update :");
            String updateKaryawan = Console.ReadLine();

            Console.WriteLine("Nama karyawan yang baru : ");
            String newNama = Console.ReadLine();

            Console.WriteLine("Alamat karyawan yang baru : ");
            String newAddress = Console.ReadLine();

            Console.WriteLine("Jabatan karyawan yang baru : ");
            String newPosition = Console.ReadLine();

            listKaryawan.Where(p=>p.Name == updateKaryawan).Select(x => { x.Name = newNama; 
            x.Address = newAddress; x.Position = newPosition; return x;}).ToList();
            return listKaryawan;
        }

        // public class Karyawans
        // {
        //     public System.Collections.Generic.IEnumerable<Karyawan> NextKaryawan
        //     {
        //         get
        //         {
        //             yield return new Karyawan("Koval", "Bandung");
        //             yield return new Karyawan("Lakov", "Bandung Coret");
        //             yield return new Karyawan("Levs", "Bandung Pinggiran");
        //             yield return new Karyawan("Svel", "Bandung Sebelah Sana");
        //             yield return new Karyawan("Hero", "Bandung Agak Kesinian");
        //         }
        //     }
        // } 

        // public class Karyawans
        // {
        //     List<Karyawan> listKaryawan = new List<Karyawan>()
        //     {
        //      new Karyawan("Levs", "Bandung"),

        //     };
        // }
    }
}
