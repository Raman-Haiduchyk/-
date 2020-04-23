using System;
using System.Linq;
using System.Drawing;

namespace Edit
{
    [Serializable]
    class Circle:Ellipse
    {
        public double Radius { get; set; }        // радиус (для будущего редактирования фигур)

        // В конструктор передается центр окружности
        // и крайняя точка ее радиуса
        public Circle(string str, Color brushCol, Color penColor, int borderWidth, params PointF[] points) : base(str, brushCol, penColor, borderWidth)
        {
            PointF A = points[0];
            PointF B = points[1];
            Radius = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
            MajorSemiaxis = MinorSemiaxis = (float)Radius;
            Center = A;
        }


        public static new bool Preview(Graphics graphics, params PointF[] renderPoints)
        {
            if (renderPoints.Count() == 2)
            {
                PointF A = renderPoints[0];
                PointF B = renderPoints[1];
                float radius = (float)Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
                graphics.DrawEllipse(new Pen(prevCol), A.X - radius, A.Y - radius, 2 * radius, 2 * radius);
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
