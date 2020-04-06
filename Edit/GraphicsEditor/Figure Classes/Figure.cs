using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Edit
{
    abstract class Figure                                   
    {
        public string Name { get; set; }

        //protected int layout { get; set; }  управление слоями в будущем

        protected Pen FigurePen;

        protected SolidBrush FigureBrush;

        protected static Color prevCol = Color.FromArgb(100, 0, 0, 0);

        protected Figure(string str, Color brushCol, Color penColor, int borderWidth) 
        {
            Name = str;
            FigurePen = new Pen(penColor, borderWidth);
            FigureBrush = new SolidBrush(brushCol);
        }

        public abstract void Draw(Graphics graphics);
        

        public static void Preview()
        {
        }

        /*
        public virtual string GetInfo()
        {
            return (Name + " ");
        } 
        */
    }
}
