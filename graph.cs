
using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tubes2Stima
{
    class GraphCity
    {
        public Dictionary<City, List<City>> Vertex;
        public Dictionary<KeyValuePair<City, City>, float> probability;
        public Microsoft.Msagl.Drawing.Graph guiGraph;
        public Dictionary<string, City> inputanNode;
        public int jumlahKota;
        public string kotaAwal;
        public int jumlahEdge;
        public Dictionary<int,KeyValuePair<string, string>> jalurInfek;


        public GraphCity()
        {
            Vertex = new Dictionary<City, List<City>>();
            probability = new Dictionary<KeyValuePair<City, City>, float>();
            guiGraph = new Microsoft.Msagl.Drawing.Graph();
            inputanNode = new Dictionary<string, City>();
            jumlahKota = 0;
            kotaAwal = "noname";
            jumlahEdge = 0;
            jalurInfek = new Dictionary<int,KeyValuePair<string, string>>();
        }
        public void add_vertex(City kota)
        {
            Vertex.Add(kota, new List<City>());
        }
        // Menghubungkan vertek asal dengan Tujuan
        public void add_Edge(City Asal, City Tujuan, float prob)
        {
            if (!Vertex.ContainsKey(Asal))
            {
                add_vertex(Asal);
            }
            if (!Vertex.ContainsKey(Tujuan))
            {
                add_vertex(Tujuan);
            }
            guiGraph.AddEdge(Asal.get_nama(), Tujuan.get_nama());
            Vertex[Asal].Add(Tujuan);
            probability.Add(new KeyValuePair<City, City>(Asal, Tujuan), prob);
        }
        public float get_prob(City Asal, City Tujuan)
        {

            return probability[new KeyValuePair<City, City>(Asal, Tujuan)];

        }
        public Boolean has_vertex(City kota)
        {
            return Vertex.ContainsKey(kota);
        }
        public Boolean has_edge(City Asal, City Tujuan)
        {
            return probability.ContainsKey(new KeyValuePair<City, City>(Asal, Tujuan));
        }
        public void update_Vertex_terinfeksi(City kota)
        {
            guiGraph.FindNode(kota.get_nama()).Attr.FillColor = Color.Red;
        }
        public Edge get_edge(City Asal, City Tujuan)
        {
            return guiGraph.Edges.Where(edge => edge.Source == Asal.get_nama() && edge.Target == Tujuan.get_nama()).FirstOrDefault();
        }
        public void update_Edge_Terinfeksi(City Asal, City Tujuan)
        {
            // guiGraph.AddEdge(Asal.get_nama(), Tujuan.get_nama()).Attr.Color = Color.DarkRed;
            Edge e = get_edge(Asal, Tujuan);
            if(e != null)
            {
                e.Attr.Color = Color.DarkRed;
            }

            Console.WriteLine(guiGraph.EdgeCount);
        }

        public void inputFromFile()
        {

            // Input Node
            string[] lineNode = System.IO.File.ReadAllLines(@"C:\\Users\\PS42\\Desktop\\Kuliah Semester 4\\STIMA\\Tubes2Stima\\text.txt"); //input Node
            bool first = true;


            foreach (string kata in lineNode)
            {
                string[] inputNode = kata.Split(' ');
                if (first)
                {
                    this.jumlahKota = int.Parse(inputNode[0]);
                    this.kotaAwal = inputNode[1];
                    first = false;

                }
                else
                {

                    this.inputanNode[inputNode[0]] = new City(int.Parse(inputNode[1]), inputNode[0]);
                    this.guiGraph.AddNode(new Node(inputNode[0]));

                }

            }

            //Input Edge
            string[] lineEdge = System.IO.File.ReadAllLines(@"C:\\Users\\PS42\\Desktop\\Kuliah Semester 4\\STIMA\\Tubes2Stima\\sisi.txt");
            bool firstEdge = true;
            foreach (string katae in lineEdge)
            {
                string[] inputEdge = katae.Split(' ');
                if (firstEdge)
                {
                    this.jumlahEdge = int.Parse(inputEdge[0]);
                    firstEdge = false;
                }
                else
                {
                    add_Edge(this.inputanNode[inputEdge[0]], this.inputanNode[inputEdge[1]], float.Parse(inputEdge[2]));
                }
            }


        }
        //make function penyebaran
        public float f_penyebaran(City Asal, City Tujuan, int day)
        {
            return (Asal.PopInfeksi(day) * get_prob(Asal, Tujuan));
        }
        //make function 
        public int first_penyebaran(City Asal, City Tujuan)
        {
            float hari;
            hari = 20f / (float)(Asal.get_populasi() * get_prob(Asal, Tujuan));
            int nextDay;
            nextDay = (int)(Math.Ceiling(hari));
            if (nextDay == hari)
            {
                ++nextDay;
            }
            return nextDay;

        }
        public void algortimaBFS(int cekHari)
        {
            foreach (City kota in this.Vertex.Keys)
            {
                kota.reset();
            }
            this.inputanNode[this.kotaAwal].kenaInfeksi = 0;
            var spanNode = new Queue<City>();
            spanNode.Enqueue(this.inputanNode[this.kotaAwal]);
            int count = 0;
            while (spanNode.Count > 0)
            {
                City Check = spanNode.Dequeue();
                this.update_Vertex_terinfeksi(Check);
                foreach (City next in this.Vertex[Check])
                {
                    
                    if (this.f_penyebaran(Check, next, cekHari) > 1)
                    {
                        update_Edge_Terinfeksi(Check, next);
                        if (!jalurInfek.ContainsValue(new KeyValuePair<string, string>(Check.get_nama(), next.get_nama())))
                        {
                            jalurInfek.Add(count, new KeyValuePair<string, string>(Check.get_nama(), next.get_nama()));
                            count += 1;
                        }
                        
                        int nextDay = this.first_penyebaran(Check, next) + Check.kenaInfeksi;
                        if (next.kenaInfeksi <= nextDay)
                        {
                            next.kenaInfeksi = nextDay;
                            spanNode.Enqueue(next);
                        }

                    }
                }
            }


        }




    }
}
