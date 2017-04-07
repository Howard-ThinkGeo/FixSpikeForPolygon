using System.Diagnostics;
using System.Drawing;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Drawing;
using ThinkGeo.MapSuite.Shapes;

namespace ThinkGeo.MapSuite.Ultilities
{
    class Program
    {
        static void Main(string[] args)
        {
            PolygonShape p = new PolygonShape();
            p.OuterRing.Vertices.Add(new Vertex(-20, 20));

            p.OuterRing.Vertices.Add(new Vertex(-0.2, 20));
            p.OuterRing.Vertices.Add(new Vertex(0, 23));
            p.OuterRing.Vertices.Add(new Vertex(0.2, 20));

            p.OuterRing.Vertices.Add(new Vertex(20, 20));
            p.OuterRing.Vertices.Add(new Vertex(20, 0.2));
            p.OuterRing.Vertices.Add(new Vertex(23, 0));
            p.OuterRing.Vertices.Add(new Vertex(20, -0.2));
            p.OuterRing.Vertices.Add(new Vertex(20, -20));
            p.OuterRing.Vertices.Add(new Vertex(-20, -20));
            p.OuterRing.Vertices.Add(new Vertex(-20, 20));

            DrawPolygon(p, "1.png");

            SmoothenHelper.Smoothen(p);

            DrawPolygon(p, "2.png");
        }

        private static void DrawPolygon(PolygonShape p, string f)
        {
            Bitmap bmp = new Bitmap(256, 256);
            PlatformGeoCanvas canvas = new PlatformGeoCanvas();
            canvas.BeginDrawing(bmp, new RectangleShape(-30, 30, 30, -30), GeographyUnit.DecimalDegree);
            canvas.DrawArea(p, GeoBrushes.Blue, DrawingLevel.LabelLevel);
            canvas.EndDrawing();

            string resultFilePath = f;
            bmp.Save(resultFilePath);
            Process.Start(resultFilePath);
        }
    }
}
