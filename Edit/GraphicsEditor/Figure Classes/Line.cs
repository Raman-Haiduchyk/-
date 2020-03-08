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

        public Line(string str, Color brushCol, int borderWidth, params PointF[] pts) : base(str, brushCol, borderWidth)
        {
            A = pts[0];
            B = pts[1];
        }


        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            graphics.DrawLine(FigurePen, A, B);
        }

        public static bool PreRender(Graphics graphics, params PointF[] drawPoints)
        {
            if (drawPoints.Count() == 2)
            {
                graphics.DrawLine(FigurePen, drawPoints[0], drawPoints[1]);
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
