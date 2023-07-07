﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapthProject
{
    public class Edge
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
        public float GetWeight() 
        {
            return Weight;
        }

        public Vertice GetDestinationVertice(int fromId) 
        {
            if(From.GetId()==fromId)
                return To;
            else
                return From;
        }

        /// <summary>
        /// Check if you can draw path from vertice using this edge
        /// </summary>
        /// <param name="vertice">Start vertice</param>
        /// <returns>Boolean determinative usable of edge</returns>
        public bool CanUseEdge(Vertice vertice) 
        {
            if (Directed) 
                if(vertice.GetId()!=From.GetId())
                    return false;
            return true;
        }
    }
}
