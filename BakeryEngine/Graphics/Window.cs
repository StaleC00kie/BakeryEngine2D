using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryEngine.Core;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.SDL;
using Silk.NET.Vulkan;
using Silk.NET.Windowing;

namespace BakeryEngine.Graphics
{
    /// <summary>
    /// A wrapper for a Silk.NET Window while also enables other functionality such as reflection.
    /// </summary>
    public abstract class Window : IDisposable
    {
        private static IWindow _window;
        public static GL GL { get; private set; }

        public Window(int posX, int posY, int width, int height, string title)
        {
            WindowOptions options = WindowOptions.Default;


            //options.Position = new Vector2D<int>(posX, posY);   
            options.Size = new Vector2D<int>(width, height);
            options.Title = title;

            InitWindow(options);
        }
            
        private static void InitWindow(WindowOptions options)
        {
            _window = Silk.NET.Windowing.Window.Create(options);

            _window.Load += OnLoad;
            _window.Update += OnUpdate;
            _window.Render += OnRender;
            _window.FramebufferResize += OnFrameBufferResize;
            _window.Closing += OnClose;

            _window?.Run();
        }

        private static void OnClose()
        {
            //EngineReflection.InvokeMethod<EngineObject>("Draw");
        }

        private static void OnFrameBufferResize(Vector2D<int> newSize)
        {
            GL.Viewport(newSize);
        }

        private static void OnLoad() 
        {
            GL = _window.CreateOpenGL();
            GL.ClearColor(System.Drawing.Color.CornflowerBlue);

            EngineReflection.InvokeMethod<EngineObject>("Construct");

            EngineReflection.InvokeMethod<EngineObject>("Awake");
        }

        protected static void OnRender(double deltaTime)
        {
            GL.Clear((uint)ClearBufferMask.ColorBufferBit);

            EngineReflection.InvokeMethod<EngineObject>("Draw");
        }

        protected static void OnUpdate(double deltaTime)
        {
            EngineReflection.InvokeMethod<EngineObject>("Update");
        }

        public void Dispose()
        {
            _window.Dispose();
        }
    }
}
