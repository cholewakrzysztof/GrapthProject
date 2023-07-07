using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapthProject
{
    class Edge
    {
        private bool Directed;
        private Vertice From;
        private Vertice To;
        private float Weight;

        public Edge(Vertice from, Vertice to, bool directed,float weight) 
        {
            this.Directed = directed;
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }

        public void SetWeight(float weight) 
        {
            this.Weight = weight;
        }
    }
}
