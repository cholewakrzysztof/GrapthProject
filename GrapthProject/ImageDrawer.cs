using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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
            throw new NotImplementedException();
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
