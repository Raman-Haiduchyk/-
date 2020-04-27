using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using FigureClass;


namespace GraphicsEditor
{
    [Serializable]
    class Polygon : Figure         
    {
        protected List<PointF> Points;      //множество точек многоугольника

        public Polygon(string str, Color brushCol, Color penColor, int borderWidth, params PointF[] points) : base(str, brushCol, penColor, borderWidth)
        {
            Points = new List<PointF>(points);
        }

        protected Polygon(string str, Color brushCol, Color penColor, int borderWidth) : base(str, brushCol, penColor, borderWidth)
        { 
        }

        override public void Draw(Graphics graphics) 
        {
            Pen FigurePen = new Pen(PenColor, BorderWidth);
            SolidBrush FigureBrush = new SolidBrush(BrushColor);
            graphics.FillPolygon(FigureBrush, Points.ToArray());
            graphics.DrawPolygon(FigurePen, Points.ToArray());
        } 

        public static bool Preview(Graphics graphics, params PointF[] renderPoints)
        {
            for (int i = 0; i < renderPoints.Count() - 1; i++) 
            {
                graphics.DrawLine(new Pen(prevCol), renderPoints[i], renderPoints[i + 1]);
            }
            return false;
        }
    }
}
