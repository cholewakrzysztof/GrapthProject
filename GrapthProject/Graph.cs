using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace GrapthProject
{
    public class Graph
    {
        public List<Vertice> vertices = new List<Vertice>();
        public List<Edge> edges = new List<Edge>();
        public Graph() { }

        public void AddVertice(int x, int y,float weight) 
        {
            Vertice vertice = new Vertice(x,y,weight);
            vertices.Add(vertice);
        }
        public void RefreshEdges() 
        {
            edges.Clear();
            foreach (Vertice vertice in vertices)
                foreach (Edge edge in vertice.GetEdges())
                    if (!edges.Contains(edge))
                        edges.Add(edge);
        }
        public void UnVisitVertices() 
        {
            foreach (Vertice vertice in vertices)
                vertice.UnVisit();
        }
        public void PrintNeiboughrList() 
        {
            foreach (Vertice vertice in vertices)
                foreach (Vertice neiboughr in vertice.GetNeiboughrs())
                    Console.Write(neiboughr.GetId().ToString()+" ");
                Console.WriteLine();
        }
        public Vertice GetVertice(int id) 
        {
            return vertices[id];
        }
        public Edge GetEdge(int id) { return edges[id]; }
    }
}
