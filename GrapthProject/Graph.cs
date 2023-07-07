using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapthProject
{
    public class Graph
    {
        private List<Vertice> vertices = new List<Vertice>();
        private List<Edge> edges = new List<Edge>();

        public Graph() { }

        public void AddVertice(float weight) 
        {
            Vertice vertice = new Vertice(weight);
            vertices.Add(vertice);
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
    }
}
