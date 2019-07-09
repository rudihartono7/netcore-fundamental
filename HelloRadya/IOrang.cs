namespace HelloRadya
{
    public interface IOrang<T>
    {
        void Pinjam(string namaBuku);
        void Kembali(string namaBuku);
        void Bayar(string namaBuku, int harga);
    }
}