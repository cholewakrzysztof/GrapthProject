using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapthProject
{
    class Vertice
    {
        private float Weight;
        private List<Edge> Edges = new List<Edge>();
        private List<Vertice> Neiboughrs = new List<Vertice>();
        private bool Visited = false;
        private int Id;
        private static int lastId = 0;

        public Vertice(float weight) 
        {
            Weight = weight;
            Id = lastId++;
        }

        public bool ConnectTo(Vertice vertice,bool directed,float weight) 
        {
            if (Neiboughrs.Contains(vertice))
                return true;
            else 
            {
                Edge edge = new Edge(this,vertice,directed,weight);
                Edges.Add(edge);
                vertice.AddEdge(edge);
                Neiboughrs.Add(vertice);
                return true;
            }
        }

        public void AddEdge(Edge edge) 
        {
            Edges.Add(edge);
        }

        public List<Vertice> GetNeiboughrs() 
        {
            return Neiboughrs;
        }

        public int GetId() 
        {
            return Id;
        }

        public void Visit() 
        {
            Visited = true;
        }

        public void UnVisit() 
        {
            Visited = false;
        }

        public bool isVisited() 
        {
            return Visited;
        }
    }
}
