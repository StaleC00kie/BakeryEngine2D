using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryEngine.API
{
    internal abstract class Component : Object
    {
        protected Component(string name) : base(name)
        {

        }
    }
}
