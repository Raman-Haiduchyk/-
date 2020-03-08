using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Edit
{
    class Polygon : Figure         
    {
        protected List<PointF> Points;      //множество точек многоугольника

        public Polygon(string str, Color brushCol, int borderWidth, params PointF[] points) : base(str, brushCol, borderWidth)
        {
            Points = new List<PointF>(points);
        }

        protected Polygon(string str, Color brushCol, int borderWidth) : base(str, brushCol, borderWidth)
        { 
        }

        override public void Draw(Graphics graphics) 
        {
            graphics.FillPolygon(FigureBrush, Points.ToArray());
            graphics.DrawPolygon(FigurePen, Points.ToArray());
        } 

        public static bool PreRender(Graphics graphics, params PointF[] renderPoints)
        {
            for (int i = 0; i < renderPoints.Count() - 1; i++) 
            {
                graphics.DrawLine(FigurePen, renderPoints[i], renderPoints[i + 1]);
            }
            return false;
        }
    }
}
