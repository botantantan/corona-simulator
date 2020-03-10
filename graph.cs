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
        int hariPertama;
        Dictionary<City, List<City>> Vertex;
        Dictionary<KeyValuePair<City, City>, float> probability;


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
            if (probability.ContainsKey(new KeyValuePair<City, City>(Asal, Tujuan)))
            {
                return probability[new KeyValuePair<City, City>(Asal, Tujuan)];
            }
            else
            {
                return 0;
            }
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





    }
}
