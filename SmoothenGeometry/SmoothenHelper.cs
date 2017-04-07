using System;
using System.Threading.Tasks;
using ThinkGeo.MapSuite.Shapes;

namespace ThinkGeo.MapSuite.Ultilities
{
    static class SmoothenHelper
    {
        public static async Task SmoothenAsync(PolygonShape polygon, double spikeAngleToleranceInDegree, double spikeDistanceTolerance)
        {
            await Task.Run(() => Smoothen(polygon, spikeAngleToleranceInDegree, spikeAngleToleranceInDegree));
        }

        public static void Smoothen(PolygonShape polygon, double spikeAngleToleranceInDegree = 170, double spikeDistanceTolerance = 0.5)
        {
            Vertex v1 = polygon.OuterRing.Vertices[0];
            Vertex v2 = polygon.OuterRing.Vertices[1];
            for (int i = 2; i < polygon.OuterRing.Vertices.Count; i++)
            {
                Vertex cv = polygon.OuterRing.Vertices[i];
                double dg1 = v2.Angle(v1, true);
                double dg2 = cv.Angle(v2, true);
                double dgDiffer = Math.Abs(dg2 - dg1);

                if (dgDiffer > spikeAngleToleranceInDegree && v1.StraightDistanceTo(cv) < spikeDistanceTolerance)
                {
                    Vertex newV2 = new Vertex((v1.X + cv.X) * .5, (v1.Y + cv.Y) * .5);
                    polygon.OuterRing.Vertices[i - 1] = newV2;
                }

                v1 = polygon.OuterRing.Vertices[i - 1];
                v2 = cv;
            }
        }

        private static double StraightDistanceTo(this Vertex v1, Vertex v2)
        {
            return Math.Sqrt(Math.Pow(v2.X - v1.X, 2) + Math.Pow(v2.Y - v1.Y, 2));
        }

        private static double Angle(this Vertex v1, Vertex v2, bool inDegree = false)
        {
            double angle = Math.Atan2(v2.Y - v1.Y, v2.X - v1.X);
            if (inDegree)
            {
                angle = angle * 180 / Math.PI;
                angle = MakeDegreeAngleInRange(angle);
            }

            return angle;
        }

        private static double MakeDegreeAngleInRange(double angleInDegree)
        {
            while (angleInDegree > 360) angleInDegree -= 360;
            while (angleInDegree < 0) angleInDegree += 360;
            return angleInDegree;
        }
    }
}
