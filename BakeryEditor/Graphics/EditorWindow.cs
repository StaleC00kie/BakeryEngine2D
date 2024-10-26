using BakeryEditor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryEditor.Graphics
{
    internal abstract class EditorWindow : BakeryEngine.Graphics.Window
    {
        public EditorWindow(EditorWindowConfiguration configuration) : base(configuration.WindowPosition.X, configuration.WindowPosition.Y, configuration.Size.X, configuration.Size.Y, configuration.Title, configuration.GraphicsAPI)
        {

        }
    }
}
