using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly archivoAssembly = Assembly.LoadFile("C:/Users/Matias/source/repos/municipality-library-macanepa/APP/APP/ClassLibrary1.dll");
            foreach (Type type in archivoAssembly.GetTypes())
            {
                if (type.IsClass) Console.WriteLine("class");
                else if (type.IsInterface) Console.WriteLine("interface");
                else Console.WriteLine("otro tipo");
                Console.WriteLine(type.Name);
                MethodInfo[] properties = type.GetMethods();

                PropertyInfo[] propinfo = type.GetProperties();
                
                foreach(PropertyInfo prop in propinfo)
                {
                    Console.WriteLine(prop.Name + "\t" + prop.PropertyType);
                }


                Console.WriteLine("metodos: ");
                foreach (MethodInfo prop in properties)
                {
                    Console.WriteLine("\t" + prop.Name + "\t" + prop.ReturnType);
                    ParameterInfo[] paramInfo = prop.GetParameters();
                    foreach(ParameterInfo p in paramInfo)
                    {
                        Console.WriteLine("\t\t"+p);
                    }
                    //Console.WriteLine();

                }

                Console.WriteLine();


            }
            Console.ReadKey();

        }
    }
}
