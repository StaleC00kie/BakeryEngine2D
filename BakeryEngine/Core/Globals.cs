using BakeryEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryEngine.Core
{
    internal static class Globals
    {
        public static GraphicsAPI GraphicsAPI
        {
             
            get => _graphicsAPI;
            
            private set 
            { 
                if(_graphicsAPI == GraphicsAPI.Unknown)
                {
                    _graphicsAPI = value;
                }
                else
                {
                    // TODO: Log an error/warning.
                }
            } 
        }

        private static GraphicsAPI _graphicsAPI = GraphicsAPI.Unknown;
    }
}
