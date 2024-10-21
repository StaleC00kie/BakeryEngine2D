using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.

namespace BakeryEngine.Core
{
    internal class EngineReflection
    {
        public EngineReflection() 
        {
        
        }


        public static List<T> GetListOfType<T>(params object[] constructorArgs) where T : class
        {
            List<T> objects = new List<T> ();

            foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }

            //objects.Sort();

            return objects;
        }

        public static void InvokeMethod<T>(string methodName, params object[] constructorArgs) where T : class
        {
            List<T> objects = new List<T>();

            foreach (Type type in Assembly.GetAssembly(typeof(EngineObject)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(EngineObject))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }

            foreach (T obj in objects)
            {
                obj.GetType()?.GetMethod(methodName)?.Invoke(obj, null);
            }
        }
    }
}
