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
        public EditorWindow(EditorWindowConfiguration editorWindowConfiguration) : base(editorWindowConfiguration.Resolution.X, editorWindowConfiguration.Resolution.Y, editorWindowConfiguration.Title)
        {

        }
    }
}
