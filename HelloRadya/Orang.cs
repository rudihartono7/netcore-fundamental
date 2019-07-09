namespace HelloRadya
{
    public class OrangViewModel {
        public string Name {get;set;}
    }
    public class Orang : IOrang<Orang> {
        public Orang(string name, string Address)
        {
            Name = name;
            this.Address = Address;
            Buku = new Buku("C# Programming", "Rudi Hartono");
            Buku.StatusPinjaman = TransaksiEnum.BELI;
        }
        public string Name { get; set; }
        public string Address { get; set; } 
        public Buku Buku {get; set; }

        public void Bayar(string namaBuku, int harga)
        {
            Buku = new Buku(namaBuku, "");
            Buku.StatusPinjaman = TransaksiEnum.BELI;
        }

        public void Kembali(string namaBuku)
        {
            Buku = null;
        }

        public void Pinjam(string namaBuku)
        {
            Buku = new Buku(namaBuku, "");
            Buku.StatusPinjaman = TransaksiEnum.PINJAM;
        }
    }     
}