using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapthProject
{
    public class Vertice
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
            if (!CanConnect(vertice))
                return false;
            else 
            {
                Edge edge = new Edge(this,vertice,directed,weight);
                this.AddEdge(edge);
                vertice.AddEdge(edge);
                this.AddNeiboughr(vertice);
                vertice.AddNeiboughr(this);
                return true;
            }
        }

        public bool ConnectTo(Vertice vertice)
        {
            if (!CanConnect(vertice))
                return false;
            else
            {
                Edge edge = new Edge(this, vertice, false, 0f);
                this.AddEdge(edge);
                vertice.AddEdge(edge);
                this.AddNeiboughr(vertice);
                vertice.AddNeiboughr(this);
                return true;
            }
        }
        private bool CanConnect(Vertice vertice) 
        {
            if (this.GetId() == vertice.GetId())
                return false;
            if (Neiboughrs.Any(ver => ver.GetId() == vertice.GetId()))
                return false;
            return true;
        }

        public void AddEdge(Edge edge) 
        {
            Edges.Add(edge);
        }
        public int GetEdgeIndex(int destinationVerticeId) 
        {
            return Edges.FindIndex(edge => edge.GetDestinationVertice(this.GetId()).GetId() == destinationVerticeId);
        }
        public Edge GetEdge(int index) 
        {
            return Edges[index];
        }

        public void AddNeiboughr(Vertice vertice) 
        {
            Neiboughrs.Add(vertice);
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

        public static void ResetLastId() 
        {
            lastId = 0;
        }
    }
}
