using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryEngine.Core;
using BakeryEngine.Graphics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace BakeryEngine.Input
{
    internal class Input : EngineSingleton<Input>
    {
        private NativeWindow _currentWindow;

        public void Awake()
        {
            Console.WriteLine("Awake");
        }

        public static bool GetKeyDown(Keys key)
        {
            if (Instance._currentWindow.KeyboardState.IsKeyDown(key))
            {
                return true;
            }

            return false;
        }
    }
}
