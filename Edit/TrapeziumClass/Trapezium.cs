using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FigureClass;

namespace GraphicsEditor
{
    [Serializable]
    class Trapezium : Figure          
    {
        public float SideA, SideB;    //стороны прямоугольника (для будущего редактирования фигур)

        protected List<PointF> Points;
        // В конструктор передаются левая верхняя
        // и правая нижняя точки
        public Trapezium(string str, Color brushCol, Color penColor, int borderWidth, params PointF[] pts):base(str, brushCol, penColor, borderWidth)
        {
            float deltaX = (pts[1].X - pts[0].X) / 3;
            PointF A = new PointF(pts[0].X + deltaX, pts[0].Y);
            PointF B = new PointF(pts[1].X - deltaX, pts[0].Y);
            PointF C = pts[1];
            PointF D = new PointF(pts[0].X, pts[1].Y);
            SideA = Math.Abs(pts[0].X - pts[1].X);
            SideB = Math.Abs(A.X - B.X);
            Points = new List<PointF>();
            Points.Add(A);
            Points.Add(B);
            Points.Add(C);
            Points.Add(D);

        }

        public static new bool Preview(Graphics graphics, params PointF[] renderPoints)
        {
            if (renderPoints.Count() == 2)
            {
                float deltaX = (renderPoints[1].X - renderPoints[0].X)/3;
                PointF[] array = new PointF[] { new PointF(renderPoints[0].X + deltaX, renderPoints[0].Y), new PointF(renderPoints[1].X - deltaX, renderPoints[0].Y), 
                    renderPoints[1], new PointF(renderPoints[0].X, renderPoints[1].Y) };
                graphics.DrawPolygon(new Pen(prevCol), array);
                return false;
            }
            else if (renderPoints.Count() > 2)
            {
                return true;
            }
            else return false;
        }

        override public void Draw(Graphics graphics)
        {
            Pen FigurePen = new Pen(PenColor, BorderWidth);
            SolidBrush FigureBrush = new SolidBrush(BrushColor);
            graphics.FillPolygon(FigureBrush, Points.ToArray());
            graphics.DrawPolygon(FigurePen, Points.ToArray());
        }

    }
}
