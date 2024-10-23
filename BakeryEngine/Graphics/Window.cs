using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryEngine.Core;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;
using Vulkan.Xlib;

namespace BakeryEngine.Graphics
{
    /// <summary>
    /// A wrapper for a SDL2 Window while also enables other functionality such as
    /// </summary>
    public abstract class Window
    {
        public Sdl2Window Sdl2Window { get; private set; }
        public GraphicsDevice GraphicsDevice { get; private set; }

        public Window(int posX, int posY, int width, int height, string title, GraphicsAPI graphicsAPI = GraphicsAPI.OpenGL3)
        {
            WindowCreateInfo windowInfo = new WindowCreateInfo()
            {
                X = posX,
                Y = posY,
                WindowWidth = width,
                WindowHeight = height,
                WindowTitle = title,
            };

            InitSDLWindow(ref windowInfo);


            GraphicsDeviceOptions options = new GraphicsDeviceOptions
            {
                PreferStandardClipSpaceYDirection = true,
                PreferDepthRangeZeroToOne = true
            };


            switch (graphicsAPI)
            {
                case GraphicsAPI.Unknown:
                    break;
                case GraphicsAPI.OpenGL3:

                    options.PreferStandardClipSpaceYDirection = true;
                    options.PreferDepthRangeZeroToOne = false;

                    break;
                case GraphicsAPI.Vulkan:

                    options.PreferStandardClipSpaceYDirection = false;
                    options.PreferDepthRangeZeroToOne = true;
                    break;
                case GraphicsAPI.D3D11:

                    options.PreferStandardClipSpaceYDirection = true;
                    options.PreferDepthRangeZeroToOne = true;

                    break;
                default:
                    break;
            }


            GraphicsDevice = VeldridStartup.CreateGraphicsDevice(Sdl2Window, options);

            EngineReflection.InvokeMethod<EngineObject>("Construct");

            EngineReflection.InvokeMethod<EngineObject>("Awake");
        }

        private void InitSDLWindow(ref WindowCreateInfo windowInfo)
        {
            Sdl2Window = VeldridStartup.CreateWindow(ref windowInfo);
        }

        protected void RenderFrame()
        {


            EngineReflection.InvokeMethod<EngineObject>("Draw");
        }

        protected void UpdateFrame()
        {
            EngineReflection.InvokeMethod<EngineObject>("Update");
        }
    }
}
