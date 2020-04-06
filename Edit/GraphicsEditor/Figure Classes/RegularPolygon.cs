using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Edit
{
    class RegularPolygon : Polygon     
    {
        public double Angle;        //угол поворота в радианах
        public int Count;           //кол-во сторон
        public float Radius;        //радиус описанной окружности


        // В конструктор передаются кол-во сторон sideCount
        // и две точки: центр и любая точка на описанной окружности
        public RegularPolygon(string str, Color brushCol, int borderWidth, int sideCount, params PointF[] points) :base(str, brushCol, borderWidth) 
        {
            PointF A = points[0];
            PointF B = points[1];
            Radius = (float)Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2)); ;
            double polygonAngle = Math.PI * 2 / sideCount;
            Count = sideCount;
            Angle = Math.Atan2((double)(A.X - B.X), (double)(A.Y - B.Y)) + Math.PI; // угол поворота многоугольника
            Points = new List<PointF>();
            float x = 0, y = 0;
            for (int i = 0; i < Count; i++)
            {
                x = A.X + (Radius * (float)Math.Sin(i * polygonAngle + Angle));
                y = A.Y + (Radius * (float)Math.Cos(i * polygonAngle + Angle));
                Points.Add(new PointF(x, y));
            }           

        }

        public static new bool Preview(Graphics graphics, int count, params PointF[] renderPoints)
        {
            if (renderPoints.Count() == 2)
            {
                int side_count = count;
                double angle = Math.PI * 2 / side_count;
                PointF A = renderPoints[0];
                PointF B = renderPoints[1];
                float rad = (float)Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));

                List<PointF> array = new List<PointF>();
                float x = 0, y = 0;
                double polygonAngle = Math.Atan2((A.X - B.X), (A.Y - B.Y)) + Math.PI;
                for (int i = 0; i < side_count; i++)
                {
                    x = A.X + (rad * (float)Math.Sin(i * angle + polygonAngle));
                    y = A.Y + (rad * (float)Math.Cos(i * angle + polygonAngle));
                    array.Add(new PointF(x, y));
                }      
                graphics.DrawPolygon(FigurePen, array.ToArray());
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
