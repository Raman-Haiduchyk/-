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

        protected static Pen FigurePen;

        protected static SolidBrush FigureBrush;       
      
        protected Figure(string str, Color brushCol, int borderWidth) 
        {
            Name = str;
            FigurePen = new Pen(Color.FromKnownColor(KnownColor.Black), borderWidth);
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
