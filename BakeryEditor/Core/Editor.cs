using BakeryEditor.Graphics;
using BakeryEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryEditor.Core
{
    internal class Editor : Application
    {
        private Viewport _viewport;
        public Editor() 
        {
            EditorWindowConfiguration editorWindowConfiguration = new EditorWindowConfiguration(0, 0, 800, 600, "Editor Viewport");
            _viewport = new Viewport(editorWindowConfiguration);
        }

        public void Run()
        {
            _viewport?.Run();
        }
    }
}
