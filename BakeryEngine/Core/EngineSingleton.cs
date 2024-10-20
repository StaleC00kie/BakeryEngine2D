using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryEngine.API;

namespace BakeryEngine.Core
{
    internal abstract class EngineSingleton<T> : EngineObject where T : EngineObject
    {
        public static T Instance { get; private set; }

//        protected sealed override void Construct()
//        {
//            if(Instance == null)
//            {
//#pragma warning disable CS8601 // Possible null reference assignment.
//                Instance = this as T;
//#pragma warning restore CS8601 // Possible null reference assignment.
//            }
//            else
//            {
//                Destroy(this);
//            }
//        }
    }
}
