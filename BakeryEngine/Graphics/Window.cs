using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryEngine.Core;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace BakeryEngine.Graphics
{
    public abstract class Window : GameWindow
    {
        public Window(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { ClientSize = (width, height), Title = title }) 
        {
            EngineReflection.InvokeMethod<EngineObject>("Construct");

            EngineReflection.InvokeMethod<EngineObject>("Awake");
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            EngineReflection.InvokeMethod<EngineObject>("Draw");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            EngineReflection.InvokeMethod<EngineObject>("Update");
        }
    }
}
