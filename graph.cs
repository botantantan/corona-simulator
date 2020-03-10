
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2Stima
{
    class GraphCity
    {
        int hariPertama;
        Dictionary<City, List<City>> Vertex;
        Dictionary<KeyValuePair<City, City>, float> probability;
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();


        public GraphCity()
        {
            hariPertama = 0;
            Vertex = new Dictionary<City, List<City>>();
            probability = new Dictionary<KeyValuePair<City, City>, float>();
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
        
        public void  inputFromFile()
        {
            // Input Node
            string[] lineNode = System.IO.File.ReadAllLines(@"..//..//..//text.txt");
            bool first = true;
            
            foreach(string kata in lineNode)
            {
                string[] inputNode = kata.Split(" ");
                if (first)//line pertama
                {
                    foreach(string hruf in inputNode)
                    {
                        Console.WriteLine(hruf);
                        first = false;

                    }

                }
                else //line lainya
                {
                    foreach (string hruf in inputNode)
                    {
                    }
                }
            }
          
            
          
           






            //Input Edge
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
            if(nextDay == hari)
            {
                ++nextDay;
            }
            return nextDay;

        }




    }
}
