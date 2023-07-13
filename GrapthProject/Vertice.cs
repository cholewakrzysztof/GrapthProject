using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapthProject
{
    public class Vertice : IComparable<Vertice>
    {
        private float Weight;
        private List<Edge> Edges = new List<Edge>();
        private List<Vertice> Neiboughrs = new List<Vertice>();
        private bool Visited = false;
        private int Degree = 0;
        public Point Point { get; set; }

        private int Id { get; }
        private static int lastId = 0;
        


        public Vertice(int x, int y,float weight = 0f) 
        {
            Weight = weight;
            Id = lastId++;
            Point = new Point(x, y);
        }

        public bool ConnectTo(Vertice vertice,bool directed = false , float weight = 0f) 
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
                this.setDegree();
                vertice.setDegree();
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
        
        private void AddEdge(Edge edge) 
        {
            Edges.Add(edge);
        }
        
        public Edge GetEdgeTo(Vertice vertice)
        {
            return GetEdge(this.GetEdgeIndex(vertice.GetId()));
        }
        
        private int GetEdgeIndex(int destinationVerticeId) 
        {
            return Edges.FindIndex(edge => edge.GetDestinationVertice(this).GetId()==destinationVerticeId);
        }
        
        private Edge GetEdge(int index) 
        {
            return Edges[index];
        }
        
        private void AddNeiboughr(Vertice vertice) 
        {
            Neiboughrs.Add(vertice);
        }
        
        public List<Vertice> GetNeiboughrs() 
        {
            return Neiboughrs;
        }
        public void setDegree() 
        {
            this.Degree = Neiboughrs.Count();
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

        public int CompareTo(Vertice other)
        {
            if (this.Degree > other.Degree)
                return 1;
            else if (this.Degree < other.Degree)
                return -1;
            else
                return 0;

        }
        public List<Edge> GetEdges() 
        {
            return Edges;
        }
    }
}
