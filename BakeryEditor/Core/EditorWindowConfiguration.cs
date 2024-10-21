using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryEditor.Core
{
    internal struct EditorWindowConfiguration
    {
        public Vector2i Resolution { get; private set; } = new Vector2i(800, 600);
        public string Title { get; private set; } = "Bakery Editor";

        public EditorWindowConfiguration(Vector2i resolution, string title) 
        {
            if(resolution.X <= 0 || resolution.Y <= 0)
            {
                throw new ArgumentException($"{nameof(resolution)} in the {nameof(EditorWindowConfiguration)} constructor needs to contain positive elements only.");
            }

            Resolution = resolution;
            Title = title;
        }

        public EditorWindowConfiguration(int width, int height, string title)
        {
            if(width <= 0 || height <= 0)
            {
                throw new ArgumentException($"{nameof(width)} and/or {nameof(height)} in the {nameof(EditorWindowConfiguration)} constructor both need to be positive.");
            }

            Resolution = new Vector2i(width, height);
            Title = title;
        }
    }
}
