using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edit
{
    class Rectangle : Polygon          
    {
        public float SideA, SideB;    //стороны прямоугольника (для будущего редактирования фигур)


        // В конструктор передаются левая верхняя
        // и правая нижняя точки
        public Rectangle(string str, Color brushCol, Color penColor, int borderWidth, params PointF[] pts):base(str, brushCol, penColor, borderWidth)
        {
            PointF A = pts[0];
            PointF B = pts[1];
            SideA = Math.Abs(A.X - B.X);
            SideB = Math.Abs(A.Y - B.Y);
            Points = new List<PointF>();
            Points.Add(A);
            Points.Add(new PointF(B.X, A.Y));
            Points.Add(B);
            Points.Add(new PointF(A.X, B.Y));

        }

        public static new bool Preview(Graphics graphics, params PointF[] renderPoints)
        {
            if (renderPoints.Count() == 2)
            {
                PointF[] array = new PointF[] { renderPoints[0], new PointF(renderPoints[1].X, renderPoints[0].Y), 
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

    }
}
