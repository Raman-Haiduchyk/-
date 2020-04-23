using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Edit
{
    [Serializable]
    class Parallelogram : Polygon       
    {
        protected double SideA, SideB;

        // В конструктор передаются три точки,
        // по которым достраивается четвертая
        public Parallelogram(string str, Color brushCol, Color penColor, int borderWidth, params PointF[] points) : base(str, brushCol, penColor, borderWidth)
        {
            PointF A = points[0];
            PointF B = points[1];
            PointF C = points[2];
            Points = new List<PointF>();
            Points.Add(A);
            Points.Add(B);
            Points.Add(C);
            PointF D = new PointF((A.X + (C.X - B.X)), (A.Y + (C.Y - B.Y)));
            Points.Add(D);
            SideA = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
            SideB = Math.Sqrt(Math.Pow(B.X - C.X, 2) + Math.Pow(B.Y - C.Y, 2));
        }


        public static new bool Preview(Graphics graphics, params PointF[] renderPoints)
        {
            if (renderPoints.Count() == 3)
            {
                PointF A = new PointF((renderPoints[0].X + (renderPoints[2].X - renderPoints[1].X)), 
                    (renderPoints[0].Y + (renderPoints[2].Y - renderPoints[1].Y)));
                PointF[] pointsArray = new PointF[] { renderPoints[0], renderPoints[1], renderPoints[2], A };
                graphics.DrawPolygon(new Pen(prevCol), pointsArray);
                return false;
            }
            else if (renderPoints.Count() > 3)
            {
                return true;
            }
            else
            {
                graphics.DrawLine(new Pen(prevCol), renderPoints[0], renderPoints[1]);
                return false;
            }
        }
    }
}
