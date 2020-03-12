using System;
using System.Collections.Generic;
using System.IO;
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
        public City(int populasi,  string nama)
        {
            this.populasi = populasi;
            this.nama = nama;
        }
        public void set_populasi(int populasi)
        {
            this.populasi = populasi;

        }
        public int get_populasi()
        {
            return populasi;
        }
        public void set_kenaInfeksi(int kenaInfeksi)
        {
            this.kenaInfeksi = kenaInfeksi;
        }
        public int get_kenaInfeksi()
        {
            return kenaInfeksi;
        }
        public void set_nama(string nama)
        {
            this.nama = nama;
        }
        public string get_nama()
        {
            return nama;
        }
        public int getTotalDay(int day)
        {
            return (day - kenaInfeksi);
        }
        public float PopInfeksi(int day)
        {
            float pop;
            pop = (float)(get_populasi() / (1 + (get_populasi() - 1)*Math.Pow(2.71828d, -(double)(0.25*getTotalDay(day)))));
            return pop;
        }
        public void reset()
        {
            this.kenaInfeksi = -1;
        }

    }
}
