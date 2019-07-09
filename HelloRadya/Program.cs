using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloRadya
{
    public class Buku {
        public Buku()
        {
            
        }
        public TransaksiEnum StatusPinjaman {get;set;}
        public Buku(string title, string author)
        {
            Title = title;
            Author = author;
            Quantity = 10;
        }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Quantity { get; set; }
    }
    class Program
    {
        //deklarasi
        static int jumlahOrang;

        //deklarasi + inisiasi
        static int jumlahBuku = 10;

        static Buku buku = new Buku();
        static void Main(string[] args)
        {

            StatementDemo();
            ClassesDemo();
            ArrayDemo();
            InteratorDemo();
            LinqDemo();
            LinqDemo2();
        }

        private static void LinqDemo2()
        {
            IEnumerable<Orang> orangs = GetOrangs();
            //select * from orangs
            var allData = (from a in orangs
            select a).ToList();

            //select name, address from orangs
            var names = (from a in orangs
            select new { a.Name, a.Address});

            var page1 = (from a in orangs
            where a.Buku.StatusPinjaman == TransaksiEnum.BELI
            select a.Name);

            orangs.ToList();
            orangs.Where(x=>x.Buku.StatusPinjaman == TransaksiEnum.BELI);

            orangs.Select(x=> new { x.Name, x.Address});

            List<OrangViewModel> orangBaruPunyaNama = orangs.Select(x=> new OrangViewModel{
                Name = x.Name
            }).ToList();

            Console.ReadKey();
        }

        private static IEnumerable<Orang> GetOrangs()
        {
            yield return new Orang("Ade", "Bandung Coret");
            yield return new Orang("Rudi", "Bandung Coret");
            yield return new Orang("Hegi", "Bandung Coret");
            yield return new Orang("Yunus", "Bandung Coret");
            yield return new Orang("Asep", "Bandung Coret");
        }

        private static void LinqDemo()
        {
            IEnumerable<int> numbers = SomeNumbers();

            var allData = numbers;

            var lessThan3 = numbers.Where(x=>x < 3 && x > 1);

            var page1 = numbers.Skip(0).Take(2);
            var page2 = numbers.Skip(2).Take(2);
            var page3 = numbers.Skip(4).Take(2);


            //Equal SELECT * FROM NUMBERS WHERE a > 3
            var result = (from a in numbers
                            where a > 3
                            select a).ToList();

            foreach(var item in allData){
                Console.WriteLine(item);
            }

            Console.WriteLine("Less than 3");

            foreach(var item in lessThan3){
                Console.WriteLine(item);
            }

            Console.WriteLine("Paging");

            foreach(var item in page1){
                Console.WriteLine(item);
            }

            Console.WriteLine("Page 2");

            foreach(var item in page2){
                Console.WriteLine(item);
            }

            Console.WriteLine("Page 3");
            foreach(var item in page3){
                Console.WriteLine(item);
            }
        }

        private static void InteratorDemo()
        {
            foreach(var item in SomeNumbers()){
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<int> SomeNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
        }

        public static void ClassesDemo(){
            buku = new Buku("Basic C# Programming", "Rudi Hartono");
            buku.Quantity = 10;
            
            Orang ade = new Orang("Ade", "Bandung Coret");
            ade.Pinjam(buku.Title);

            Console.WriteLine($"Status buku {ade.Buku.Title} status: " + ade.Buku.StatusPinjaman);

            //buku.Title = "C# Programming languague";

            Console.WriteLine("Daftar buku : ");
            Console.WriteLine($"1. {buku.Title} penulis: {buku.Author}");
        }

        public static void StatementDemo(){
            jumlahOrang = 10;
            Console.WriteLine($" jumlah buku {jumlahBuku} untuk {jumlahOrang} orang ");
            
            Console.WriteLine(" jumlah buku "+jumlahBuku+ "untuk " + jumlahOrang +".");
            
            //statement operator
            int hasilBagi = jumlahBuku/jumlahOrang;


            if(hasilBagi == 1){
                Console.WriteLine("Semua orang terbagi");
            }else if(hasilBagi > 10){
                Console.WriteLine("Kalau masuk kesini berarti error");
            }else{

            }

            switch(hasilBagi){
                case 1:
                 Console.WriteLine("Semua orang terbagi");
                break;

                default:
                break;
            }

            //iterasi

            string namaAnakAyam = "ChickenSoap";

            for(int i = 0; i < namaAnakAyam.Length; i++){
                Console.Write($"{namaAnakAyam[i]} ");
            }

            Console.WriteLine();

            foreach(char item in namaAnakAyam){
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            
            Console.WriteLine($" masing orang punya {hasilBagi} buku ");

            //Console.WriteLine("Hello World!");
        }

        public static void ArrayDemo (){
            //aray 1 dimensi
            string[] daftarOrang = new string[5];

            daftarOrang[0] = "Rudi";
            daftarOrang[1] = "Ade";
            daftarOrang[2] = "Hegi";
            daftarOrang[3] = "Yunus";
            daftarOrang[4] = "Iwa";

           daftarOrang = new string[]{ 
               "Asep",
               "Arik",
               "Arik",
               "Arik",
               "Arik",
               "Azis"
           };

           foreach(var item in daftarOrang){
               Console.WriteLine(item);
           }


           string[,] orangDanBuku0 = {{"1", "2", "3" }, { "Satu", "Dua", "Tiga"}};

           string[,] orangDanBuku1 = new string[2, 3] { {"1", "2", "3"}, {"1","2","3"}};

           string[][] orangDanBukuJagged = new string[2][];

           orangDanBukuJagged[0] = new string[2]{ "SATU", "DUA" };
           orangDanBukuJagged[1] = new string[2]{ "SATU", "DUA" };

            foreach(var items in orangDanBuku0){
                foreach(var item in items){
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            for(int i = 0; i< orangDanBuku0.Length/3; i++){
                for(int j = 0; j < orangDanBuku0.Length/2; j++){
                    Console.Write(orangDanBuku0[i,j]);
                }
            }

             foreach(var items in orangDanBuku1){
                foreach(var item in items){
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }
            
            foreach(var items in orangDanBukuJagged){
                foreach(var item in items){
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
