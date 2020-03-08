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

        private static int CompareByName(Type class1, Type class2)
        { return class1.Name.CompareTo(class2.Name); }

      /*  private static int CompareByLayout(Figure fig1, Figure fig2)
        { return fig1.layout.CompareTo(fig2.layout); }
      */
        public void SortTypesWithName()
        {
            Types.Sort(CompareByName);
        }

      /*  public void SortWithLayout()
        {
            Figures.Sort(CompareByLayout);
        }
      */
    }
}
