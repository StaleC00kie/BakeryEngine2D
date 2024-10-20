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
    public class MainWindow : GameWindow
    {
        public MainWindow(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { ClientSize = (width, height), Title = title }) 
        {
            EngineReflection.DoAwake<EngineObject>();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
    }
}
