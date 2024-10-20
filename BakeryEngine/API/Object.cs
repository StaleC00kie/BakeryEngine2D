using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryEngine.API
{
    internal abstract class Object
    {
        public virtual string Name { get; internal set; }

        public Object(string name)
        {
            Name = name;
        }

        public static void Create(Object originalObject)
        {

        }

        public static void Destroy(Object objectToDestroy, float time = 0.0f)
        {

        }
    }
}
