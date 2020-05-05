using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using FigureClass;

namespace GraphicsEditor
{
    static class Serialization
    {
        public static bool SaveFigure(string filename, int index, Model data)
        {
            Figure fig = data.Figures[index];
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    formatter.Serialize(fs, fig);

                }
                return true;
            }
            catch
            {

                return false;
            }
        }

        public static bool LoadFigure(Model data, string path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    Figure fig = (Figure)formatter.Deserialize(fs);
                    data.Figures.Add(fig);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool SaveList(string filename, Model data)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    formatter.Serialize(fs, data.Figures);

                }
                return true;
            }
            catch
            {

                return false;
            }
        }

        public static bool LoadList(Model data, string path)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    List<Figure> list = (List<Figure>)formatter.Deserialize(fs);
                    data.Figures.AddRange(list);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
