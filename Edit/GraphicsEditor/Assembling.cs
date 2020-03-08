using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Edit
{
    class Assembling
    {
        public static class ReflectiveEnumerator
        {
            public static List<Type> GetEnumerableOfType<T>() where T : class
            {
                List<Type> classes = new List<Type>();
                foreach (Type type in
                    Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
                {
                    classes.Add(type);
                }
                return classes;
            }
        }
    }
}
