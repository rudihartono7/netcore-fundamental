namespace KaryawanCSharp
{
    public class Karyawan {
        public Karyawan(string name, string address, string position)
        {
            Name = name;
            Address = address;
            Position = position;

        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
    }
}