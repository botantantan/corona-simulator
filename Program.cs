using System;

namespace Tubes2Stima
{
    class City
    {
        public int populasi;
        public string nama;
        public int kenaInfeksi;

        public City()
        {
            populasi = 0;
            kenaInfeksi = 0;
            nama = "noname";
            
        }
        public City(int populasi, int kenaInfeksi, string nama)
        {
            this->populasi = populasi;
            this->kenaInfeksi = kenaInfeksi;
            this->nama = nama;
        }
        public void set_populasi(int populasi)
        {
            this->populasi = populasi;
        }
        public int get_populasi()
        {
            return populasi;
        }
        public void set_kenaInfeksi(int kenaInfeksi)
        {
            this->kenaInfeksi = kenaInfeksi;
        }
        public int get_kenaInfeksi()
        {
            return kenaInfeksi;
        }
        public void set_nama(string nama)
        {
            this->nama = nama;
        }
        public string get_nama()
        {
            return nama;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            City kota = new City(1000,10,"pekutan");
            Console.WriteLine(kota.get_populasi());

        }
    }
}
