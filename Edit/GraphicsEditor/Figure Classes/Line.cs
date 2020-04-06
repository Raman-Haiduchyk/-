using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edit
{
    class Line : Figure
    {
        protected PointF A, B;

        public Line(string str, Color brushCol, Color penColor, int borderWidth, params PointF[] pts) : base(str, brushCol, penColor, borderWidth)
        {
            A = pts[0];
            B = pts[1];
        }


        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(FigurePen, A, B);
        }

        public static bool Preview(Graphics graphics, params PointF[] drawPoints)
        {
            if (drawPoints.Count() == 2)
            {
                graphics.DrawLine(new Pen(prevCol), drawPoints[0], drawPoints[1]);
                return false;
            }
            else if (drawPoints.Count() > 2)
            {
                return true;
            }
            else return false;
        }

    }
}
