using System;
using System.Collections.Generic;

namespace Edit
{
    class Model     //класс хранения данных о фигурах и классах сборки при работе с редактором
    {
        public List<Figure> Figures;

        public List<Type> Types;



        public Model()
        {
        }

        public void AddFigure(Figure fig)
        {
            int ID = 0;
            string bufName = fig.Name;
            while (IfConsist(bufName))
            {
                bufName = fig.Name + "_" + ID.ToString(); 
                ID++;
            }
            fig.Name = bufName;
            Figures.Add(fig);
        }

        private static int CompareByName(Type class1, Type class2)
        { return class1.Name.CompareTo(class2.Name); }

      /*  private static int CompareByLayout(Figure fig1, Figure fig2)
        { return fig1.layout.CompareTo(fig2.layout); }
      */
        public void SortTypesWithName()
        {
            Types.Sort(CompareByName);
        }

        public bool IfConsist(string name)
        {
            foreach (Figure fig in Figures)
            {
                if (name == fig.Name) return true;
            }
            return false;
        }

      /*  public void SortWithLayout()
        {
            Figures.Sort(CompareByLayout);
        }
      */
    }
}
