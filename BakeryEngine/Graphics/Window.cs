using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryEngine.Core;
using Silk.NET.Maths;
using Silk.NET.SDL;
using Silk.NET.Vulkan;
using Silk.NET.Windowing;

namespace BakeryEngine.Graphics
{
    /// <summary>
    /// A wrapper for a SDL2 Window while also enables other functionality such as reflection.
    /// </summary>
    public abstract class Window
    {
        private static IWindow _window;

        public Window(int posX, int posY, int width, int height, string title, GraphicsAPI graphicsAPI)
        {
            WindowOptions options = WindowOptions.Default;

            options.API = graphicsAPI;
            options.Position = new Vector2D<int>(posX, posY);   
            options.Size = new Vector2D<int>(width, height);
            options.Title = title;

            InitWindow(options);
        }
            
        public void Run()
        {
            _window?.Run();
        }

        private static void InitWindow(WindowOptions options)
        {
            _window = Silk.NET.Windowing.Window.Create(options);

            _window.Load += OnLoad;
            _window.Update += OnUpdate;
            _window.Render += OnRender;
        }

        private static void OnLoad() 
        {
            EngineReflection.InvokeMethod<EngineObject>("Construct");

            EngineReflection.InvokeMethod<EngineObject>("Awake");
        }

        protected static void OnRender(double deltaTime)
        {
            EngineReflection.InvokeMethod<EngineObject>("Draw");
        }

        protected static void OnUpdate(double deltaTime)
        {
            EngineReflection.InvokeMethod<EngineObject>("Update");
        }
    }
}
