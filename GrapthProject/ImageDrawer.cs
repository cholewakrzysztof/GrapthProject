using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GrapthProject
{
    public class ImageDrawer
    {
        /// <summary>
        /// Draw blank image
        /// </summary>
        /// <returns>Vector image without shapes</returns>
        public static DrawingImage DrawImage()
        {
            return new DrawingImage();
        }
        /// <summary>
        /// Draw image
        /// </summary>
        /// <param name="graph">Source graph</param>
        /// <returns>DrawingImage with graph</returns>
        public static DrawingImage DrawImage(Graph graph)
        {
            GeometryGroup points = new GeometryGroup();
            foreach (Vertice element in graph.vertices)
            {
                points.Children.Add(new EllipseGeometry(element.Point,0,0));
            }
            foreach (Edge edge in graph.edges)
            {
                points.Children.Add(new LineGeometry(edge.StartPoint, edge.EndPoint));
            }
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = points;
            geometryDrawing.Pen = new Pen(Brushes.Black, 1);

            DrawingImage geometryImage = new DrawingImage(geometryDrawing);
            return geometryImage;
        }
        public static DrawingImage DrawSampleImage()
        {
            GeometryGroup ellipses = new GeometryGroup();
            ellipses.Children.Add(new EllipseGeometry(new Point(50, 50), 45, 20));
            ellipses.Children.Add(new LineGeometry(new Point(0, 0), new Point(50, 50)));
            GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            aGeometryDrawing.Geometry = ellipses;
            aGeometryDrawing.Pen = new Pen(Brushes.Black, 1);
            DrawingImage geometryImage = new DrawingImage(aGeometryDrawing);
            return geometryImage;
        }
    }
}
